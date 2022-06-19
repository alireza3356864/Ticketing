
using MazaNetCOreFw.SharedPersistence.DataBase;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations
{
    public class AppTicketRaiserConfigurations : IEntityTypeConfiguration<AppTicketRaiser>
    {
        public virtual void Configure(EntityTypeBuilder<AppTicketRaiser> modelBuilder)
        {
            modelBuilder.HasKey(x => x.TicketId)
              .HasName($"PCK_{typeof(AppTicketRaiser)}TicketId")
              .IsClustered();

            var tableName = nameof(AppTicketRaiser).Substring(3);
            modelBuilder.ToTable(tableName);

            modelBuilder.Property(x => x.FromUserId)
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            modelBuilder.Property(x => x.FromUserName)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            modelBuilder.Property(x => x.FromSectionId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.FromSectionName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            modelBuilder.Property(x => x.FromSectionCode)
                .IsRequired(false)
                .HasColumnType("nvarchar(10)");

            modelBuilder.Property(x => x.FromSectionType)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.ToSectionType)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.ToSectionId)
                .IsRequired(false)
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.ToSectionCode)
                .IsRequired(false)
                .HasColumnType("nvarchar(10)");

            modelBuilder.Property(x => x.ToSectionName)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Property(x => x.ToUserId)
                .IsRequired(false)
                .HasColumnType("nvarchar(450)");

            modelBuilder.Property(x => x.ToUserName)
                .IsRequired(false)
                .HasColumnType("nvarchar(256)");

        }
    }
}
