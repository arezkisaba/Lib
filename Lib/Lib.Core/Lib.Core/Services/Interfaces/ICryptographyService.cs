using System.Threading.Tasks;

namespace Lib.Core
{
	public interface ICryptographyService
    {
		Task<byte[]> EncryptAsync(byte[] bytes);

		Task<byte[]> DecryptAsync(byte[] bytes);
	}
}