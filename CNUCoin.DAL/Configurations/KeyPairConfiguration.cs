using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="KeyPair"/>.
	/// </summary>
	public class KeyPairConfiguration : IEntityTypeConfiguration<KeyPair>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<KeyPair> builder)
		{
			builder.Property(kp => kp.KeyPairId)
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(kp => kp.PublicKey)
				.IsRequired();

			builder.Property(kp => kp.PrivateKey)
				.IsRequired();
		}
	}
}
