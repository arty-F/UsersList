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

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("8979d9eb-3e97-4470-bbfe-78fca77b414b"), "Развлечений", null },
                    { new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20"), "Финансовый", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Patronymic", "Salary" },
                values: new object[,]
                {
                    { new Guid("17a90727-cae1-44fd-94a3-0c38fbe3b539"), "Антон", "Антонов", "Антонович", 123m },
                    { new Guid("7804a181-1025-482a-aec8-88f35c4bb058"), "Дмитрий", "Дмитриев", "Дмитриевич", 200m },
                    { new Guid("7ceeb499-4c14-419b-a331-b1437c062469"), "Борис", "Борисов", "Борисович", 125.5m },
                    { new Guid("9cde75ae-35e4-4c69-8580-996e47d55306"), "Владимир", "Владимиров", "Владимирович", 155m },
                    { new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb"), "Григорий", "Григорьев", "Григорьевич", 101m }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("55ad76ec-c8cd-4df1-acae-ebe2f20771e8"), "Кадров", new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20") },
                    { new Guid("7830d605-8bfc-45ca-a736-cdcbb26c6d5a"), "Логистики", new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20") },
                    { new Guid("c1dd00d2-428e-430f-9fcf-8b96fd2512b5"), "Закупок", new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20") }
                });

            migrationBuilder.InsertData(
                table: "DepartmentUser",
                columns: new[] { "DepartmentsId", "UsersId" },
                values: new object[,]
                {
                    { new Guid("55ad76ec-c8cd-4df1-acae-ebe2f20771e8"), new Guid("17a90727-cae1-44fd-94a3-0c38fbe3b539") },
                    { new Guid("8979d9eb-3e97-4470-bbfe-78fca77b414b"), new Guid("17a90727-cae1-44fd-94a3-0c38fbe3b539") },
                    { new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20"), new Guid("7804a181-1025-482a-aec8-88f35c4bb058") },
                    { new Guid("7830d605-8bfc-45ca-a736-cdcbb26c6d5a"), new Guid("7804a181-1025-482a-aec8-88f35c4bb058") },
                    { new Guid("55ad76ec-c8cd-4df1-acae-ebe2f20771e8"), new Guid("7ceeb499-4c14-419b-a331-b1437c062469") },
                    { new Guid("7830d605-8bfc-45ca-a736-cdcbb26c6d5a"), new Guid("7ceeb499-4c14-419b-a331-b1437c062469") },
                    { new Guid("c1dd00d2-428e-430f-9fcf-8b96fd2512b5"), new Guid("7ceeb499-4c14-419b-a331-b1437c062469") },
                    { new Guid("8979d9eb-3e97-4470-bbfe-78fca77b414b"), new Guid("9cde75ae-35e4-4c69-8580-996e47d55306") },
                    { new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20"), new Guid("9cde75ae-35e4-4c69-8580-996e47d55306") },
                    { new Guid("8979d9eb-3e97-4470-bbfe-78fca77b414b"), new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb") },
                    { new Guid("b9f56b45-3a0d-4b86-af63-234ba4d37c20"), new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb") },
                    { new Guid("55ad76ec-c8cd-4df1-acae-ebe2f20771e8"), new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb") },
                    { new Guid("7830d605-8bfc-45ca-a736-cdcbb26c6d5a"), new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb") },
                    { new Guid("c1dd00d2-428e-430f-9fcf-8b96fd2512b5"), new Guid("9f262dfa-10d4-401d-be94-32b4fb1f1bfb") },
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentUser_UsersId",
                table: "DepartmentUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentUser");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
