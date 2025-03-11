namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about member of system.
	/// </summary>
	public class Member
	{
		#region Properties

		/// <summary>
		/// Provides information about member crypto id.
		/// </summary>
		public string? MemberId { get; set; }

		/// <summary>
		/// Provides information about member username.
		/// </summary>
		public string? Username { get; set; }

		/// <summary>
		/// Provides information about member password.
		/// </summary>
		public string? Password { get; set; }

		/// <summary>
		/// Provides information about member public key.
		/// </summary>
		public string? PublicKey { get; set; }

		/// <summary>
		/// Provides information whether member is miner or not.
		/// </summary>
		public bool IsMiner { get; set; }

		#endregion

		#region Relations
		
		/// <summary>
		/// Provides information about member wallet.
		/// </summary>
		public Wallet? Wallet { get; set; }

		/// <summary>
		/// Provides information about member sended transactions.
		/// </summary>
		public List<Transaction>? TransactionsFrom { get; set; }

		/// <summary>
		/// Provides information about member received transactions.
		/// </summary>
		public List<Transaction>? TransactionsTo { get; set; }

		/// <summary>
		/// Provides information about member assigned by transactions.
		/// </summary>
		public List<Transaction>? TransactionsAssigned { get; set; }

		/// <summary>
		/// Provides information about member mined by block chains.
		/// </summary>
		public List<Block>? BlocksMained { get; set; }
		
		/// <summary>
		/// Provides information about member assigned by block chains.
		/// </summary>
		public List<Block>? BlocksAssigned { get; set; }

		#endregion
	}
}
