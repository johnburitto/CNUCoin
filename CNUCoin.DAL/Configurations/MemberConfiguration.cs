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
				.ValueGeneratedOnAdd()
				.IsRequired();

			builder.Property(m => m.MemberCryptoId)
				.IsRequired();

			builder.Property(m => m.PublicKey)
				.IsRequired();

			builder.Property(m => m.IsMiner)
				.IsRequired();
		}
	}
}
