// Data/Configurations/CommentConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);

        builder.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId);

        builder.HasOne(c => c.Post)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PostId);
        // Comment ↔ Replies (Self Reference)
        builder.HasOne(c => c.ParentComment)
               .WithMany(c => c.Replies)
               .HasForeignKey(c => c.ParentCommentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
