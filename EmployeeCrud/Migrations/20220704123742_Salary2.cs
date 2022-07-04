using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrud.Migrations
{
    public partial class Salary2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Salaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Basic = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Hra = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Da = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "date", nullable: false),
                    EmployeeRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salaries_Employees_EmployeeRefId",
                        column: x => x.EmployeeRefId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salaries_EmployeeRefId",
                table: "Salaries",
                column: "EmployeeRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salaries");
        }
    }
}
