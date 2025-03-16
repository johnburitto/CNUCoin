namespace CNUCoin.BLL.Crypto.Interfaces
{
	/// <summary>
	/// Describe all methods to process crypto operations
	/// </summary>
	public interface ICryptoService
	{
		/// <summary>
		/// Generate public and private RSA keys for identification of user.
		/// </summary>
		/// <returns>String representations of public and private RSA keys.</returns>
		(string, string) GenerateRsaKeys();

		/// <summary>
		/// Hash data using SHA256 hash function.
		/// </summary>
		/// <param name="value">Data to hash.</param>
		/// <returns>String representations of hash.</returns>
		string Sha256Hash(string? value);
	}
}
