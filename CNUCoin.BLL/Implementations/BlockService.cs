using CNUCoin.BLL.Interfaces;

using CNUCoin.DAL.Data;
using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using CNUCoin.DAL.Common.Dtos;

namespace CNUCoin.BLL.Implementations
{
	public class BlockService : IBlockService
	{
		#region Private fields

		/// <summary>
		/// App db context.
		/// </summary>
		private readonly AppDbContext _context;

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="BlockService"/>.
		/// </summary>
		/// <param name="context">App db context.</param>
		public BlockService(AppDbContext context)
		{
			_context = context;
		}

		#endregion

		#region Implementation of IBlockService

		/// <inheritdoc/>
		public async Task<Block> GetLastBlockByDateAsync()
		{
			var block = await _context.Blocks.OrderByDescending(b => b.LastHashDate)
				.Include(b => b.Transactions)
				.FirstOrDefaultAsync();

			return block ?? new()
			{
				BlockHash = "0",
				Nonce = 0
			};
		}

		/// <inheritdoc/>
		public async Task<Block> CreateBlockAsync(BlockCreateDto dto)
		{
			var block = new Block
			{
				MinerId = dto.MinerId,
				MinerSignature = dto.MinerSignature,
				LastHashDate = dto.LastHashDate,
				BlockHash = dto.BlockHash,
				PreviousBlockHash = dto.PreviousBlockHash,
				Nonce = dto.Nonce
			};

			await _context.Blocks.AddAsync(block);
			await _context.SaveChangesAsync();

			return block;
		}

		#endregion
	}
}
