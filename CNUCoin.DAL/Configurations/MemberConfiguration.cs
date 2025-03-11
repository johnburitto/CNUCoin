using CNUCoin.DAL.Common.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNUCoin.DAL.Configurations
{
	/// <summary>
	/// Db configuration for entity <see cref="Member"/>.
	/// </summary>
	public class MemberConfiguration : IEntityTypeConfiguration<Member>
	{
		/// <inheritdoc/>
		public void Configure(EntityTypeBuilder<Member> builder)
		{
			builder.Property(m => m.MemberId)
				.IsRequired();

			builder.Property(m => m.Username)
				.IsRequired();

			builder.Property(m => m.Password)
				.IsRequired();

			builder.Property(m => m.PublicKey)
				.IsRequired();

			builder.Property(m => m.IsMiner)
				.IsRequired();

			builder.HasOne(m => m.Wallet)
				.WithOne(w => w.Owner)
				.HasForeignKey<Wallet>(w => w.OwnerId);
		}
	}
}
