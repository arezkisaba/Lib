namespace Lib.Core
{
	public interface IZipService
	{
		void Zip(string folderPath, string zipName);

		void Unzip(string zipPath, string folderName);
	}
}