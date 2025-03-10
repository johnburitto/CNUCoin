using CNUCoin.DAL.Configurations;
using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;

namespace CNUCoin.DAL.Data
{
	/// <summary>
	/// Application db context.
	/// </summary>
	public class AppDbContext : DbContext
	{
		#region DbSets

		/// <summary>
		/// Repository for entity <see cref="Member"/>.
		/// </summary>
		public DbSet<Member> Members { get; set; }

		/// <summary>
		/// Repository for entity <see cref="KeyPair"/>.
		/// </summary>
		public DbSet<KeyPair> KeyPairs { get; set; }

		/// <summary>
		/// Repository for entity <see cref="Wallet"/>.
		/// </summary>
		public DbSet<Wallet> Wallets { get; set; }

		/// <summary>
		/// Repository for entity <see cref="Transaction"/>.
		/// </summary>
		public DbSet<Transaction> Transactions { get; set; }

		/// <summary>
		/// Repository for entity <see cref="BlockChain"/>.
		/// </summary>
		public DbSet<BlockChain> BlockChains { get; set; }

		#endregion

		#region Constructor
		
		/// <summary>
		/// Constructor for instanceof <see cref="AppDbContext"/>.
		/// </summary>
		/// <param name="options">Db connection options.</param>
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		#endregion

		#region Ovverides

		/// <inheritdoc/>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new MemberConfiguration());
			modelBuilder.ApplyConfiguration(new KeyPairConfiguration());
			modelBuilder.ApplyConfiguration(new WalletConfiguration());
			modelBuilder.ApplyConfiguration(new TransactionConfiguration());
			modelBuilder.ApplyConfiguration(new BlockChainConfiguration());
		}

		#endregion
	}
}
