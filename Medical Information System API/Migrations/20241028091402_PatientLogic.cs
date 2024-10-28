using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class PatientLogic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("004a642f-5886-4091-9332-37b1562886c7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("08d34521-bc76-4733-acf7-4779fc6c6886"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("0bf67a48-69db-4be8-8148-f1439506ab5c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("15cf3ab8-ea35-4425-9f1d-f9342ede1d01"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1669137b-1b0f-4037-9eda-a62ffd7bd3e7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1d0d7975-142b-4f29-8ddb-fa0cdb7413c5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("3851c555-24a3-437a-88dd-c861cea26463"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("418154c2-e78f-4e33-a44a-f756914880cf"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("427afc69-ee75-48ec-b71f-c42b3eb439ec"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("69439086-0489-483d-84cb-5de2968e38b7"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("70d99873-6637-4ed4-9cd5-cf860503495d"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("7c03fe4b-5a60-40fd-9e37-94be21924a26"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("959d8772-224f-4e71-88a5-e430f7e16aab"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a4051901-5195-474a-8f07-f80b97ed06f6"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("cdd4d4ae-0e3d-429e-993b-466b1102f433"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d3fd25a5-c465-44ed-9447-8820bf142e56"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d4389d75-c62f-49d2-8595-f5de53120b96"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ea82d514-a1d5-4f89-97eb-04b5eeacb557"));

            migrationBuilder.CreateTable(
                name: "inspection",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Anamnesis = table.Column<string>(type: "text", nullable: false),
                    Complaints = table.Column<string>(type: "text", nullable: false),
                    Treatment = table.Column<string>(type: "text", nullable: false),
                    Conclusion = table.Column<int>(type: "integer", nullable: false),
                    NextVisitDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeathDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BaseInspectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PreviousInspectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    PatientId = table.Column<Guid>(type: "uuid", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "consultation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    InspectionId = table.Column<Guid>(type: "uuid", nullable: false),
                    SpecialityId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_consultation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_consultation_inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnose",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    InspectionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diagnose_inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "inspection",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConsultationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_consultation_ConsultationId",
                        column: x => x.ConsultationId,
                        principalTable: "consultation",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("1037bc07-e1d7-48d4-affe-bd232c1d6d1f"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8342), "Акушер-гинеколог" },
                    { new Guid("1d1ec024-2282-4543-9d16-8a76f5ce0970"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8520), "Эндокринолог" },
                    { new Guid("27b6f2b4-9645-4c9b-8853-ab598c005af4"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8421), "Психиатр" },
                    { new Guid("45f60b30-a051-4158-81ae-5ffd7e8d1ef1"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8415), "Онколог" },
                    { new Guid("4b14d8fe-d8aa-42a6-8c8b-a74b7aa37d7c"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8429), "Терапевт" },
                    { new Guid("4c34c43b-be0b-421b-88b5-b83d38195252"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8428), "Стоматолог" },
                    { new Guid("779a4701-c66e-44df-ad56-274b5a4eee53"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8391), "Анестезиолог-реаниматолог" },
                    { new Guid("853e5542-4d38-40f9-ac2f-1b3871ae8141"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8413), "Невролог" },
                    { new Guid("90516672-83f2-433c-97b5-d422ff4be25a"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8406), "Дерматовенеролог" },
                    { new Guid("a4db63c8-85d8-4bca-882c-df501189cfe9"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8431), "УЗИ-специалист" },
                    { new Guid("a5f3be46-1d40-4153-a2fe-03dacd17edea"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8434), "Хирург" },
                    { new Guid("bb95b963-ecc5-4271-8f1c-169e31b346cb"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8410), "Кардиолог" },
                    { new Guid("c36da27f-e268-4112-8e17-c2ecae8a94c5"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8432), "Уролог" },
                    { new Guid("c6cd7076-f38b-47d2-b38f-1fc9e185dfe4"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8408), "Инфекционист" },
                    { new Guid("c712a3e7-03e8-4561-9081-90a85cb1b2cb"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8426), "Рентгенолог" },
                    { new Guid("d22edc09-2e09-48ce-befd-aece3a3738ec"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8418), "Офтальмолог" },
                    { new Guid("ea4291b1-7c4b-4bea-b7a8-bb905dcc4217"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8425), "Психолог" },
                    { new Guid("fbcc7a5e-ba4a-4ca4-b059-d8bfba7e2d18"), new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8417), "Отоларинголог" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_ConsultationId",
                table: "comment",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_consultation_InspectionId",
                table: "consultation",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnose_InspectionId",
                table: "diagnose",
                column: "InspectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "diagnose");

            migrationBuilder.DropTable(
                name: "consultation");

            migrationBuilder.DropTable(
                name: "inspection");

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1037bc07-e1d7-48d4-affe-bd232c1d6d1f"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1d1ec024-2282-4543-9d16-8a76f5ce0970"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("27b6f2b4-9645-4c9b-8853-ab598c005af4"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("45f60b30-a051-4158-81ae-5ffd7e8d1ef1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4b14d8fe-d8aa-42a6-8c8b-a74b7aa37d7c"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("4c34c43b-be0b-421b-88b5-b83d38195252"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("779a4701-c66e-44df-ad56-274b5a4eee53"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("853e5542-4d38-40f9-ac2f-1b3871ae8141"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("90516672-83f2-433c-97b5-d422ff4be25a"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a4db63c8-85d8-4bca-882c-df501189cfe9"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("a5f3be46-1d40-4153-a2fe-03dacd17edea"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("bb95b963-ecc5-4271-8f1c-169e31b346cb"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c36da27f-e268-4112-8e17-c2ecae8a94c5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c6cd7076-f38b-47d2-b38f-1fc9e185dfe4"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("c712a3e7-03e8-4561-9081-90a85cb1b2cb"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d22edc09-2e09-48ce-befd-aece3a3738ec"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ea4291b1-7c4b-4bea-b7a8-bb905dcc4217"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("fbcc7a5e-ba4a-4ca4-b059-d8bfba7e2d18"));

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("004a642f-5886-4091-9332-37b1562886c7"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7634), "Дерматовенеролог" },
                    { new Guid("08d34521-bc76-4733-acf7-4779fc6c6886"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7631), "Анестезиолог-реаниматолог" },
                    { new Guid("0bf67a48-69db-4be8-8148-f1439506ab5c"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7657), "Психиатр" },
                    { new Guid("15cf3ab8-ea35-4425-9f1d-f9342ede1d01"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7646), "Инфекционист" },
                    { new Guid("1669137b-1b0f-4037-9eda-a62ffd7bd3e7"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7667), "УЗИ-специалист" },
                    { new Guid("1d0d7975-142b-4f29-8ddb-fa0cdb7413c5"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7654), "Отоларинголог" },
                    { new Guid("3851c555-24a3-437a-88dd-c861cea26463"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7662), "Рентгенолог" },
                    { new Guid("418154c2-e78f-4e33-a44a-f756914880cf"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7595), "Акушер-гинеколог" },
                    { new Guid("427afc69-ee75-48ec-b71f-c42b3eb439ec"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7659), "Психолог" },
                    { new Guid("69439086-0489-483d-84cb-5de2968e38b7"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7664), "Стоматолог" },
                    { new Guid("70d99873-6637-4ed4-9cd5-cf860503495d"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7670), "Хирург" },
                    { new Guid("7c03fe4b-5a60-40fd-9e37-94be21924a26"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7655), "Офтальмолог" },
                    { new Guid("959d8772-224f-4e71-88a5-e430f7e16aab"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7652), "Онколог" },
                    { new Guid("a4051901-5195-474a-8f07-f80b97ed06f6"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7668), "Уролог" },
                    { new Guid("cdd4d4ae-0e3d-429e-993b-466b1102f433"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7672), "Эндокринолог" },
                    { new Guid("d3fd25a5-c465-44ed-9447-8820bf142e56"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7651), "Невролог" },
                    { new Guid("d4389d75-c62f-49d2-8595-f5de53120b96"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7665), "Терапевт" },
                    { new Guid("ea82d514-a1d5-4f89-97eb-04b5eeacb557"), new DateTime(2024, 10, 27, 5, 47, 10, 296, DateTimeKind.Utc).AddTicks(7648), "Кардиолог" }
                });
        }
    }
}
