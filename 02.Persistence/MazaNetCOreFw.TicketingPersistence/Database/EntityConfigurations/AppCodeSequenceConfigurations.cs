
using MazaNetCOreFw.SharedPersistence.DataBase;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations
{
    public class AppCodeSequenceConfigurations : IEntityTypeConfiguration<AppCodeSequence>
    {
        public virtual void Configure(EntityTypeBuilder<AppCodeSequence> modelBuilder)
        {

            modelBuilder.HasKey(x => x.Id)
               .HasName($"PCK_{typeof(AppCodeSequence)}Id")
               .IsClustered();

            modelBuilder.Property(x => x.Id)
                 .ValueGeneratedOnAdd()
                 .HasDefaultValueSql("newId()");

            var tableName = nameof(AppCodeSequence).Substring(3);
            modelBuilder.ToTable(tableName);

            modelBuilder.Property(x => x.Year)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.Prefix)
                .IsRequired()
                .HasColumnType("nvarchar(10)");

            modelBuilder.Property(x => x.Sequence)
                 .IsRequired()
                 .HasColumnType("bigint");

            modelBuilder.Property(x => x.SectionType)
                .IsRequired(false)
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.SectionId)
              .IsRequired(false)
              .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.UserId)
               .IsRequired(false)
               .HasColumnType("nvarchar(450)");


        }
    }
}
