using System;
using Mai.SalaryComputation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mai.SalaryComputation.Infrastructure.DataAccess.Configurations
{
    public class ProcessedFileConfiguration : IEntityTypeConfiguration<ProcessedFile>
    {
        public void Configure(EntityTypeBuilder<ProcessedFile> builder)
        {
            builder.ToTable("processed_files");

            builder.HasIndex(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id")
                .HasConversion(g => g.ToString(), s => new Guid(s))
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(x => x.Sha512Hash)
                .HasColumnName("hash")
                .IsRequired();

            builder.Property(x => x.Payload)
                .HasColumnName("payload")
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
        }
    }
}