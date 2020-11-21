using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Core
{
    public class SystemStorageService : ISystemStorageService
    {
        public Task CreateFileAsync(string fileName, bool overwrite = false)
        {
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            else
            {
                if (overwrite)
                {
                    File.Delete(fileName);
                    File.Create(fileName);
                }
            }

            return Task.CompletedTask;
        }

        public Task CreateFolderAsync(string folderName)
        {
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            return Task.CompletedTask;
        }

        public Task DeleteFileAsync(string fileName)
        {
            File.Delete(fileName);
            return Task.CompletedTask;
        }

        public Task DeleteFolderAsync(string folderName)
        {
            Directory.Delete(folderName, recursive: true);
            return Task.CompletedTask;
        }

        public Task<byte[]> ReadBytesAsync(string fileName)
        {
            return Task.FromResult(File.ReadAllBytes(fileName));
        }

        public Task<string> ReadTextAsync(string fileName)
        {
            return Task.FromResult(File.ReadAllText(fileName));
        }

        public async Task<T> ReadObjectAsync<T>(string fileName, ExchangeFormat format) where T : class
        {
            if (format == ExchangeFormat.Json)
            {
                var text = await ReadTextAsync(fileName);
                return await Serializer.JsonDeserializeAsync<T>(text);
            }
            else if (format == ExchangeFormat.Xml)
            {
                var text = await ReadTextAsync(fileName);
                return await Serializer.XmlDeserializeAsync<T>(text);
            }
            else
            {
                throw new ArgumentException("[ReadObjectAsync()] format invalid");
            }
        }

        public Task WriteBytesAsync(string fileName, byte[] bytes)
        {
            File.WriteAllBytes(fileName, bytes);
            return Task.CompletedTask;
        }

        public Task WriteTextAsync(string fileName, string text)
        {
            File.WriteAllText(fileName, text);
            return Task.CompletedTask;
        }

        public async Task WriteObjectAsync<T>(string fileName, T value, ExchangeFormat format) where T : class
        {
            if (format == ExchangeFormat.Json)
            {
                var text = await Serializer.JsonSerializeAsync(value);
                await WriteTextAsync(fileName, text);
            }
            else if (format == ExchangeFormat.Xml)
            {
                var text = await Serializer.XmlSerializeAsync(value);
                await WriteTextAsync(fileName, text);
            }
            else
            {
                throw new ArgumentException("[WriteObjectAsync()] format invalid");
            }
        }

        public Task AppendTextAsync(string fileName, string text)
        {
            File.AppendAllText(fileName, text);
            return Task.CompletedTask;
        }

        public Task CopyFileAsync(string source, string destination, bool overwrite = true)
        {
            File.Copy(source, destination, overwrite);
            return Task.CompletedTask;
        }

        public Task MoveFileAsync(string source, string destination)
        {
            File.Move(source, destination);
            return Task.CompletedTask;
        }

        public async Task<List<string>> GetFilesFromFolderAsync(string path, bool recursive = false, bool includePath = false, string filter = null)
        {
            if (recursive)
            {
                return await GetAllFilesFromFolderAsync(path, includePath: includePath, filter: filter);
            }
            else
            {
                var files = Directory.GetFiles(path).ToList();
                return files.Where(obj =>
                {
                    if (!string.IsNullOrWhiteSpace(filter) && !obj.EndsWith(filter))
                    {
                        return false;
                    }

                    return true;

                }).Select(obj => includePath ? obj : Path.GetFileName(obj)).ToList();
            }
        }

        private async Task<List<string>> GetAllFilesFromFolderAsync(string path, bool includePath = false, string filter = null)
        {
            var filesToReturn = new List<string>();
            var files = Directory.GetFileSystemEntries(path);

            foreach (var file in files)
            {
                if (Directory.Exists(file))
                {
                    var newFiles = await GetAllFilesFromFolderAsync(file, includePath: includePath, filter: filter);
                    filesToReturn.AddRange(newFiles);
                }

                if (File.Exists(file))
                {
                    if (!string.IsNullOrWhiteSpace(filter) && !file.EndsWith(filter))
                    {
                    }
                    else
                    {
                        filesToReturn.Add(includePath ? file : Path.GetFileName(file));
                    }
                }
            }

            return filesToReturn;
        }

    }
}