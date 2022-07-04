using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeCrud.Migrations
{
    public partial class AddedDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentRefId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentRefId",
                table: "Employees",
                column: "DepartmentRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Department_DepartmentRefId",
                table: "Employees",
                column: "DepartmentRefId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Department_DepartmentRefId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepartmentRefId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepartmentRefId",
                table: "Employees");
        }
    }
}
