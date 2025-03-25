using CNUCoin.BLL.Interfaces;
using CNUCoin.BLL.Crypto.Interfaces;

using CNUCoin.DAL.Data;
using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;

namespace CNUCoin.BLL.Implementations
{
	/// <summary>
	/// Realisation of <see cref="ITransactionService"/>.
	/// </summary>
	public class TransactionService : ITransactionService
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

		#endregion

		#region Constructor

		/// <summary>
		/// Inizialise instance of <see cref="TransactionService"/>.
		/// </summary>
		/// <param name="context">App db context.</param>
		/// <param name="memberService">Member service.</param>
		/// <param name="cryptoService">Crypto service.</param>
		public TransactionService(AppDbContext context, ICryptoService cryptoService)
		{
			_context = context;
			_cryptoService = cryptoService;
		}

		#endregion

		#region Implementation of ITransactionService

		/// <inheritdoc/>
		public async Task<Transaction> CreateTransactionAsync(TransactionCreateDto dto)
		{
			var transaction = new Transaction
			{
				SenderId = dto.SenderId,
				ReceiverId = dto.ReceiverId,
				Amount = dto.Amount,
				TransactionDate = DateTime.UtcNow
			};

			transaction.Hash = _cryptoService.Sha256Hash($"{dto.SenderId}{dto.ReceiverId}{dto.Amount}{transaction.TransactionDate}");
			transaction.SenderSignature = _cryptoService.SignData(transaction.Hash, dto.PrivateKey);

			await _context.Transactions.AddAsync(transaction);
			await _context.SaveChangesAsync();

			return transaction;
		}

		/// <inheritdoc/>
		public Task<List<Transaction>> GetNotProcesedTransactionsAsync()
			=> _context.Transactions.Where(t => t.BlockId == null)
				.ToListAsync();
	
		/// <inheritdoc/>
		public async Task SetBlockAsync(List<Transaction> transactions, Guid blockId)
		{
			transactions.ForEach(t => t.BlockId = blockId);

			_context.Transactions.UpdateRange(transactions);
			await _context.SaveChangesAsync();
		}

		/// <inheritdoc/>
		public async Task ProcessTransactionsAsync(List<Transaction>? transactions)
		{
			foreach (var transaction in transactions)
			{
				transaction.Approved = true;
				transaction.Sender!.Wallet!.Amount -= transaction.Amount;
				transaction.Receiver!.Wallet!.Amount += transaction.Amount;

				_context.Wallets.UpdateRange(transaction.Sender.Wallet, transaction.Receiver.Wallet);
			}
			
			_context.Transactions.UpdateRange(transactions);
			await _context.SaveChangesAsync();
		}

		#endregion
	}
}
