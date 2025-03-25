using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNUCoin.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class SchemaFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blocks_Members_AssignedById",
                table: "Blocks");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_AssignedById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_FromId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_ToId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_AssignedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Blocks_AssignedById",
                table: "Blocks");

            migrationBuilder.DropColumn(
                name: "AssignedById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Nonce",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "AssignedById",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "ToId",
                table: "Transactions",
                newName: "SenderId");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Transactions",
                newName: "ReceiverId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ToId",
                table: "Transactions",
                newName: "IX_Transactions_SenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FromId",
                table: "Transactions",
                newName: "IX_Transactions_ReceiverId");

            migrationBuilder.AddColumn<float>(
                name: "Anout",
                table: "Transactions",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<byte[]>(
                name: "ECP",
                table: "Transactions",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_ReceiverId",
                table: "Transactions",
                column: "ReceiverId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_SenderId",
                table: "Transactions",
                column: "SenderId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_ReceiverId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Members_SenderId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Anout",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ECP",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Transactions",
                newName: "ToId");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Transactions",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_SenderId",
                table: "Transactions",
                newName: "IX_Transactions_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_ReceiverId",
                table: "Transactions",
                newName: "IX_Transactions_FromId");

            migrationBuilder.AddColumn<string>(
                name: "AssignedById",
                table: "Transactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nonce",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AssignedById",
                table: "Blocks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_AssignedById",
                table: "Transactions",
                column: "AssignedById");

            migrationBuilder.CreateIndex(
                name: "IX_Blocks_AssignedById",
                table: "Blocks",
                column: "AssignedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Blocks_Members_AssignedById",
                table: "Blocks",
                column: "AssignedById",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_AssignedById",
                table: "Transactions",
                column: "AssignedById",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_FromId",
                table: "Transactions",
                column: "FromId",
                principalTable: "Members",
                principalColumn: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Members_ToId",
                table: "Transactions",
                column: "ToId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
