using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lib.Core;

namespace Lib.ApiServices.Torrents
{
    public class IdopeTorrentScrapperService : TorrentScrapperServiceBase
    {
        protected override string RowRegexp => "<div class=\"resultdiv\">(.*?)MAGNET URI";
        protected override string RowFilterRegexp => "<div class=\"resultdiv\"";
        protected override string TorrentSizeRegexp => "<div class=['\"]resultdivbottonlength['\"]>(.*?)</div>";
        protected override string TorrentSeedsRegexp => "<div class=['\"]resultdivbottonseed['\"]>(.*?)</div>";
        public override bool IsActive => true;
        public override int Priority => 5;
        public override string Name => "Idope";

        public IdopeTorrentScrapperService(string url)
            : base(url)
        {
        }

        protected override async Task<List<TorrentDto>> GetTorrentsByKeywordAsync(string keyword, int timeout = 20)
        {
            var content = await _httpService.GetStringAsync($"torrent-list/{keyword}");
            content = StringExtensions.RemoveCarriageReturnAndOtherFuckingCharacters(content);

            var torrents = new List<TorrentDto>();
            var regexTr = new Regex(RowRegexp);
            var matchesTr = regexTr.Matches(content);
            foreach (Match matchTr in matchesTr)
            {
                var valueTr = matchTr.Groups[0].Value;

                var regexTrWithFilter = new Regex(RowFilterRegexp);
                var matchesTrWithFilter = regexTrWithFilter.Matches(valueTr);
                if (matchesTrWithFilter.Count <= 0)
                {
                    continue;
                }

                var nameAndLink = ScrappingHelper.GetParamsFromLink(valueTr);
                var regexSize = new Regex(TorrentSizeRegexp);
                var matchesSize = regexSize.Matches(valueTr);
                var valueSize = StringExtensions.RemoveHtml(matchesSize[0].Groups[1].Value);
                var regexSeeds = new Regex(TorrentSeedsRegexp);
                var matchesSeed = regexSeeds.Matches(valueTr);
                var valueSeeds = StringExtensions.RemoveHtml(matchesSeed[0].Groups[1].Value);

                if (!string.IsNullOrWhiteSpace(nameAndLink.Item2))
                {
                    torrents.Add(new TorrentDto
                    {
                        DescriptionUrl = $"{nameAndLink.Item2}",
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
