using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UsersList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentUser",
                columns: table => new
                {
                    DepartmentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    UsersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentUser", x => new { x.DepartmentsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDepartments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("1164ae15-cf81-41a2-8804-b4eff6117ffb"), "Развлечений", null },
                    { new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2"), "Финансовый", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Patronymic", "Salary" },
                values: new object[,]
                {
                    { new Guid("1dd132b1-98cc-4a77-a3fc-6c9a1ba49cb8"), "Григорий", "Григорьев", "Григорьевич", 101m },
                    { new Guid("347069e6-83ad-4463-85b2-467ce4ae8c65"), "Борис", "Борисов", "Борисович", 125.5m },
                    { new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3"), "Дмитрий", "Дмитриев", "Дмитриевич", 200m },
                    { new Guid("9bb18507-6fb0-4890-8e6d-9dcc2510f2f1"), "Антон", "Антонов", "Антонович", 123m },
                    { new Guid("e79e39d9-673d-41c2-912a-2c0c3f6a3f14"), "Владимир", "Владимиров", "Владимирович", 155m }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("414a8ef5-48c1-4179-91cd-56097b6b31f1"), "Закупок", new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2") },
                    { new Guid("47a7bfb3-ef3e-47e2-ab43-c317312b2187"), "Кадров", new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2") },
                    { new Guid("bda8ce7e-1d98-4a65-b9cc-195167404807"), "Логистики", new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2") }
                });

            migrationBuilder.InsertData(
                table: "UserDepartments",
                columns: new[] { "Id", "DepartmentId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0945faf5-35f9-4666-9b62-09bd8a1db537"), new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2"), new Guid("1dd132b1-98cc-4a77-a3fc-6c9a1ba49cb8") },
                    { new Guid("111a0096-4f18-4c8e-b0d9-75407ea3a2ac"), new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2"), new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3") },
                    { new Guid("561cff71-039f-4075-a50a-e339a1943a21"), new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2"), new Guid("9bb18507-6fb0-4890-8e6d-9dcc2510f2f1") },
                    { new Guid("928b1961-1d93-4d60-8730-1d59dbef255f"), new Guid("7e7b2c05-4316-4131-95e3-4bce0ba31bc2"), new Guid("e79e39d9-673d-41c2-912a-2c0c3f6a3f14") },
                    { new Guid("d7a4865c-262b-4e88-81e1-f10e3c868e66"), new Guid("1164ae15-cf81-41a2-8804-b4eff6117ffb"), new Guid("e79e39d9-673d-41c2-912a-2c0c3f6a3f14") },
                    { new Guid("d886528a-0af3-4871-901b-2ea1723c8ef1"), new Guid("1164ae15-cf81-41a2-8804-b4eff6117ffb"), new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3") },
                    { new Guid("2940c7bd-ae4c-4a57-99fb-066afaacf8c6"), new Guid("47a7bfb3-ef3e-47e2-ab43-c317312b2187"), new Guid("347069e6-83ad-4463-85b2-467ce4ae8c65") },
                    { new Guid("3e297885-7b66-4c5f-95a1-756ec94d605a"), new Guid("bda8ce7e-1d98-4a65-b9cc-195167404807"), new Guid("347069e6-83ad-4463-85b2-467ce4ae8c65") },
                    { new Guid("4e8e7d24-8f65-4eec-9320-6bceaa4a2a07"), new Guid("bda8ce7e-1d98-4a65-b9cc-195167404807"), new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3") },
                    { new Guid("518f03e0-e2a7-4017-a260-5319579bc71a"), new Guid("414a8ef5-48c1-4179-91cd-56097b6b31f1"), new Guid("347069e6-83ad-4463-85b2-467ce4ae8c65") },
                    { new Guid("ab25d3a0-75b2-437f-a234-2885e7b3dbb7"), new Guid("47a7bfb3-ef3e-47e2-ab43-c317312b2187"), new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3") },
                    { new Guid("c753c9ce-1664-41ff-bd28-cea88529b736"), new Guid("414a8ef5-48c1-4179-91cd-56097b6b31f1"), new Guid("494acce1-4d96-4da3-88cb-35e96f8aa5d3") },
                    { new Guid("f52d360c-0ae7-41a3-b855-ce17eeda83e7"), new Guid("bda8ce7e-1d98-4a65-b9cc-195167404807"), new Guid("1dd132b1-98cc-4a77-a3fc-6c9a1ba49cb8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_UsersId",
                table: "DepartmentUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_DepartmentId",
                table: "UserDepartments",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDepartments_UserId",
                table: "UserDepartments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "UserDepartments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
