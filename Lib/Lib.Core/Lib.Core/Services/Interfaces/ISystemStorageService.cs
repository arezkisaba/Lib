using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Core
{
    public interface ISystemStorageService
    {
        Task CreateFileAsync(string fileName, bool overwrite = false);

        Task CreateFolderAsync(string folderName);

        Task DeleteFileAsync(string fileName);

        Task DeleteFolderAsync(string folderName);

        Task<byte[]> ReadBytesAsync(string fileName);

        Task<string> ReadTextAsync(string fileName);

        Task<T> ReadObjectAsync<T>(string fileName, ExchangeFormat format) where T : class;

        Task WriteBytesAsync(string fileName, byte[] bytes);

        Task WriteTextAsync(string fileName, string text);

        Task WriteObjectAsync<T>(string fileName, T value, ExchangeFormat format) where T : class;

        Task AppendTextAsync(string fileName, string text);

        Task CopyFileAsync(string source, string destination, bool overwrite = true);

        Task MoveFileAsync(string source, string destination);

        Task<List<string>> GetFilesFromFolderAsync(string path, bool recursive = false, bool includePath = false, string filter = null);
    }
}