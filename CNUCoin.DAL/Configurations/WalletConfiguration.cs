using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="Wallet"/>.
	/// </summary>
	public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<Wallet> builder)
		{
			builder.Property(w => w.WalletId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(w => w.OwnerId)
				.IsRequired();

			builder.Property(w => w.Amount)
				.IsRequired();
		}
	}
}
