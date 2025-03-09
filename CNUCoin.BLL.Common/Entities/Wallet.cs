namespace CNUCoin.BLL.Common.Entities
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
		/// Provides information about transaction date.
		/// </summary>
		public DateTime TransactionDate { get; set; }

		/// <summary>
		/// Provides information about sender.
		/// </summary>
		public Guid From {  get; set; }
		
		/// <summary>
		/// Provides information about receiver.
		/// </summary>
		public Guid To { get; set; }

		/// <summary>
		/// Provides information about transaction amount.
		/// </summary>
		public int Amount { get; set; }
	}
}
