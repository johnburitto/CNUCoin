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
			builder.Property(bc => bc.BlockId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(bc => bc.MinerId)
				.IsRequired();

			builder.Property(bc => bc.LastHashDate)
				.IsRequired();

			builder.Property(bc => bc.BlockChainHash)
				.IsRequired();

			builder.Property(bc => bc.Nonce)
				.IsRequired();

			builder.Property(bc => bc.AssignedById)
				.IsRequired();

			builder.HasOne(b => b.Miner)
				.WithMany(m => m.BlocksMained)
				.HasForeignKey(b => b.MinerId)
				.OnDelete(DeleteBehavior.ClientSetNull);
			
			builder.HasOne(b => b.AssignedBy)
				.WithMany(m => m.BlocksAssigned)
				.HasForeignKey(b => b.AssignedById)
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
