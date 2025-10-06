// Data/Configurations/FriendshipConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static Friendship;

public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
{
    public void Configure(EntityTypeBuilder<Friendship> builder)
    {
        builder.ToTable("Friendships");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Status)
               .HasConversion<string>()
               .HasDefaultValue(FriendshipStatus.Pending);

        builder.HasOne(f => f.Requester)
               .WithMany(u => u.SentFriendRequests)
               .HasForeignKey(f => f.RequesterId);

        builder.HasOne(f => f.Receiver)
               .WithMany(u => u.ReceivedFriendRequests)
               .HasForeignKey(f => f.ReceiverId);

        builder.HasIndex(f => new { f.RequesterId, f.ReceiverId }).IsUnique();
    }
}
