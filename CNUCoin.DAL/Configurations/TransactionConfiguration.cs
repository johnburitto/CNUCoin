using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="Transaction"/>.
	/// </summary>
	public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<Transaction> builder)
		{
			builder.Property(t => t.TransactionId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(t => t.TransactionDate)
				.IsRequired();

			builder.Property(t => t.SenderId)
				.IsRequired();

			builder.Property(t => t.ReceiverId)
				.IsRequired();

			builder.Property(t => t.Hash)
				.IsRequired();

			builder.Property(t => t.Approved)
				.IsRequired();

			builder.Property(t => t.Amount)
				.IsRequired();

			builder.Property(t => t.SenderSignature)
				.IsRequired();

			builder.HasOne(t => t.Sender)
				.WithMany(m => m.TransactionsSent)
				.HasForeignKey(t => t.SenderId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.HasOne(t => t.Receiver)
				.WithMany(m => m.TransactionsReceived)
				.HasForeignKey(t => t.ReceiverId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.HasOne(t => t.Block)
				.WithMany(b => b.Transactions)
				.HasForeignKey(t => t.BlockId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
