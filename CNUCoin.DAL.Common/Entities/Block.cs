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
		public string? BlockChainHash { get; set; }

		/// <summary>
		/// Provides information about 'salt'.
		/// </summary>
		public string? Nonce { get; set; }

		/// <summary>
		/// Provides information about who is assign block.
		/// </summary>
		public string? AssignedById { get; set; }

		#endregion

		#region Relations

		/// <summary>
		/// Provides information about miner.
		/// </summary>
		public Member? Miner { get; set; }

		/// <summary>
		/// Provides information about who is assign block. Object.
		/// </summary>
		public Member? AssignedBy { get; set; }

		#endregion
	}
}
