// Data/Configurations/MessageConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class MessageConfiguration : IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        builder.ToTable("Messages");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Content).IsRequired();

        builder.HasOne(m => m.Sender)
               .WithMany()
               .HasForeignKey(m => m.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m => m.Conversation)
               .WithMany(c => c.Messages)
               .HasForeignKey(m => m.ConversationId);
    }
}
