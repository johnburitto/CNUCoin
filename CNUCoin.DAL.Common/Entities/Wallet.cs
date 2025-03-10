namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about <see cref="Member"/> wallet.
	/// </summary>
	public class Wallet
	{
		/// <summary>
		/// Provides information about wallet id.
		/// </summary>
		public Guid WalletId { get; set; }

		/// <summary>
		/// Owner crypto id.
		/// </summary>
		public string? OwnerCryptoId { get; set; }

		/// <summary>
		/// Provides information about transaction amount.
		/// </summary>
		public int Amount { get; set; }
	}
}
