using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EksiSozluk.API.Persistence.EntityFramework.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailConfirmations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldEmail = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    NewEmail = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailConfirmations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailConfirmations");
        }
    }
}
