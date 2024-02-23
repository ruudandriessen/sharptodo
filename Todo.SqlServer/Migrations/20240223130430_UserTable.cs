using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "TodoEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "TodoEntity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoEntity",
                table: "TodoEntity",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoEntity_UserId",
                table: "TodoEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoEntity_UserEntity_UserId",
                table: "TodoEntity",
                column: "UserId",
                principalTable: "UserEntity",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoEntity_UserEntity_UserId",
                table: "TodoEntity");

            migrationBuilder.DropTable(
                name: "UserEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoEntity",
                table: "TodoEntity");

            migrationBuilder.DropIndex(
                name: "IX_TodoEntity_UserId",
                table: "TodoEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TodoEntity");

            migrationBuilder.RenameTable(
                name: "TodoEntity",
                newName: "Todos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
