// Data/Configurations/ConversationConfiguration.cs

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
{
    public void Configure(EntityTypeBuilder<Conversation> builder)
    {
        builder.ToTable("Conversations");

        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Participants)
               .WithMany(u => u.Conversations)
               .UsingEntity(j => j.ToTable("ConversationParticipants"));

        builder.HasMany(c => c.Messages)
               .WithOne(m => m.Conversation)
               .HasForeignKey(m => m.ConversationId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
