using Microsoft.EntityFrameworkCore.Migrations;

namespace MazaNetCOreFw.TicketingPersistence.Migrations
{
    public partial class Change_ParentId_Column_In_TicketConversation_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketConversation_TicketConversation_ParentTicketId",
                table: "TicketConversation");

            migrationBuilder.RenameColumn(
                name: "ParentTicketId",
                table: "TicketConversation",
                newName: "ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketConversation_ParentTicketId",
                table: "TicketConversation",
                newName: "IX_TicketConversation_ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketConversation_TicketConversation_ParentId",
                table: "TicketConversation",
                column: "ParentId",
                principalTable: "TicketConversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketConversation_TicketConversation_ParentId",
                table: "TicketConversation");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "TicketConversation",
                newName: "ParentTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_TicketConversation_ParentId",
                table: "TicketConversation",
                newName: "IX_TicketConversation_ParentTicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketConversation_TicketConversation_ParentTicketId",
                table: "TicketConversation",
                column: "ParentTicketId",
                principalTable: "TicketConversation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
