using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lib.Core;

namespace Lib.ApiServices.Torrents
{
    public class Torrent9TorrentScrapperService : TorrentScrapperServiceBase
    {
        protected override string RowRegexp => "<tr.*?>(.*?)</tr>";
        protected override string RowFilterRegexp => "<tr><td>";
        protected override string TorrentSizeRegexp => "<td.*?>(.*?)</td>";
        protected override string TorrentSeedsRegexp => "<td.*?>(.*?)</td>";
        public override bool IsActive => true;
        public override int Priority => 2;
        public override string Name => "Torrent9";

        public Torrent9TorrentScrapperService(string url)
            : base(url)
        {
        }

        protected override async Task<List<TorrentDto>> GetTorrentsByKeywordAsync(string keyword, int timeout = 20)
        {
            var content = await _httpService.GetStringAsync($"recherche/{keyword}");
            content = StringExtensions.RemoveCarriageReturnAndOtherFuckingCharacters(content);

            var torrents = new List<TorrentDto>();
            var regexTr = new Regex(RowRegexp);
            var matchesTr = regexTr.Matches(content);
            foreach (Match matchTr in matchesTr)
            {
                var valueTr = matchTr.Groups[0].Value.Replace("<span style=\"color:#337ab7\">", "").Replace("</span>", "");

                var regexTrWithFilter = new Regex(RowFilterRegexp);
                var matchesTrWithFilter = regexTrWithFilter.Matches(valueTr);
                if (matchesTrWithFilter.Count <= 0)
                {
                    continue;
                }

                var nameAndLink = ScrappingHelper.GetParamsFromLink(valueTr);
                var regexSize = new Regex(TorrentSizeRegexp);
                var matchesSize = regexSize.Matches(valueTr);
                var valueSize = StringExtensions.RemoveHtml(matchesSize[1].Groups[1].Value);
                var regexSeeds = new Regex(TorrentSeedsRegexp);
                var matchesSeeds = regexSeeds.Matches(valueTr);
                var valueSeeds = StringExtensions.RemoveHtml(matchesSeeds[2].Groups[1].Value);

                if (!string.IsNullOrWhiteSpace(nameAndLink.Item2))
                {
                    torrents.Add(new TorrentDto
                    {
                        DescriptionUrl = $"{Url}{nameAndLink.Item2}",
                        Name = nameAndLink.Item1,
                        Provider = Name,
                        Seeds = Convert.ToInt32(valueSeeds),
                        Size = ScrappingHelper.ConvertSizeStringToNumber(valueSize)
                    });
                }
            }

            foreach (var torrent in torrents)
            {
                torrent.Url = await GetMagnetUrlAsync(torrent);
            }

            torrents.RemoveAll(obj => string.IsNullOrWhiteSpace(obj.Url));

            return torrents;
        }
    }
}
