
using MazaNetCOreFw.SharedPersistence.DataBase;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations
{
    public class AppTicketConversationConfigurations : BaseEntityConfigurations<AppTicketConversation>
    {
        public override void Configure(EntityTypeBuilder<AppTicketConversation> modelBuilder)
        {
            base.Configure(modelBuilder);

            var tableName = nameof(AppTicketConversation).Substring(3);
            modelBuilder.ToTable(tableName);

            modelBuilder.Property(x => x.Body)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");

            modelBuilder.Property(x => x.Status)
                .IsRequired(false)
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.ParentId)
                .IsRequired(false)
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.TicketId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.UserId)
                .IsRequired()
                .HasColumnType("nvarchar(450)");

            modelBuilder.Property(x => x.UserName)
                .IsRequired()
                .HasColumnType("nvarchar(256)");

            modelBuilder.Property(x => x.SectionId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.SectionCode)
                .IsRequired(false)
                .HasColumnType("nvarchar(10)");

            modelBuilder.Property(x => x.SectionType)
                .IsRequired()
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.SectionName)
                .IsRequired()
                .HasColumnType("nvarchar(100)");

            modelBuilder.HasOne(e => e.ParentTicket)
                .WithMany()
                .HasForeignKey(m => m.ParentId);
        }
        
    }
}
