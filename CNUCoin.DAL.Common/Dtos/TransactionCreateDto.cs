namespace CNUCoin.DAL.Common.Dtos
{
	/// <summary>
	/// Holds all needed information for creation transaction.
	/// </summary>
	public class TransactionCreateDto
	{
		/// <summary>
		/// Provides information about sender id.
		/// </summary>
		public string? SenderId { get; set; }

		/// <summary>
		/// Provides information about receiver.
		/// </summary>
		public string? ReceiverId { get; set; }

		/// <summary>
		/// Provides information about trnsaction amount.
		/// </summary>
		public float Amount { get; set; }

		/// <summary>
		/// Provides information avout member private key.
		/// </summary>
		public string? PrivateKey { get; set; }
	}
}
