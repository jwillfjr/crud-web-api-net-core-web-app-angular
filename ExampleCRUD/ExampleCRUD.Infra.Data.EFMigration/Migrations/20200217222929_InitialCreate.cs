using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExampleCRUD.Infra.Data.EFMigration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actived = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    CpfCnpj = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 500, nullable: true),
                    AddressStreet = table.Column<string>(nullable: true),
                    AddressNumber = table.Column<string>(nullable: true),
                    AddressCity = table.Column<string>(nullable: true),
                    AddressState = table.Column<string>(nullable: true),
                    AddressZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Actived", "AddressCity", "AddressNumber", "AddressState", "AddressStreet", "AddressZipCode", "BirthDate", "CpfCnpj", "Created", "Email", "Name" },
                values: new object[] { 1L, true, "Santos", "123", "SP", "Rua das Mares", "05589458", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "90252253060", new DateTime(2020, 2, 17, 19, 29, 29, 469, DateTimeKind.Local).AddTicks(2455), "josedasilva@email.com", "Jose da Silva" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Actived", "AddressCity", "AddressNumber", "AddressState", "AddressStreet", "AddressZipCode", "BirthDate", "CpfCnpj", "Created", "Email", "Name" },
                values: new object[] { 2L, true, "Manaus", "123", "AM", "Rua Caiapó", "77788858", new DateTime(1975, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "18453944024", new DateTime(2020, 2, 17, 19, 29, 29, 470, DateTimeKind.Local).AddTicks(816), "mariajoseantunes@emailtest.com", "Maria Jose Antunes" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Actived", "AddressCity", "AddressNumber", "AddressState", "AddressStreet", "AddressZipCode", "BirthDate", "CpfCnpj", "Created", "Email", "Name" },
                values: new object[] { 3L, true, "São Paulo", "85", "SP", "Av. Paulista", "99999558", new DateTime(1987, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "58757311099", new DateTime(2020, 2, 17, 19, 29, 29, 470, DateTimeKind.Local).AddTicks(868), "mohamedli@testemail.com", "Mohamed Li" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
