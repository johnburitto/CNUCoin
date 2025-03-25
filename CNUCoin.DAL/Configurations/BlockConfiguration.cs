using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="Block"/>.
	/// </summary>
	public class BlockConfiguration : IEntityTypeConfiguration<Block>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<Block> builder)
		{
			builder.Property(b => b.BlockId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(b => b.MinerId)
				.IsRequired();

			builder.Property(b => b.LastHashDate)
				.IsRequired();

			builder.Property(b => b.BlockHash)
				.IsRequired();

			builder.Property(b => b.PreviousBlockHash)
				.IsRequired();

			builder.Property(b => b.Nonce)
				.IsRequired();

			builder.HasOne(b => b.Miner)
				.WithMany(m => m.BlocksMained)
				.HasForeignKey(b => b.MinerId)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
