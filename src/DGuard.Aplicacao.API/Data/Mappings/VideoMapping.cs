using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DGuard.Core.DomainObjects;
using DGuard.Aplicacao.API.Models;

namespace DGuard.Aplicacao.API.Data.Mappings
{
    public class VideoMapping : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");


            builder.ToTable("Video");

        }
    }
}
