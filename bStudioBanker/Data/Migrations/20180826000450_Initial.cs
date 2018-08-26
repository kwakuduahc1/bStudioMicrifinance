using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bStudioBanker.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypesID = table.Column<Guid>(nullable: false),
                    AccountType = table.Column<string>(maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypesID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomersID = table.Column<Guid>(nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: false),
                    OtherNames = table.Column<string>(maxLength: 50, nullable: false),
                    Residence = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 15, nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomersID);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountsID = table.Column<Guid>(nullable: false),
                    AccountNumber = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    AccountTypesID = table.Column<Guid>(nullable: false),
                    CustomersID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountsID);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypesID",
                        column: x => x.AccountTypesID,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypesID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomersID",
                        column: x => x.CustomersID,
                        principalTable: "Customers",
                        principalColumn: "CustomersID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountsTransactions",
                columns: table => new
                {
                    AccountsTransactionsID = table.Column<Guid>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AccountsID = table.Column<Guid>(nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountsTransactions", x => x.AccountsTransactionsID);
                    table.ForeignKey(
                        name: "FK_AccountsTransactions_Accounts_AccountsID",
                        column: x => x.AccountsID,
                        principalTable: "Accounts",
                        principalColumn: "AccountsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypesID",
                table: "Accounts",
                column: "AccountTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomersID",
                table: "Accounts",
                column: "CustomersID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountsTransactions_AccountsID",
                table: "AccountsTransactions",
                column: "AccountsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountsTransactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
