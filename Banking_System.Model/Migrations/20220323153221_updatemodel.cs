using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Banking_System.Model.Migrations
{
    public partial class updatemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionLog",
                table: "Logs",
                newName: "ActivityBy");

            migrationBuilder.AddColumn<DateTime>(
                name: "ActivityDate",
                table: "Logs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityDate",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "ActivityBy",
                table: "Logs",
                newName: "TransactionLog");
        }
    }
}
