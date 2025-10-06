// Data/Configurations/UserConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Username).IsRequired().HasMaxLength(50);
        builder.HasIndex(u => u.Username).IsUnique();

        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.HasIndex(u => u.Email).IsUnique();

       

        builder.Property(u => u.Bio).HasMaxLength(500);

        builder.HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.UserId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Likes)
               .WithOne(l => l.User)
               .HasForeignKey(l => l.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.SentFriendRequests)
               .WithOne(f => f.Requester)
               .HasForeignKey(f => f.RequesterId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.ReceivedFriendRequests)
               .WithOne(f => f.Receiver)
               .HasForeignKey(f => f.ReceiverId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Notifications)
               .WithOne(n => n.Recipient)
               .HasForeignKey(n => n.RecipientId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Conversations)
               .WithMany(c => c.Participants);
    }
}
