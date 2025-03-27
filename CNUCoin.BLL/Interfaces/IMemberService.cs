using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.BLL.Interfaces
{
	/// <summary>
	/// Describe all methods to manipulate with <see cref="Member"/>.
	/// </summary>
	public interface IMemberService
	{
		/// <summary>
		/// Register member into system.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for register.</param>
		/// <returns>Returns generated crypto id of created memeber, and his public, private keys.</returns>
		Task<(string, string, string)> RegisterAsync(RegisterDto dto);

		/// <summary>
		/// Logins user into system.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for login.</param>
		/// <returns>Wheter member logined or not.</returns>
		Task<bool> LoginAsync(LoginDto dto);

		/// <summary>
		/// Get all members.
		/// </summary>
		/// <returns>List of members.</returns>
		Task<List<Member>> GetAllAsync(string? memberId = "");

		/// <summary>
		/// Get member by his id.
		/// </summary>
		/// <param name="id">Member id.</param>
		/// <returns>Member.</returns>
		Task<Member?> GetByIdAsync(string? id);

		/// <summary>
		/// Get member by public key.
		/// </summary>
		/// <param name="publicKey">Public key.</param>
		/// <returns>Member.</returns>
		Task<Member?> GetByPublicKeyAsync(string publicKey);

		/// <summary>
		/// Mine blocks.
		/// </summary>
		/// <param name="minerId">Miner id.</param>
		/// <param name="privateKey">Miner private key.</param>
		Task MineAsync(string? minerId, string privateKey);
	}
}
