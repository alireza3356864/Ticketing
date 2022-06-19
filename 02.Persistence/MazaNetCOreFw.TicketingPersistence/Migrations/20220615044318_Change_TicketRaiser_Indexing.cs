using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MazaNetCOreFw.TicketingPersistence.Migrations
{
    public partial class Change_TicketRaiser_Indexing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TicketId",
                table: "TicketRaiser",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "newId()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "TicketId",
                table: "TicketRaiser",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "newId()",
                oldClrType: typeof(Guid));
        }
    }
}
