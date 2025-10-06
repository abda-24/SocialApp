// Data/Configurations/LikeConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LikeConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("Likes");

        builder.HasKey(l => l.Id);

        builder.HasOne(l => l.User)
               .WithMany(u => u.Likes)
               .HasForeignKey(l => l.UserId);

        builder.HasOne(l => l.Post)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PostId);

        builder.HasIndex(l => new { l.UserId, l.PostId }).IsUnique();
    }
}
