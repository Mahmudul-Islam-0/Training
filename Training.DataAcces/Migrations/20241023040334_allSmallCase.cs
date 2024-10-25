using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class allSmallCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "employees");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "departments");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "employees",
                newName: "updatedby");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "employees",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "employees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "employees",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "DeptId",
                table: "employees",
                newName: "deptid");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "employees",
                newName: "departmentid");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "employees",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "employees",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "employees",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "employees",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "employees",
                newName: "ix_employees_departmentid");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "departments",
                newName: "updatedby");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "departments",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "departments",
                newName: "isdeleted");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "departments",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "departments",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_employees",
                table: "employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_departments",
                table: "departments",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_departments_departmentid",
                table: "employees",
                column: "departmentid",
                principalTable: "departments",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employees_departments_departmentid",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_employees",
                table: "employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_departments",
                table: "departments");

            migrationBuilder.RenameTable(
                name: "employees",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Departments");

            migrationBuilder.RenameColumn(
                name: "updatedby",
                table: "Employees",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "Employees",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "Employees",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deptid",
                table: "Employees",
                newName: "DeptId");

            migrationBuilder.RenameColumn(
                name: "departmentid",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Employees",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Employees",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Employees",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Employees",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_employees_departmentid",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "updatedby",
                table: "Departments",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Departments",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "isdeleted",
                table: "Departments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Departments",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Departments",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
