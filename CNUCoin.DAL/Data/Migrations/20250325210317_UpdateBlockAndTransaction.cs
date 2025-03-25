using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNUCoin.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBlockAndTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ECP",
                table: "Transactions",
                newName: "SenderSignature");

            migrationBuilder.AlterColumn<long>(
                name: "Nonce",
                table: "Blocks",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<byte[]>(
                name: "MinerSignature",
                table: "Blocks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinerSignature",
                table: "Blocks");

            migrationBuilder.RenameColumn(
                name: "SenderSignature",
                table: "Transactions",
                newName: "ECP");

            migrationBuilder.AlterColumn<string>(
                name: "Nonce",
                table: "Blocks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
