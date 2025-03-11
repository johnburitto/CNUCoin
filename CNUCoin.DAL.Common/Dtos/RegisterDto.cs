using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.DAL.Common.Dtos
{
	/// <summary>
	/// Holds information needed for register.
	/// </summary>
	public class RegisterDto
	{
		/// <summary>
		/// Provides information about <see cref="Member"/> username to register with.
		/// </summary>
		public string? Username { get; set; }

		/// <summary>
		/// Provides information about <see cref="Member"/> password to register with.
		/// </summary>
		public string? Password { get; set; }

		/// <summary>
		/// Provides information whether <see cref="Member"/> is miner or not.
		/// </summary>
		public bool IsMiner { get; set; }
	}
}
