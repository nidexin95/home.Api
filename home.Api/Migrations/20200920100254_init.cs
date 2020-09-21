using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace home.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    OperatorId = table.Column<Guid>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    PassWord = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomeBases",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false),
                    OperatorId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CommunityName = table.Column<string>(maxLength: 100, nullable: false),
                    Room = table.Column<int>(nullable: false),
                    Office = table.Column<int>(nullable: false),
                    Wei = table.Column<int>(nullable: false),
                    Area = table.Column<double>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    TotalFloor = table.Column<int>(nullable: false),
                    Elevator = table.Column<bool>(nullable: false),
                    HouseOrientation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeBases_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeBases_UserId",
                table: "HomeBases",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeBases");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
