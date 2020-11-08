using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class initMSSql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 4, nullable: true),
                    IconId = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disburses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    BillType = table.Column<Guid>(nullable: false),
                    BillTime = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disburses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revenues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Money = table.Column<decimal>(nullable: false),
                    BillTypeId = table.Column<Guid>(nullable: false),
                    BillTime = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    Day = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revenues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revenues_BillTypes_BillTypeId",
                        column: x => x.BillTypeId,
                        principalTable: "BillTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BillTypes",
                columns: new[] { "Id", "IconId", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("44de7e05-da1f-d17e-7ae7-7999c7f3e004"), "restaurant", "餐饮", new Guid("dfc004e1-24a2-ef56-4d1a-463a4040900f") },
                    { new Guid("e96a2e05-1f4e-ee8d-bc16-e64732910bc2"), "daily-expenses", "日用", new Guid("dfc004e1-24a2-ef56-4d1a-463a4040900f") },
                    { new Guid("c3621be8-a9da-9f9d-81ee-c0b6889a3692"), "traffic", "交通", new Guid("dfc004e1-24a2-ef56-4d1a-463a4040900f") },
                    { new Guid("eca480e0-98b4-c01f-4684-12449d0ea658"), "wages", "工资", new Guid("dfc004e1-24a2-ef56-4d1a-463a4040900f") },
                    { new Guid("825559b5-fd27-4c66-a0e4-34033f7698b6"), "conduct", "理财", new Guid("dfc004e1-24a2-ef56-4d1a-463a4040900f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Revenues_BillTypeId",
                table: "Revenues",
                column: "BillTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disburses");

            migrationBuilder.DropTable(
                name: "Revenues");

            migrationBuilder.DropTable(
                name: "BillTypes");
        }
    }
}
