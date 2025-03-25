using CNUCoin.BLL.Interfaces;
using CNUCoin.BLL.Crypto.Interfaces;

using CNUCoin.DAL.Data;
using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;

namespace CNUCoin.BLL.Implementations
{
	/// <summary>
	/// Realisation of <see cref="IMemberService"/>.
	/// </summary>
	public class MemberService : IMemberService
	{
		#region Private fields

		/// <summary>
		/// App db context.
		/// </summary>
		private readonly AppDbContext _context;

		/// <summary>
		/// Crypto service.
		/// </summary>
		private readonly ICryptoService _cryptoService;

		/// <summary>
		/// Transaction service.
		/// </summary>
		private readonly ITransactionService _transactionService;

		/// <summary>
		/// Block service.
		/// </summary>
		private readonly IBlockService _blockService;

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="MemberService"/>.
		/// </summary>
		/// <param name="context">App db context.</param>
		/// <param name="cryptoService">Crypto service.</param>
		public MemberService(AppDbContext context, ICryptoService cryptoService, ITransactionService transactionService, IBlockService blockService)
		{
			_context = context;
			_cryptoService = cryptoService;
			_transactionService = transactionService;
			_blockService = blockService;
		}

		#endregion

		#region Implementation of IMemberService

		/// <inheritdoc/>
		public Task<bool> LoginAsync(LoginDto dto)
			=> _context.Members
				.Where(m => m.PublicKey == dto.PublicKey && m.Password == _cryptoService.Sha256Hash(dto.Password))
				.AnyAsync();

		/// <inheritdoc/>
		public async Task<(string, string, string)> RegisterAsync(RegisterDto dto)
		{
			var member = new Member();
			(var publicKey, var privateKey) = _cryptoService.GenerateRsaKeys();

			member.MemberId = _cryptoService.Sha256Hash(publicKey);
			member.PublicKey = publicKey;
			member.Username = dto.Username;
			member.Password = _cryptoService.Sha256Hash(dto.Password);
			member.IsMiner = dto.IsMiner;

			await _context.Members.AddAsync(member);
			await _context.SaveChangesAsync();

			return (member.MemberId, publicKey, privateKey);
		}

		/// <inheritdoc/>
		public Task<Member?> GetByIdAsync(string? id)
			=> _context.Members.Where(m => m.MemberId == id)
				.Include(m => m.Wallet)
				.Include(m => m.TransactionsSent)
				.Include(m => m.TransactionsReceived)
				.Include(m => m.BlocksMained)
				.FirstOrDefaultAsync();

		/// <inheritdoc/>
		public async Task MineAsync(string minerId, string privateKey)
		{
			var transactions = await _transactionService.GetNotProcesedTransactionsAsync();
			var latestBlock = await _blockService.GetLastBlockByDateAsync();
			var transactionHash = _cryptoService.BuildMerkelRoot(transactions);
			var latestBlockHash = latestBlock.BlockHash;
			var newBlockHash = string.Empty;
			var nonce = 0;

			while (!newBlockHash.StartsWith('0'))
			{
				newBlockHash = _cryptoService.Sha256Hash($"{transactionHash}{latestBlockHash}{nonce}");
				nonce++;
			}

			var block = await _blockService.CreateBlockAsync(new()
			{
				BlockHash = newBlockHash,
				Nonce = nonce,
				MinerSignature = _cryptoService.SignData(newBlockHash, privateKey),
				LastHashDate = DateTime.UtcNow,
				PreviousBlockHash = latestBlock.BlockHash,
				MinerId = minerId
			});

			await _transactionService.SetBlockAsync(transactions, block.BlockId);
			await _transactionService.ProcessTransactionsAsync(latestBlock.Transactions);
		}

		#endregion
	}
}
