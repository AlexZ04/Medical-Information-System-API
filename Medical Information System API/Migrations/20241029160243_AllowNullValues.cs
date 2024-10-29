using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class AllowNullValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PreviousInspectionId",
                table: "inspection",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextVisitDate",
                table: "inspection",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "inspection",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseInspectionId",
                table: "inspection",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PreviousInspectionId",
                table: "inspection",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextVisitDate",
                table: "inspection",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeathDate",
                table: "inspection",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "BaseInspectionId",
                table: "inspection",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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
    }
}
