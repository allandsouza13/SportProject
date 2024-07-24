using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportProject.Migrations
{
    public partial class AddCoachSportRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Sport_SportID",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_User_UserID",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Coach_CoachID",
                table: "Sport");

            migrationBuilder.DropForeignKey(
                name: "FK_Sport_Departments_DepartmentID",
                table: "Sport");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sport",
                table: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_Sport_CoachID",
                table: "Sport");

            migrationBuilder.DropIndex(
                name: "IX_Sport_DepartmentID",
                table: "Sport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.DropColumn(
                name: "CoachID",
                table: "Sport");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Sport");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Sport",
                newName: "Sports");

            migrationBuilder.RenameTable(
                name: "Coach",
                newName: "Coaches");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Coaches",
                newName: "FirstMidName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sports",
                table: "Sports",
                column: "SportID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "CoachSports",
                columns: table => new
                {
                    CoachesID = table.Column<int>(type: "int", nullable: false),
                    SportsSportID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachSports", x => new { x.CoachesID, x.SportsSportID });
                    table.ForeignKey(
                        name: "FK_CoachSports_Coaches_CoachesID",
                        column: x => x.CoachesID,
                        principalTable: "Coaches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoachSports_Sports_SportsSportID",
                        column: x => x.SportsSportID,
                        principalTable: "Sports",
                        principalColumn: "SportID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoachSports_SportsSportID",
                table: "CoachSports",
                column: "SportsSportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Sports_SportID",
                table: "Fixtures",
                column: "SportID",
                principalTable: "Sports",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Users_UserID",
                table: "Fixtures",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Sports_SportID",
                table: "Fixtures");

            migrationBuilder.DropForeignKey(
                name: "FK_Fixtures_Users_UserID",
                table: "Fixtures");

            migrationBuilder.DropTable(
                name: "CoachSports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sports",
                table: "Sports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Sports",
                newName: "Sport");

            migrationBuilder.RenameTable(
                name: "Coaches",
                newName: "Coach");

            migrationBuilder.RenameColumn(
                name: "FirstMidName",
                table: "Coach",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "CoachID",
                table: "Sport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Sport",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sport",
                table: "Sport",
                column: "SportID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdministratorID = table.Column<int>(type: "int", nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Coach_AdministratorID",
                        column: x => x.AdministratorID,
                        principalTable: "Coach",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sport_CoachID",
                table: "Sport",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Sport_DepartmentID",
                table: "Sport",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_AdministratorID",
                table: "Departments",
                column: "AdministratorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_Sport_SportID",
                table: "Fixtures",
                column: "SportID",
                principalTable: "Sport",
                principalColumn: "SportID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fixtures_User_UserID",
                table: "Fixtures",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Coach_CoachID",
                table: "Sport",
                column: "CoachID",
                principalTable: "Coach",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sport_Departments_DepartmentID",
                table: "Sport",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID");
        }
    }
}
