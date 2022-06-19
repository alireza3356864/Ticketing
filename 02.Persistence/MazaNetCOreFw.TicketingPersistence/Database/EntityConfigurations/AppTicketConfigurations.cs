
using MazaNetCOreFw.SharedPersistence.DataBase;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations
{
    public class AppTicketConfigurations : BaseEntityConfigurations<AppTicket>
    {
        public override void Configure(EntityTypeBuilder<AppTicket> modelBuilder)
        {
            base.Configure(modelBuilder);
            var tableName = nameof(AppTicket).Substring(3);
            modelBuilder.ToTable(tableName);

            modelBuilder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar(200)");

            modelBuilder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.TopicId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.Code)
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            modelBuilder.Property(x => x.Year)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.Priority)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.HasIndex(x => new {x.Year, x.Code })
               .HasName($"UX_{tableName}_{nameof(AppTicket.Year)}_{nameof(AppTicket.Code)}")
               .IsUnique();

            modelBuilder.HasOne(x => x.Topic)
                  .WithMany(x => x.Tickets)
                  .HasForeignKey(x => x.TopicId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
