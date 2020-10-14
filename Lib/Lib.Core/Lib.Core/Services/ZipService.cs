using System.IO.Compression;

namespace Lib.Core
{
    public class ZipService : IZipService
	{
		public void Zip(string folderPath, string zipName)
		{
            ZipFile.CreateFromDirectory(folderPath, zipName);
        }

		public void Unzip(string zipPath, string folderName)
		{
            ZipFile.ExtractToDirectory(zipPath, folderName);
        }

		////public Stream[] Unzip(byte[] bytes)
		////{
		////	var zipEntries = new List<Stream>();
		////	using (var memoryStream = new MemoryStream(bytes))
		////	{
		////		var zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Read);
		////		foreach (var zipArchiveEntry in zipArchive.Entries)
		////		{
		////			var entry = zipArchiveEntry;
		////			var entryStream = entry.Open();
		////			zipEntries.Add(entryStream);
		////		}
		////	}

		////	return zipEntries.ToArray();
		////}
	}
}