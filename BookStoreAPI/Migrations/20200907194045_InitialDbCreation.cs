using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BookStoreAPI.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DOB", "FirstName", "LastName" },
                values: new object[] { 1, new DateTime(1985, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Doe" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "DOB", "FirstName", "LastName" },
                values: new object[] { 2, new DateTime(1975, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allen", "Green" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, 99.879999999999995, "SQL Server 2017" },
                    { 3, 1, 68.150000000000006, "Python For Snakes" },
                    { 4, 1, 59.149999999999999, "Angular Jump Start" },
                    { 2, 2, 78.150000000000006, "NodeJS For Beginners" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
