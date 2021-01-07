using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lib.Core;

namespace Lib.ApiServices.Torrents
{
    public class SkyTorrentsTorrentScrapperService : TorrentScrapperServiceBase
    {
        protected override string RowRegexp => "<tr.*?>(.*?)</tr>";
        protected override string RowFilterRegexp => "<tr class=\"result\"";
        protected override string TorrentSizeRegexp => "<td.*?>(.*?)</td>";
        protected override string TorrentSeedsRegexp => "<td.*?>(.*?)</td>";
        public override bool IsActive => true;
        public override int Priority => 6;
        public override string Name => "SkyTorrents";

        public SkyTorrentsTorrentScrapperService(string url)
            : base(url)
        {
        }

        protected override async Task<List<TorrentDto>> GetTorrentsByKeywordAsync(string keyword, int timeout = 20)
        {
            var content = await _httpService.GetStringAsync($"?query={keyword}");
            content = RegexHelper.RemoveCarriageReturnAndOtherFuckingCharacters(content);

            var torrents = new List<TorrentDto>();
            var regexTr = new Regex(RowRegexp);
            var matchesTr = regexTr.Matches(content);

            foreach (Match matchTr in matchesTr)
            {
                var valueTr = matchTr.Groups[0].Value;
                if (valueTr.Contains("<th") || valueTr.Contains("Found 0 results"))
                {
                    continue;
                }

                var regexTd = new Regex("<td.*?>(.*?)</td>");
                var matchesTd = regexTd.Matches(valueTr);

                var nameAndLink = RegexHelper.GetParamsFromLink(valueTr);
                var valueSize = RegexHelper.RemoveHtml(matchesTd[1].Groups[1].Value);
                var valueSeeds = RegexHelper.RemoveHtml(matchesTd[4].Groups[1].Value).Replace(",", string.Empty);

                if (!string.IsNullOrWhiteSpace(nameAndLink.Item2))
                {
                    torrents.Add(new TorrentDto
                    {
                        DescriptionUrl = $"{Url}/{nameAndLink.Item2}",
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
