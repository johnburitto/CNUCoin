namespace CNUCoin.DAL.Common.Dtos
{
	/// <summary>
	/// Holds all needed information for creation block.
	/// </summary>
	public class BlockCreateDto
	{
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
		public long Nonce { get; set; }

		/// <summary>
		/// Provides information about miner signature.
		/// </summary>
		public byte[]? MinerSignature { get; set; }
	}
}
