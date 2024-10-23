using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class AddPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("112bc411-8a13-477d-a9bc-7e75485bfe7e"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("16d34fb7-4257-426a-9242-960a15615b5d"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1d4bed19-e0a2-4787-94ad-5ed54bc1e895"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1f8762b9-2026-4896-a76e-d40af9d6a01e"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("2b3715d7-397e-45cb-96bf-c50885aaea1a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("48cb3cde-68e7-4932-be29-a4851987f657"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("49482f68-0744-4c07-a615-a73848f698f3"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4f522034-9f61-4bcf-96c5-09092c03b555"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("5589153e-2464-46c9-b72d-d3dfee6d89a3"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("7151e7de-3c91-4932-ac3c-a96b7fedc2d9"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("781480df-a0d6-4925-9e56-bbae97c2e658"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("964fc9b4-d0bd-45ac-8704-759a88f34870"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("aabd51ed-25be-46c2-94ca-f59b428aabc8"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ba1e03e1-3cde-4468-b1f4-2d0f7f51927f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("bb9dfd97-f86e-43af-b588-220766872889"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c879592e-ef60-4de6-b548-3f7ab7bb824c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c992dc76-a0e4-4c3d-a45d-18a4cf97c0c7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e02edf77-fd11-4da8-9f2a-ebb5d0559af7"));

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "patient");

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

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("112bc411-8a13-477d-a9bc-7e75485bfe7e"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4866), "Дерматовенеролог" },
                    { new Guid("16d34fb7-4257-426a-9242-960a15615b5d"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4896), "Стоматолог" },
                    { new Guid("1d4bed19-e0a2-4787-94ad-5ed54bc1e895"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4864), "Анестезиолог-реаниматолог" },
                    { new Guid("1f8762b9-2026-4896-a76e-d40af9d6a01e"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4901), "Уролог" },
                    { new Guid("2b3715d7-397e-45cb-96bf-c50885aaea1a"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4892), "Рентгенолог" },
                    { new Guid("48cb3cde-68e7-4932-be29-a4851987f657"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4890), "Психиатр" },
                    { new Guid("49482f68-0744-4c07-a615-a73848f698f3"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4905), "Эндокринолог" },
                    { new Guid("4f522034-9f61-4bcf-96c5-09092c03b555"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4884), "Онколог" },
                    { new Guid("5589153e-2464-46c9-b72d-d3dfee6d89a3"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4887), "Офтальмолог" },
                    { new Guid("7151e7de-3c91-4932-ac3c-a96b7fedc2d9"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4891), "Психолог" },
                    { new Guid("781480df-a0d6-4925-9e56-bbae97c2e658"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4821), "Акушер-гинеколог" },
                    { new Guid("964fc9b4-d0bd-45ac-8704-759a88f34870"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4902), "Хирург" },
                    { new Guid("aabd51ed-25be-46c2-94ca-f59b428aabc8"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4886), "Отоларинголог" },
                    { new Guid("ba1e03e1-3cde-4468-b1f4-2d0f7f51927f"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4868), "Инфекционист" },
                    { new Guid("bb9dfd97-f86e-43af-b588-220766872889"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4899), "УЗИ-специалист" },
                    { new Guid("c879592e-ef60-4de6-b548-3f7ab7bb824c"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4880), "Кардиолог" },
                    { new Guid("c992dc76-a0e4-4c3d-a45d-18a4cf97c0c7"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4898), "Терапевт" },
                    { new Guid("e02edf77-fd11-4da8-9f2a-ebb5d0559af7"), new DateTime(2024, 10, 22, 17, 22, 18, 724, DateTimeKind.Utc).AddTicks(4883), "Невролог" }
                });
        }
    }
}
