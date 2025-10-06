// Data/Configurations/PostConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Content).HasMaxLength(2000);

        builder.HasOne(p => p.User)
               .WithMany(u => u.Posts)
               .HasForeignKey(p => p.UserId);

        builder.HasMany(p => p.Comments)
               .WithOne(c => c.Post)
               .HasForeignKey(c => c.PostId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(p => p.Likes)
               .WithOne(l => l.Post)
               .HasForeignKey(l => l.PostId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
