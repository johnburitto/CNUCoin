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

			builder.Property(t => t.From)
				.IsRequired();

			builder.Property(t => t.To)
				.IsRequired();

			builder.Property(t => t.Hash)
				.IsRequired();

			builder.Property(t => t.Nonce)
				.IsRequired();

			builder.Property(t => t.Approved)
				.IsRequired();

			builder.Property(t => t.AssignedBy)
				.IsRequired();
		}
	}
}
