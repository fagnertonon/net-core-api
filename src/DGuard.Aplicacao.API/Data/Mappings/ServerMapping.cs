using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DGuard.Core.DomainObjects;
using DGuard.Aplicacao.API.Models;

namespace DGuard.Aplicacao.API.Data.Mappings
{
    public class ServerMapping : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(c => c.IP)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

            builder.Property(c => c.IPPort)
                    .HasColumnType("varchar(200)");

            builder.ToTable("Server");
        }
    }
}