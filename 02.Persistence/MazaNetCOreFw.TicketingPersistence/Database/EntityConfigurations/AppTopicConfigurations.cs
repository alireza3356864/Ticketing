
using MazaNetCOreFw.SharedPersistence.DataBase;
using MazaNetCOreFw.TicketingDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazaNetCOreFw.DummyPersistence.Database.EntityConfigurations
{
    public class AppTopicConfigurations : BaseEntityConfigurations<AppTopic>
    {
        public override void Configure(EntityTypeBuilder<AppTopic> modelBuilder)
        {
            base.Configure(modelBuilder);

            var tableName = nameof(AppTopic).Substring(3);
            modelBuilder.ToTable(tableName);

            modelBuilder.Property(x => x.Title)
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            modelBuilder.Property(x => x.SectionType)
                .IsRequired(false)
                .HasColumnType("smallint");

            modelBuilder.Property(x => x.SectionId)
                .IsRequired(false)
                .HasColumnType("uniqueidentifier");

            modelBuilder.Property(x => x.SectionName)
                .IsRequired(false)
                .HasColumnType("nvarchar(100)");

            modelBuilder.Property(x => x.UserId)
                .IsRequired(false)
                .HasColumnType("nvarchar(450)");

            modelBuilder.Property(x => x.UserName)
                .IsRequired(false)
                .HasColumnType("nvarchar(256)");


        }
    }
}
