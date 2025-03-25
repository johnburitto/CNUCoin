namespace CNUCoin.DAL.Common.Entities
{
	/// <summary>
	/// Holds information about BlockChain.
	/// </summary>
	public class Block
	{
		#region Properties

		/// <summary>
		/// Provides information about block chain id.
		/// </summary>
		public Guid BlockId { get; set; }
		
		/// <summary>
		/// Provides information about miner id.
		/// </summary>
		public string? MinerId { get; set; }

		/// <summary>
		/// Provides information about last hash date.
		/// </summary>
		public DateTime LastHashDate { get; set; }

		/// <summary>
		/// Provides information about block chain hash.
		/// </summary>
		public string? BlockHash { get; set; }

		/// <summary>
		/// Provides information about previous block chain hash.
		/// </summary>
		public string? PreviousBlockHash { get; set; }

		/// <summary>
		/// Provides information about 'salt'.
		/// </summary>
		public string? Nonce { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Provides information about miner.
		/// </summary>
		public Member? Miner { get; set; }

		/// <summary>
		/// Provides information about transactions in block.
		/// </summary>
		public List<Transaction>? Transactions { get; set; }

		#endregion
	}
}
