﻿// <auto-generated />
using System;
using MazaNetCOreFw.TicketingPersistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MazaNetCOreFw.TicketingPersistence.Migrations
{
    [DbContext(typeof(TicketingDbContext))]
    partial class TicketingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppCodeSequence", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newId()");

                    b.Property<string>("Prefix")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("SectionType")
                        .HasColumnType("smallint");

                    b.Property<long>("Sequence")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("PCK_MazaNetCOreFw.TicketingDomain.Entities.AppCodeSequenceId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("CodeSequence");
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newId()");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<short>("Priority")
                        .HasColumnType("smallint");

                    b.Property<short>("Status")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)");

                    b.Property<Guid>("TopicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("PCK_TicketId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("TopicId");

                    b.HasIndex("Year", "Code")
                        .IsUnique()
                        .HasName("UX_Ticket_Year_Code");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicketConversation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newId()");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SectionCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("SectionType")
                        .HasColumnType("smallint");

                    b.Property<short?>("Status")
                        .HasColumnType("smallint");

                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PCK_TicketConversationId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.HasIndex("ParentId");

                    b.HasIndex("TicketId");

                    b.ToTable("TicketConversation");
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicketRaiser", b =>
                {
                    b.Property<Guid>("TicketId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromSectionCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid>("FromSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FromSectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("FromSectionType")
                        .HasColumnType("smallint");

                    b.Property<string>("FromUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FromUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ToSectionCode")
                        .HasColumnType("nvarchar(10)");

                    b.Property<Guid?>("ToSectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ToSectionName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<short>("ToSectionType")
                        .HasColumnType("smallint");

                    b.Property<string>("ToUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ToUserName")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("TicketId")
                        .HasName("PCK_MazaNetCOreFw.TicketingDomain.Entities.AppTicketRaiserTicketId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("TicketRaiser");
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTopic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newId()");

                    b.Property<bool>("Active")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("Deleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid?>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<short?>("SectionType")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PCK_TopicId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicket", b =>
                {
                    b.HasOne("MazaNetCOreFw.TicketingDomain.Entities.AppTopic", "Topic")
                        .WithMany("Tickets")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicketConversation", b =>
                {
                    b.HasOne("MazaNetCOreFw.TicketingDomain.Entities.AppTicketConversation", "ParentTicket")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("MazaNetCOreFw.TicketingDomain.Entities.AppTicket", "Ticket")
                        .WithMany("TicketConversations")
                        .HasForeignKey("TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MazaNetCOreFw.TicketingDomain.Entities.AppTicketRaiser", b =>
                {
                    b.HasOne("MazaNetCOreFw.TicketingDomain.Entities.AppTicket", "Ticket")
                        .WithOne("TicketRaiser")
                        .HasForeignKey("MazaNetCOreFw.TicketingDomain.Entities.AppTicketRaiser", "TicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
