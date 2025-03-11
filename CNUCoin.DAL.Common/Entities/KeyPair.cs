namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about <see cref="Member"/> key pair.
	/// </summary>
	public class KeyPair
	{
		/// <summary>
		/// Provides information about key pair id.
		/// </summary>
		public Guid KeyPairId { get; set; }

		/// <summary>
		/// Provides information about public key.
		/// </summary>
		public string? PublicKey { get; set; }

		/// <summary>
		/// Provides information about private key.
		/// </summary>
		public string? PrivateKey { get; set; }
	}
}
