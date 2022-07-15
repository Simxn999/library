using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitiatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanID);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoan",
                columns: table => new
                {
                    BooksBookID = table.Column<int>(type: "int", nullable: false),
                    LoansLoanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoan", x => new { x.BooksBookID, x.LoansLoanID });
                    table.ForeignKey(
                        name: "FK_BookLoan_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoan_Loans_LoansLoanID",
                        column: x => x.LoansLoanID,
                        principalTable: "Loans",
                        principalColumn: "LoanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookID", "Author", "Genre", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, "Buddy The Cat", "Adventure", 999, "Mice in Heaven" },
                    { 2, "TP-Link", "Romantic", 3, "Archer AX50 User Guide" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Email", "Name", "PhoneNumber", "Surname" },
                values: new object[,]
                {
                    { 1, "simon.johansson@mail.com", "Simon", "123 456 78 91", "Johansson" },
                    { 2, "elon.musk@mail.com", "Elon", "123 456 78 92", "Musk" },
                    { 3, "rebecca.gerdin@mail.com", "Rebecca", "123 456 78 93", "Gerdin" }
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "CustomerID", "DueDate", "InitiatedDate", "IsReturned" },
                values: new object[] { 1, 1, new DateTime(2022, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), true });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "CustomerID", "DueDate", "InitiatedDate", "IsReturned" },
                values: new object[] { 2, 2, new DateTime(2022, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanID", "CustomerID", "DueDate", "InitiatedDate", "IsReturned" },
                values: new object[] { 3, 3, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "BookLoan",
                columns: new[] { "BooksBookID", "LoansLoanID" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "BookLoan",
                columns: new[] { "BooksBookID", "LoansLoanID" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "BookLoan",
                columns: new[] { "BooksBookID", "LoansLoanID" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_LoansLoanID",
                table: "BookLoan",
                column: "LoansLoanID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerID",
                table: "Loans",
                column: "CustomerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookLoan");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
