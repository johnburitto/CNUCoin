using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.BLL.Interfaces
{
	/// <summary>
	/// Describe all methods to manipukate with <see cref="Member"/>
	/// </summary>
	public interface IMemberService
	{
		/// <summary>
		/// Register member into system.
		/// </summary>
		/// <returns>Returns generated crypto id of created memeber.</returns>
		Task<string> RegisterAsync();

		/// <summary>
		/// Logins user into system.
		/// </summary>
		/// <returns>Wheter member logined or not.</returns>
		Task<bool> LoginAsync();
	}
}
