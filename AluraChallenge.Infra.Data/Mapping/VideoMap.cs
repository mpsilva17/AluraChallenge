using AluraChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AluraChallenge.Infra.Data.Mapping
{
    public class VideoMap : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.ToTable("Videos");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Titulo)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("varchar(255)");

            builder.Property(prop => prop.Descricao)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Descricao")
               .HasColumnType("varchar(255)");

            builder.Property(prop => prop.Url)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("Url")
                .HasColumnType("varchar(30)");
        }
    }
}
