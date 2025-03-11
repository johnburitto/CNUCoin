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

			builder.Property(t => t.FromId)
				.IsRequired();

			builder.Property(t => t.ToId)
				.IsRequired();

			builder.Property(t => t.Hash)
				.IsRequired();

			builder.Property(t => t.Nonce)
				.IsRequired();

			builder.Property(t => t.Approved)
				.IsRequired();

			builder.Property(t => t.AssignedById)
				.IsRequired();

			builder.HasOne(t => t.From)
				.WithMany(m => m.TransactionsFrom)
				.HasForeignKey(t => t.FromId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.HasOne(t => t.To)
				.WithMany(m => m.TransactionsTo)
				.HasForeignKey(t => t.ToId)
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.HasOne(t => t.AssignedBy)
				.WithMany(m => m.TransactionsAssigned)
				.HasForeignKey(t => t.AssignedById)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
