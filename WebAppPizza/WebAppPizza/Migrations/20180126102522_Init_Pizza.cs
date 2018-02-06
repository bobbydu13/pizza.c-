using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebAppPizza.Migrations
{
    public partial class Init_Pizza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Command",
                columns: table => new
                {
                    IDCommand = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommandDate = table.Column<DateTime>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Command", x => x.IDCommand);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    IDPizza = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    PriceHT = table.Column<decimal>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.IDPizza);
                });

            migrationBuilder.CreateTable(
                name: "DetailCommand",
                columns: table => new
                {
                    IDDetailCommand = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IDCommand = table.Column<int>(nullable: false),
                    IDPizza = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCommand", x => x.IDDetailCommand);
                    table.ForeignKey(
                        name: "FK_DetailCommand_Command_IDCommand",
                        column: x => x.IDCommand,
                        principalTable: "Command",
                        principalColumn: "IDCommand",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailCommand_Pizza_IDPizza",
                        column: x => x.IDPizza,
                        principalTable: "Pizza",
                        principalColumn: "IDPizza",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailCommand_IDCommand",
                table: "DetailCommand",
                column: "IDCommand");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCommand_IDPizza",
                table: "DetailCommand",
                column: "IDPizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCommand");

            migrationBuilder.DropTable(
                name: "Command");

            migrationBuilder.DropTable(
                name: "Pizza");
        }
    }
}
