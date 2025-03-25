using System.Text;
using System.Security.Cryptography;

using CNUCoin.BLL.Crypto.Interfaces;

namespace CNUCoin.BLL.Crypto.Implementations
{
	/// <summary>
	/// Realisation of <see cref="ICryptoService"/>.
	/// </summary>
	public class CryptoService : ICryptoService
	{
		#region Constants

		private const int RSA_KEY_LENGTH = 2048;

		#endregion

		#region Realisation of ICryptoService
		/// <inheritdoc/>
		public (string, string) GenerateRsaKeys()
		{
			using var rsa = RSA.Create(RSA_KEY_LENGTH);

			return (Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo()),
				Convert.ToBase64String(rsa.ExportPkcs8PrivateKey()));
		}

		/// <inheritdoc/>
		public string Sha256Hash(string? value) 
			=> Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(value)));

		#endregion
	}
}
