using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MazaNetCOreFw.TicketingPersistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeSequence",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Prefix = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    Sequence = table.Column<long>(type: "bigint", nullable: false),
                    SectionType = table.Column<short>(type: "smallint", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PCK_MazaNetCOreFw.TicketingDomain.Entities.AppCodeSequenceId", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SectionType = table.Column<short>(type: "smallint", nullable: true),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SectionName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PCK_TopicId", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Year = table.Column<short>(type: "smallint", nullable: false),
                    Priority = table.Column<short>(type: "smallint", nullable: false),
                    TopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PCK_TicketId", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Ticket_Topic_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topic",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketConversation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Body = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SectionCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    SectionType = table.Column<short>(type: "smallint", nullable: false),
                    SectionName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentTicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PCK_TicketConversationId", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TicketConversation_TicketConversation_ParentTicketId",
                        column: x => x.ParentTicketId,
                        principalTable: "TicketConversation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketConversation_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketRaiser",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    FromUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromUserName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    FromSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromSectionName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FromSectionCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    FromSectionType = table.Column<short>(type: "smallint", nullable: false),
                    ToSectionType = table.Column<short>(type: "smallint", nullable: false),
                    ToSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToSectionCode = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    ToSectionName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ToUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToUserName = table.Column<string>(type: "nvarchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PCK_MazaNetCOreFw.TicketingDomain.Entities.AppTicketRaiserTicketId", x => x.TicketId)
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_TicketRaiser_Ticket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TopicId",
                table: "Ticket",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "UX_Ticket_Year_Code",
                table: "Ticket",
                columns: new[] { "Year", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketConversation_ParentTicketId",
                table: "TicketConversation",
                column: "ParentTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketConversation_TicketId",
                table: "TicketConversation",
                column: "TicketId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeSequence");

            migrationBuilder.DropTable(
                name: "TicketConversation");

            migrationBuilder.DropTable(
                name: "TicketRaiser");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
