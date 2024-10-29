using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeConsultationRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("20be656d-1851-4ca3-9997-5427d1716de5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("28b63826-920a-4ce1-a3d1-62b74cfbc5e0"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("3aa791df-2654-4b89-a6d0-ddfa6aab2818"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("3fd075cc-a641-4c54-8b11-267cfc0f5dc1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4c0344fa-d522-46dd-862a-9b7ca483497f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4d4d31a2-bea8-4b7d-9240-51392b9440e7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("57f523dc-2b7e-4d43-af72-2da73c3bf6a3"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("737e6efe-3ea9-4c03-8383-f8b7522bcbe3"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("92f59e15-280c-4e18-b5a4-99302acab646"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a3ed7aa5-fbac-44c5-9932-5a78f16e5591"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a763748f-1353-420a-870c-a67819cf3d8a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("b9dcd3db-2246-46d6-8cf9-f11c62e40395"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("bc40d866-07f1-4f23-a65c-61f0bcd2caf0"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c92887a8-f8e0-4263-af48-ed0f32c60b8e"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ca6f65fb-41bf-41bd-8bb4-f181e703d69e"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e2bdb674-85b3-4398-a5c3-a37dcc4b4578"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("e7f588df-51ee-464c-9bbb-3c84f1e228f8"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("eb1f0a5c-b34c-42c7-942a-8b295878929f"));

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("1db1acbc-46f7-4338-b484-a47a6d289ede"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(101), "Терапевт" },
                    { new Guid("1f9e59d5-fca3-4f55-b4f2-7c908688df76"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(19), "Анестезиолог-реаниматолог" },
                    { new Guid("206e5f83-43d7-4e17-9c70-ac8d13db60b8"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(49), "Психиатр" },
                    { new Guid("29e4341b-b742-45f0-8a74-8fefad099adc"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(104), "Уролог" },
                    { new Guid("2bba5a90-5908-437a-a252-8f0c4b401e56"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(43), "Онколог" },
                    { new Guid("376297f5-879c-43e8-8248-b3cea8908515"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(37), "Кардиолог" },
                    { new Guid("40e3f6be-ff7d-4fe8-baf5-c7ec7d6e1e8c"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(97), "Рентгенолог" },
                    { new Guid("43b5d9ab-6cc8-4179-8d40-a581795bc2b0"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(99), "Стоматолог" },
                    { new Guid("65b11a7c-e6c1-4ca3-8b07-8c96ce20ddb4"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(46), "Офтальмолог" },
                    { new Guid("8d2c2e9a-9e3d-41d2-b1d6-6f58cb4c075b"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(44), "Отоларинголог" },
                    { new Guid("8dfd7208-bdf0-4519-88c5-5f8dc1526c02"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(108), "Эндокринолог" },
                    { new Guid("8dffbad6-4af6-41fd-902c-fafd0c6f9624"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(36), "Инфекционист" },
                    { new Guid("9a7683d6-0bb8-4f13-98f0-11bec346831a"), new DateTime(2024, 10, 29, 4, 59, 48, 175, DateTimeKind.Utc).AddTicks(9973), "Акушер-гинеколог" },
                    { new Guid("a611e9bb-6613-4f57-ad22-266cebb6cc38"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(34), "Дерматовенеролог" },
                    { new Guid("c411df26-d7f6-4766-9e99-3c1a3780d3d1"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(53), "Психолог" },
                    { new Guid("d156ba24-8a2a-4f22-8938-2ce02877556d"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(103), "УЗИ-специалист" },
                    { new Guid("df4fe298-074b-4ed4-8083-9838799eba1f"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(106), "Хирург" },
                    { new Guid("f9d58485-a6a1-4385-9111-8c66f55089c9"), new DateTime(2024, 10, 29, 4, 59, 48, 176, DateTimeKind.Utc).AddTicks(41), "Невролог" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1db1acbc-46f7-4338-b484-a47a6d289ede"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1f9e59d5-fca3-4f55-b4f2-7c908688df76"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("206e5f83-43d7-4e17-9c70-ac8d13db60b8"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("29e4341b-b742-45f0-8a74-8fefad099adc"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("2bba5a90-5908-437a-a252-8f0c4b401e56"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("376297f5-879c-43e8-8248-b3cea8908515"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("40e3f6be-ff7d-4fe8-baf5-c7ec7d6e1e8c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("43b5d9ab-6cc8-4179-8d40-a581795bc2b0"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("65b11a7c-e6c1-4ca3-8b07-8c96ce20ddb4"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("8d2c2e9a-9e3d-41d2-b1d6-6f58cb4c075b"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("8dfd7208-bdf0-4519-88c5-5f8dc1526c02"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("8dffbad6-4af6-41fd-902c-fafd0c6f9624"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("9a7683d6-0bb8-4f13-98f0-11bec346831a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a611e9bb-6613-4f57-ad22-266cebb6cc38"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c411df26-d7f6-4766-9e99-3c1a3780d3d1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d156ba24-8a2a-4f22-8938-2ce02877556d"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("df4fe298-074b-4ed4-8083-9838799eba1f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("f9d58485-a6a1-4385-9111-8c66f55089c9"));

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("20be656d-1851-4ca3-9997-5427d1716de5"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9251), "УЗИ-специалист" },
                    { new Guid("28b63826-920a-4ce1-a3d1-62b74cfbc5e0"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9249), "Стоматолог" },
                    { new Guid("3aa791df-2654-4b89-a6d0-ddfa6aab2818"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9174), "Инфекционист" },
                    { new Guid("3fd075cc-a641-4c54-8b11-267cfc0f5dc1"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9172), "Дерматовенеролог" },
                    { new Guid("4c0344fa-d522-46dd-862a-9b7ca483497f"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9240), "Офтальмолог" },
                    { new Guid("4d4d31a2-bea8-4b7d-9240-51392b9440e7"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9244), "Психолог" },
                    { new Guid("57f523dc-2b7e-4d43-af72-2da73c3bf6a3"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9235), "Невролог" },
                    { new Guid("737e6efe-3ea9-4c03-8383-f8b7522bcbe3"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9256), "Эндокринолог" },
                    { new Guid("92f59e15-280c-4e18-b5a4-99302acab646"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9250), "Терапевт" },
                    { new Guid("a3ed7aa5-fbac-44c5-9932-5a78f16e5591"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9254), "Хирург" },
                    { new Guid("a763748f-1353-420a-870c-a67819cf3d8a"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9169), "Анестезиолог-реаниматолог" },
                    { new Guid("b9dcd3db-2246-46d6-8cf9-f11c62e40395"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9253), "Уролог" },
                    { new Guid("bc40d866-07f1-4f23-a65c-61f0bcd2caf0"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9083), "Акушер-гинеколог" },
                    { new Guid("c92887a8-f8e0-4263-af48-ed0f32c60b8e"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9185), "Кардиолог" },
                    { new Guid("ca6f65fb-41bf-41bd-8bb4-f181e703d69e"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9245), "Рентгенолог" },
                    { new Guid("e2bdb674-85b3-4398-a5c3-a37dcc4b4578"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9237), "Онколог" },
                    { new Guid("e7f588df-51ee-464c-9bbb-3c84f1e228f8"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9243), "Психиатр" },
                    { new Guid("eb1f0a5c-b34c-42c7-942a-8b295878929f"), new DateTime(2024, 10, 28, 11, 52, 56, 515, DateTimeKind.Utc).AddTicks(9239), "Отоларинголог" }
                });
        }
    }
}
