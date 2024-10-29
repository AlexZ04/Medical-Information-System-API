using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class TransferSpecialitiesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("0cddff4e-d232-4e0f-a048-454363d0ac27"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("12c4c50a-1b18-40a0-b5bf-95ce0a54103b"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("131e3beb-d2cf-4983-aef8-2217f395c93f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("33b7632e-7724-48d0-ad50-b1706dd6c0f6"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("363d2b45-b8e6-47c8-92ee-f2ce676a1db9"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("77265701-7b7d-4079-b172-d906b30e5b95"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("7d791f3a-823f-468b-b464-358ae7a94479"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("98244469-76b4-4dfc-814a-8c98b2132c09"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("9e48573c-3521-4f75-a253-79aea256219e"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a6b6fe44-2039-4c59-ac58-9a3eec46b2cd"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("afad5e66-efb7-400d-8743-36cfdd632a17"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("b71ba320-6cb3-4c92-8a68-e03be4e45179"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("cbc16b40-2868-452b-b049-101bd6ba8733"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("cf20a490-66bb-44cd-ac13-3dbf08b1ef25"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d370a9ec-9e11-4484-bc5c-a2ac7d188738"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e1b54780-8d13-4c0f-945e-c6a5dbeaef91"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ec65aa8f-a50c-4ec7-9a06-d69e351ed324"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f60ddf89-5ebc-4d01-99e6-5929dd9a7247"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("0cddff4e-d232-4e0f-a048-454363d0ac27"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(72), "Хирург" },
                    { new Guid("12c4c50a-1b18-40a0-b5bf-95ce0a54103b"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(36), "Дерматовенеролог" },
                    { new Guid("131e3beb-d2cf-4983-aef8-2217f395c93f"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(37), "Инфекционист" },
                    { new Guid("33b7632e-7724-48d0-ad50-b1706dd6c0f6"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(70), "УЗИ-специалист" },
                    { new Guid("363d2b45-b8e6-47c8-92ee-f2ce676a1db9"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(64), "Рентгенолог" },
                    { new Guid("77265701-7b7d-4079-b172-d906b30e5b95"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(68), "Терапевт" },
                    { new Guid("7d791f3a-823f-468b-b464-358ae7a94479"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(67), "Стоматолог" },
                    { new Guid("98244469-76b4-4dfc-814a-8c98b2132c09"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(61), "Психиатр" },
                    { new Guid("9e48573c-3521-4f75-a253-79aea256219e"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(50), "Кардиолог" },
                    { new Guid("a6b6fe44-2039-4c59-ac58-9a3eec46b2cd"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(56), "Онколог" },
                    { new Guid("afad5e66-efb7-400d-8743-36cfdd632a17"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(57), "Отоларинголог" },
                    { new Guid("b71ba320-6cb3-4c92-8a68-e03be4e45179"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(74), "Эндокринолог" },
                    { new Guid("cbc16b40-2868-452b-b049-101bd6ba8733"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(34), "Анестезиолог-реаниматолог" },
                    { new Guid("cf20a490-66bb-44cd-ac13-3dbf08b1ef25"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(59), "Офтальмолог" },
                    { new Guid("d370a9ec-9e11-4484-bc5c-a2ac7d188738"), new DateTime(2024, 10, 29, 16, 2, 43, 215, DateTimeKind.Utc).AddTicks(9995), "Акушер-гинеколог" },
                    { new Guid("e1b54780-8d13-4c0f-945e-c6a5dbeaef91"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(54), "Невролог" },
                    { new Guid("ec65aa8f-a50c-4ec7-9a06-d69e351ed324"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(71), "Уролог" },
                    { new Guid("f60ddf89-5ebc-4d01-99e6-5929dd9a7247"), new DateTime(2024, 10, 29, 16, 2, 43, 216, DateTimeKind.Utc).AddTicks(62), "Психолог" }
                });
        }
    }
}
