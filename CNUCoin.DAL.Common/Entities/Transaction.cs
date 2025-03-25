namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about transaction.
	/// </summary>
	public class Transaction
	{
		#region Properties

		/// <summary>
		/// Provides information about transaction id.
		/// </summary>
		public Guid TransactionId { get; set; }

		/// <summary>
		/// Provides information about block, where transaction is chained.
		/// </summary>
		public Guid BlockId { get; set; }

		/// <summary>
		/// Provides information about transaction date.
		/// </summary>
		public DateTime TransactionDate { get; set; }

		/// <summary>
		/// Provides information about sender id.
		/// </summary>
		public string? SenderId { get; set; }

		/// <summary>
		/// Provides information about receiver id.
		/// </summary>
		public string? ReceiverId { get; set; }

		/// <summary>
		/// Provides information about transaction hash.
		/// </summary>
		public string? Hash { get; set; }

		/// <summary>
		/// Provides information whether transaction is approved or not.
		/// </summary>
		public bool Approved { get; set; }

		/// <summary>
		/// Provides information about transaction amount.
		/// </summary>
		public float Amount { get; set; }

		/// <summary>
		/// Provides information about  sender signature.
		/// </summary>
		public byte[]? ECP { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Provides information about sender.
		/// </summary>
		public Member? Sender { get; set; }

		/// <summary>
		/// Provides information about receiver.
		/// </summary>
		public Member? Receiver { get; set; }

		/// <summary>
		/// Provides information about block, where transaction is chained. Object.
		/// </summary>
		public Block? Block { get; set; }

		#endregion
	}
}
