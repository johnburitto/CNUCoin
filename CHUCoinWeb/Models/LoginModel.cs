namespace CNUCoinWeb.Models
{
	/// <summary>
	/// Login model.
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		/// Member public key file.
		/// </summary>
		public IFormFile? PublicKeyFile { get; set; }

		/// <summary>
		/// Member password.
		/// </summary>
		public string? Password { get; set; }
	}
}
