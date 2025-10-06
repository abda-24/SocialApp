using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Presistance.Data.Configrations
{
    public class FileUploadConfiguration : IEntityTypeConfiguration<FileUpload>
    {
        public void Configure(EntityTypeBuilder<FileUpload> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FileName).IsRequired().HasMaxLength(255);
            builder.Property(f => f.FileUrl).IsRequired();
            builder.Property(f => f.ContentType).HasMaxLength(100);
        }
    }
}
