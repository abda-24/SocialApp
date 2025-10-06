// Data/Configurations/NotificationConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Type).HasConversion<string>();

        builder.HasOne(n => n.Recipient)
               .WithMany(u => u.Notifications)
               .HasForeignKey(n => n.RecipientId);

        builder.HasOne(n => n.TriggeredByUser)
               .WithMany()
               .HasForeignKey(n => n.TriggeredByUserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}
