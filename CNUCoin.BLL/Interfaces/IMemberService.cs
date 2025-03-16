using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.BLL.Interfaces
{
	/// <summary>
	/// Describe all methods to manipulate with <see cref="Member"/>
	/// </summary>
	public interface IMemberService
	{
		/// <summary>
		/// Register member into system.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for register.</param>
		/// <returns>Returns generated crypto id of created memeber.</returns>
		Task<string> RegisterAsync(RegisterDto dto);

		/// <summary>
		/// Logins user into system.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for login.</param>
		/// <returns>Wheter member logined or not.</returns>
		Task<bool> LoginAsync(LoginDto dto);
	}
}
