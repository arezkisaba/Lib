using Lib.Core;
using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Security.Cryptography.DataProtection;

namespace Lib.Uwp
{
    public class CryptographyService
	{
		public async Task<byte[]> EncryptAsync(byte[] bytes)
		{
			var data = bytes.AsBuffer(0, bytes.Length);
			var provider = new DataProtectionProvider("Local=user");
			var protectedData = await provider.ProtectAsync(data);
			return protectedData.ToArray();
		}

		public async Task<byte[]> DecryptAsync(byte[] bytes)
		{
			var data = bytes.AsBuffer(0, bytes.Length);
			var provider = new DataProtectionProvider();
			var unprotectedData = await provider.UnprotectAsync(data);
			return unprotectedData.ToArray();
		}
	}
}