using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.DAL.Common.Dtos
{
	/// <summary>
	/// Holds information needed for login.
	/// </summary>
	public class LoginDto
	{
		/// <summary>
		/// Provides information about <see cref="Member"/> public key.
		/// </summary>
		public string? PublicKey { get; set; }

		/// <summary>
		/// Provides information about <see cref="Member"/> password.
		/// </summary>
		public string? Password { get; set; }
	}
}
