namespace CNUCoin.BLL.Common.Entities
{
	/// <summary>
	/// Holds information about member of system.
	/// </summary>
	public class Member
	{
		/// <summary>
		/// Provides information about member Id.
		/// </summary>
		public Guid MemberId { get; set; }
		
		/// <summary>
		/// Provides information about member crypto id.
		/// </summary>
		public string? MemberCryptoId { get; set; }

		/// <summary>
		/// Provides information about member public key.
		/// </summary>
		public string? PublicKey { get; set; }

		/// <summary>
		/// Provides information whether member is miner or not.
		/// </summary>
		public bool IsMiner { get; set; }
	}
}
