using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenBlacklist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("03bd5edd-66d6-49ec-b851-bacbc445c9f4"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("0b444015-f3b3-4c04-a10e-fef54154de8f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("3863a611-b45c-4493-9206-32a002fa9617"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("3de5c622-9283-4a8e-8868-532e9b6983ef"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("515a0c43-ab5d-4685-a17d-1b0f18c25ff5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("5292064f-1652-4be1-8013-b16f05a8c454"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("682b4402-08eb-4bc5-a94c-098f7d85e28a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("739804ee-5de2-4a27-a7a8-2fd4cbb4fde1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("78c646e4-2215-432d-8d14-4f5cfb137128"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("8ae5678d-2303-493b-a9ad-b8660b2528ad"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a0e01547-ccf1-4123-9790-7cae94aa9836"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a6afb196-9199-4ea7-b169-6d6f33302de4"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a8c33ed4-11a2-4218-ba27-ff4f8e9860ef"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ac7d4b47-3276-4194-8932-fc7acb104b64"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ae3d8ff6-4048-4c00-b105-50cfe8b33c35"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f0dbb230-78ef-4c8c-9a5f-c294f5ec7a24"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f186b581-5785-4e41-a50a-1bc033ac595c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f6c72ec8-e13a-4171-b4cc-e83c50a418a6"));

            migrationBuilder.CreateTable(
                name: "tokenBlacklist",
                columns: table => new
                {
                    Token = table.Column<string>(type: "text", nullable: false),
                    AddTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokenBlacklist", x => x.Token);
                });

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0259df4b-ef7d-4c90-a0ff-03fa97d926ff"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7549), "Дерматовенеролог" },
                    { new Guid("09980b3f-fab4-4c72-b6ec-a2ee9afe022b"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7551), "Инфекционист" },
                    { new Guid("37d7ecf6-830f-423d-9dec-7414ab4f2990"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7586), "Терапевт" },
                    { new Guid("4b246a18-d589-47d7-942a-61dd9d707f01"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7564), "Кардиолог" },
                    { new Guid("69e0f635-53ec-4f89-9644-3bbb8b618c0f"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7578), "Психиатр" },
                    { new Guid("85e1a8fe-0104-41f1-a7ce-4ac0d1afacd0"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7575), "Офтальмолог" },
                    { new Guid("894189fe-a1f8-4408-9a3e-26583a5fec47"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7595), "Эндокринолог" },
                    { new Guid("908f4195-1945-4f83-b41a-ef71fe01a6c7"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7580), "Психолог" },
                    { new Guid("9885500b-f8bb-4377-bc56-bc001f68c199"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7592), "Хирург" },
                    { new Guid("a41507c3-cb56-4cfb-ad1c-ded232427b8a"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7494), "Акушер-гинеколог" },
                    { new Guid("ae9473c5-064c-49e1-8043-168cfd56d8de"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7573), "Отоларинголог" },
                    { new Guid("bbfe4587-af8d-4506-a35a-9361db96f302"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7588), "УЗИ-специалист" },
                    { new Guid("c4f6f6b3-af07-4db6-91f3-8868983a97a1"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7571), "Онколог" },
                    { new Guid("caab77ce-0c19-48e7-8b8e-ab64ec00c8a1"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7590), "Уролог" },
                    { new Guid("db399213-0df1-4882-9257-df914a327888"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7546), "Анестезиолог-реаниматолог" },
                    { new Guid("e33da5c5-e45d-4ca7-a925-765427cb8f9c"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7585), "Стоматолог" },
                    { new Guid("e515fcad-e900-4804-ae91-8959eb8b02b6"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7569), "Невролог" },
                    { new Guid("f5a5d7ec-4797-4102-8003-3fe31f1bc882"), new DateTime(2024, 10, 26, 7, 30, 5, 456, DateTimeKind.Utc).AddTicks(7581), "Рентгенолог" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tokenBlacklist");

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("0259df4b-ef7d-4c90-a0ff-03fa97d926ff"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("09980b3f-fab4-4c72-b6ec-a2ee9afe022b"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("37d7ecf6-830f-423d-9dec-7414ab4f2990"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4b246a18-d589-47d7-942a-61dd9d707f01"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("69e0f635-53ec-4f89-9644-3bbb8b618c0f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("85e1a8fe-0104-41f1-a7ce-4ac0d1afacd0"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("894189fe-a1f8-4408-9a3e-26583a5fec47"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("908f4195-1945-4f83-b41a-ef71fe01a6c7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("9885500b-f8bb-4377-bc56-bc001f68c199"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a41507c3-cb56-4cfb-ad1c-ded232427b8a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ae9473c5-064c-49e1-8043-168cfd56d8de"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("bbfe4587-af8d-4506-a35a-9361db96f302"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c4f6f6b3-af07-4db6-91f3-8868983a97a1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("caab77ce-0c19-48e7-8b8e-ab64ec00c8a1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("db399213-0df1-4882-9257-df914a327888"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e33da5c5-e45d-4ca7-a925-765427cb8f9c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e515fcad-e900-4804-ae91-8959eb8b02b6"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f5a5d7ec-4797-4102-8003-3fe31f1bc882"));

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("03bd5edd-66d6-49ec-b851-bacbc445c9f4"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1428), "Рентгенолог" },
                    { new Guid("0b444015-f3b3-4c04-a10e-fef54154de8f"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1406), "Анестезиолог-реаниматолог" },
                    { new Guid("3863a611-b45c-4493-9206-32a002fa9617"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1412), "Кардиолог" },
                    { new Guid("3de5c622-9283-4a8e-8868-532e9b6983ef"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1426), "Психолог" },
                    { new Guid("515a0c43-ab5d-4685-a17d-1b0f18c25ff5"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1351), "Акушер-гинеколог" },
                    { new Guid("5292064f-1652-4be1-8013-b16f05a8c454"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1440), "Эндокринолог" },
                    { new Guid("682b4402-08eb-4bc5-a94c-098f7d85e28a"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1431), "Терапевт" },
                    { new Guid("739804ee-5de2-4a27-a7a8-2fd4cbb4fde1"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1415), "Невролог" },
                    { new Guid("78c646e4-2215-432d-8d14-4f5cfb137128"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1409), "Дерматовенеролог" },
                    { new Guid("8ae5678d-2303-493b-a9ad-b8660b2528ad"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1418), "Отоларинголог" },
                    { new Guid("a0e01547-ccf1-4123-9790-7cae94aa9836"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1420), "Офтальмолог" },
                    { new Guid("a6afb196-9199-4ea7-b169-6d6f33302de4"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1432), "УЗИ-специалист" },
                    { new Guid("a8c33ed4-11a2-4218-ba27-ff4f8e9860ef"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1411), "Инфекционист" },
                    { new Guid("ac7d4b47-3276-4194-8932-fc7acb104b64"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1434), "Уролог" },
                    { new Guid("ae3d8ff6-4048-4c00-b105-50cfe8b33c35"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1417), "Онколог" },
                    { new Guid("f0dbb230-78ef-4c8c-9a5f-c294f5ec7a24"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1435), "Хирург" },
                    { new Guid("f186b581-5785-4e41-a50a-1bc033ac595c"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1425), "Психиатр" },
                    { new Guid("f6c72ec8-e13a-4171-b4cc-e83c50a418a6"), new DateTime(2024, 10, 23, 3, 38, 22, 590, DateTimeKind.Utc).AddTicks(1429), "Стоматолог" }
                });
        }
    }
}
