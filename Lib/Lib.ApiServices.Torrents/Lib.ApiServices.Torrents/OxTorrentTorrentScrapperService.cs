using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lib.Core;

namespace Lib.ApiServices.Torrents
{
    public class OxTorrentTorrentScrapperService : TorrentScrapperServiceBase
    {
        protected override string RowRegexp => "<tr.*?>(.*?)</tr>";
        protected override string RowFilterRegexp => "<tr><td>";
        protected override string TorrentSizeRegexp => "<td.*?>(.*?)</td>";
        protected override string TorrentSeedsRegexp => "<td.*?>(.*?)</td>";
        public override bool IsActive => true;
        public override int Priority => 1;
        public override string Name => "OxTorrent";

        public OxTorrentTorrentScrapperService(string url)
            : base(url)
        {
        }

        protected override async Task<List<TorrentDto>> GetTorrentsByKeywordAsync(string keyword, int timeout = 20)
        {
            var content = await _httpService.GetStringAsync($"recherche/{keyword}");
            content = StringExtensions.RemoveCarriageReturnAndOtherFuckingCharacters(content);
            content = Regex.Replace(content, "\\s*title=\".*?\"\\s*", "", RegexOptions.Singleline);

            var torrents = new List<TorrentDto>();
            var regexTr = new Regex(RowRegexp);
            var matchesTr = regexTr.Matches(content);

            foreach (Match matchTr in matchesTr)
            {
                var valueTr = matchTr.Groups[0].Value;
                if (valueTr.Contains("<th") || valueTr.Contains("Pas de torrents"))
                {
                    continue;
                }

                var regexTd = new Regex("<td.*?>(.*?)</td>");
                var matchesTd = regexTd.Matches(valueTr);

                var nameAndLink = ScrappingHelper.GetParamsFromLink(valueTr);
                var valueSize = StringExtensions.RemoveHtml(matchesTd[1].Groups[1].Value);
                var valueSeeds = StringExtensions.RemoveHtml(matchesTd[2].Groups[1].Value);

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
