using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.BLL.Interfaces
{
	/// <summary>
	/// Describe all methods to manipulate with <see cref="Block"/>.
	/// </summary>
	public interface IBlockService
	{
		/// <summary>
		/// Get last created block.
		/// </summary>
		/// <returns>Block.</returns>
		Task<Block> GetLastBlockByDateAsync();

		/// <summary>
		/// Create new block.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for block creation.</param>
		/// <returns>Created block.</returns>
		Task<Block> CreateBlockAsync(BlockCreateDto dto);

		/// <summary>
		/// Get all blocks.
		/// </summary>
		/// <returns>List of blocks./returns>
		Task<List<Block>> GetAllAsync();
	}
}
