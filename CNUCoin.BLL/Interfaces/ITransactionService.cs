using CNUCoin.DAL.Common.Dtos;
using CNUCoin.DAL.Common.Entities;

namespace CNUCoin.BLL.Interfaces
{
	/// <summary>
	/// Describe all methods to manipulate with <see cref="Transaction"/>.
	/// </summary>
	public interface ITransactionService
	{
		/// <summary>
		/// Create new transactions.
		/// </summary>
		/// <param name="dto">Dto that holds all needed information for transaction creation.</param>
		/// <returns>Created transaction.</returns>
		Task<Transaction> CreateTransactionAsync(TransactionCreateDto dto);

		/// <summary>
		/// Get all not processed transactions.
		/// </summary>
		/// <returns>List of transactions.</returns>
		Task<List<Transaction>> GetNotProcesedTransactionsAsync();

		/// <summary>
		/// Set transaction relatiom to specific block.
		/// </summary>
		/// <param name="blockId">Block id.</param>
		Task SetBlockAsync(List<Transaction> transactions, Guid blockId);

		/// <summary>
		/// Process trnsactions.
		/// </summary>
		/// <param name="transactions">Trancations to process.</param>
		Task ProcessTransactionsAsync(List<Transaction>? transactions);
	}
}
