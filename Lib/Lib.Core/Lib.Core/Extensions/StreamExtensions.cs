using System.IO;

namespace Lib.Core
{
	public static class StreamExtensions
	{
		public static byte[] ToBytes(this Stream stream)
		{
			var memoryStream = new MemoryStream();
			var bytes = new byte[stream.Length];
			int nbRead;
			stream.Seek(0, SeekOrigin.Begin);
			
			while ((nbRead = stream.Read(bytes, 0, bytes.Length)) > 0)
			{
				memoryStream.Write(bytes, 0, nbRead);
			}

			return memoryStream.ToArray();
		}
	}
}