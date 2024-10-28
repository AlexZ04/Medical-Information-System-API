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
                    table.ForeignKey(
                        name: "FK_inspection_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inspection_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_consultation_speciality_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "speciality",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "diagnose",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    InspectionId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diagnose", x => x.Id);
                    table.ForeignKey(
                        name: "FK_diagnose_icd10_RecordId",
                        column: x => x.RecordId,
                        principalTable: "icd10",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_comment_doctor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorId",
                table: "comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ConsultationId",
                table: "comment",
                column: "ConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_consultation_InspectionId",
                table: "consultation",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_consultation_SpecialityId",
                table: "consultation",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnose_InspectionId",
                table: "diagnose",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_diagnose_RecordId",
                table: "diagnose",
                column: "RecordId");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_DoctorId",
                table: "inspection",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_PatientId",
                table: "inspection",
                column: "PatientId");
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
