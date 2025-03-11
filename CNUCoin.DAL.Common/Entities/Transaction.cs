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
		/// Provides information about transaction date.
		/// </summary>
		public DateTime TransactionDate { get; set; }

		/// <summary>
		/// Provides information about sender id.
		/// </summary>
		public string? FromId { get; set; }

		/// <summary>
		/// Provides information about receiver id.
		/// </summary>
		public string? ToId { get; set; }

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
		public string? AssignedById { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Provides information about sender.
		/// </summary>
		public Member? From { get; set; }

		/// <summary>
		/// Provides information about receiver.
		/// </summary>
		public Member? To { get; set; }

		/// <summary>
		/// Provides information about who is assign transaction. Object.
		/// </summary>
		public Member? AssignedBy { get; set; }

		#endregion
	}
}
