using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="BlockChain"/>.
	/// </summary>
	public class BlockChainConfiguration : IEntityTypeConfiguration<BlockChain>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<BlockChain> builder)
		{
			builder.Property(bc => bc.BlockChainId)
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

			builder.Property(bc => bc.BlockAssignedBy)
				.IsRequired();
		}
	}
}
