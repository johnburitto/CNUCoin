namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about <see cref="Member"/> wallet.
	/// </summary>
	public class Wallet
	{
		#region Properties

		/// <summary>
		/// Provides information about wallet id.
		/// </summary>
		public Guid WalletId { get; set; }

		/// <summary>
		/// Provides information about owner id.
		/// </summary>
		public string? OwnerId { get; set; }

		/// <summary>
		/// Provides information about transaction amount.
		/// </summary>
		public float Amount { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Provides information about owner.
		/// </summary>
		public Member? Owner { get; set; }

		#endregion
	}
}
