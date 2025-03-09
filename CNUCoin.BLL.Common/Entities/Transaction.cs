namespace CNUCoin.BLL.Common.Entities
{
	/// <summary>
	/// Holds information about transaction.
	/// </summary>
	public class Transaction
	{
		/// <summary>
		/// Provides information about transaction id.
		/// </summary>
		public Guid TransactionId { get; set; }

		/// <summary>
		/// Provides information about transaction date.
		/// </summary>
		public DateTime TransactionDate { get; set; }

		/// <summary>
		/// Provides information about sender.
		/// </summary>
		public Guid From { get; set; }

		/// <summary>
		/// Provides information about receiver.
		/// </summary>
		public Guid To { get; set; }

		/// <summary>
		/// Provides information about transaction hash.
		/// </summary>
		public string? Hash { get; set; }

		/// <summary>
		/// Provides information about 'salt'.
		/// </summary>
		public string? Nonce { get; set; }

		/// <summary>
		/// Provides information whether transaction is approved or not.
		/// </summary>
		public bool Approved { get; set; }

		/// <summary>
		/// Provides information about who is assign transaction.
		/// </summary>
		public Guid AssignedBy { get; set; }
	}
}
