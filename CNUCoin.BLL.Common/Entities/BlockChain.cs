namespace CNUCoin.BLL.Common.Entities
{
	/// <summary>
	/// Holds information about BlockChain.
	/// </summary>
	public class BlockChain
	{
		/// <summary>
		/// Provides information about block chain id.
		/// </summary>
		public Guid BlockChainId { get; set; }
		
		/// <summary>
		/// Provides information about miner id.
		/// </summary>
		public Guid MinerId { get; set; }

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
		public Guid BlockAssignedBy { get; set; }
	}
}
