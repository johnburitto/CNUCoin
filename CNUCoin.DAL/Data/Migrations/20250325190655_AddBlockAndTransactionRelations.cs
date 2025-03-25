using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNUCoin.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockAndTransactionRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Anout",
                table: "Transactions",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "BlockChainHash",
                table: "Blocks",
                newName: "PreviousBlockHash");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ECP",
                table: "Transactions",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BlockId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "BlockHash",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BlockId",
                table: "Transactions",
                column: "BlockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Blocks_BlockId",
                table: "Transactions",
                column: "BlockId",
                principalTable: "Blocks",
                principalColumn: "BlockId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Blocks_BlockId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_BlockId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BlockId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "BlockHash",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Transactions",
                newName: "Anout");

            migrationBuilder.RenameColumn(
                name: "PreviousBlockHash",
                table: "Blocks",
                newName: "BlockChainHash");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ECP",
                table: "Transactions",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
