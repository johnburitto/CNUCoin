using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CNUCoin.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBlock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BlockId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "BlockId",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: null,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
