using Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.ApiServices.Torrents
{
    public abstract class TorrentScrapperServiceBase
    {
        #region Dirty

        protected HttpService _httpService;
        private string _tvShowTitle = "Game of Thrones";

        #endregion

        protected abstract string RowRegexp { get; }
        protected abstract string RowFilterRegexp { get; }
        protected abstract string TorrentSizeRegexp { get; }
        protected abstract string TorrentSeedsRegexp { get; }
        public abstract bool IsActive { get; }
        public abstract int Priority { get; }
        public abstract string Name { get; }

        public string Url { get; set; }

        public TorrentScrapperServiceBase(string url)
        {
            Url = url;
            _httpService = new HttpService(Url, randomizeUserAgent: true);
        }

        public async Task<List<TorrentDto>> GetTorrentsByKeywordQueryAsync(string keyword)
        {
            return await GetTorrentsByKeywordAsync($"{keyword.Replace(" ", "%20")}");
        }

        public async Task<bool> TestAvailabilityAsync()
        {
            try
            {
                var torrents = await GetTorrentsByKeywordAsync(_tvShowTitle.Replace(" ", "%20"));
                if (torrents == null || !torrents.Any())
                {
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected abstract Task<List<TorrentDto>> GetTorrentsByKeywordAsync(string keyword, int timeout = 20);

        protected virtual async Task<string> GetMagnetUrlAsync(TorrentDto torrent)
        {
            var content = await _httpService.GetStringAsync(torrent.DescriptionUrl);
            content = content.Replace("<br>", "").Replace("<br/>", "").Replace("<br />", "").Replace("\t", "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "");
            return ScrappingHelper.GetMagnetLink(content);
        }
    }
}
