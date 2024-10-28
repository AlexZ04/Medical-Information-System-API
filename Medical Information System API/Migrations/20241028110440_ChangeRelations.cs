using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "DoctorModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("01fe0004-dab4-422c-99f4-31a8aa1ada95"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7074), "Дерматовенеролог" },
                    { new Guid("037400fe-f6e5-4cd3-a1bf-56d8f5bf3ac2"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7094), "Невролог" },
                    { new Guid("042121f0-d31f-4c67-aeed-fae56a4f5aa5"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7116), "Эндокринолог" },
                    { new Guid("1374ffcd-a93a-4e6c-ad96-b02cf942ad62"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7096), "Онколог" },
                    { new Guid("1bff1b38-9709-4c8a-a22d-c8d1d8d10425"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7112), "Уролог" },
                    { new Guid("28ec18e0-8032-4d3e-867a-d97fbe41a9ea"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7097), "Отоларинголог" },
                    { new Guid("31ed31bf-e93e-48d8-9bff-759c75d2dc47"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7090), "Кардиолог" },
                    { new Guid("393cf46c-6833-4a5f-8dcc-8458a6d84629"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7103), "Психолог" },
                    { new Guid("51c9f493-1558-45c6-ad6a-7ebdd6502dc5"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7107), "Стоматолог" },
                    { new Guid("5809b609-0dbe-4684-96b7-2fc315ddf0f0"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7114), "Хирург" },
                    { new Guid("6f312cca-7b03-4f20-9c81-80616d526478"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7110), "Терапевт" },
                    { new Guid("722182aa-18a6-4592-a7b9-f11349c301f1"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7072), "Анестезиолог-реаниматолог" },
                    { new Guid("7700d6bc-9b50-4707-bbcb-62f168c9c78d"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7028), "Акушер-гинеколог" },
                    { new Guid("8457b68e-4eb5-475c-9d1d-167814542e95"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7099), "Офтальмолог" },
                    { new Guid("91c7cee7-3a25-4ce5-ad91-a2fb2d3584c9"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7104), "Рентгенолог" },
                    { new Guid("ad76ec6b-3321-4913-9dc8-a9748908f63d"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7076), "Инфекционист" },
                    { new Guid("d5c9b6a4-c675-462e-ac83-545571e03c18"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7111), "УЗИ-специалист" },
                    { new Guid("ea34808b-bb2c-4357-93b1-9dde99aee1e7"), new DateTime(2024, 10, 28, 11, 4, 39, 818, DateTimeKind.Utc).AddTicks(7101), "Психиатр" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_inspection_DoctorId",
                table: "inspection",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_inspection_PatientId",
                table: "inspection",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_consultation_SpecialityId",
                table: "consultation",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_AuthorId",
                table: "comment",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_comment_DoctorModel_AuthorId",
                table: "comment",
                column: "AuthorId",
                principalTable: "DoctorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_consultation_speciality_SpecialityId",
                table: "consultation",
                column: "SpecialityId",
                principalTable: "speciality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inspection_DoctorModel_DoctorId",
                table: "inspection",
                column: "DoctorId",
                principalTable: "DoctorModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inspection_patient_PatientId",
                table: "inspection",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comment_DoctorModel_AuthorId",
                table: "comment");

            migrationBuilder.DropForeignKey(
                name: "FK_consultation_speciality_SpecialityId",
                table: "consultation");

            migrationBuilder.DropForeignKey(
                name: "FK_inspection_DoctorModel_DoctorId",
                table: "inspection");

            migrationBuilder.DropForeignKey(
                name: "FK_inspection_patient_PatientId",
                table: "inspection");

            migrationBuilder.DropTable(
                name: "DoctorModel");

            migrationBuilder.DropIndex(
                name: "IX_inspection_DoctorId",
                table: "inspection");

            migrationBuilder.DropIndex(
                name: "IX_inspection_PatientId",
                table: "inspection");

            migrationBuilder.DropIndex(
                name: "IX_consultation_SpecialityId",
                table: "consultation");

            migrationBuilder.DropIndex(
                name: "IX_comment_AuthorId",
                table: "comment");

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("01fe0004-dab4-422c-99f4-31a8aa1ada95"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("037400fe-f6e5-4cd3-a1bf-56d8f5bf3ac2"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("042121f0-d31f-4c67-aeed-fae56a4f5aa5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1374ffcd-a93a-4e6c-ad96-b02cf942ad62"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("1bff1b38-9709-4c8a-a22d-c8d1d8d10425"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("28ec18e0-8032-4d3e-867a-d97fbe41a9ea"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("31ed31bf-e93e-48d8-9bff-759c75d2dc47"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("393cf46c-6833-4a5f-8dcc-8458a6d84629"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("51c9f493-1558-45c6-ad6a-7ebdd6502dc5"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("5809b609-0dbe-4684-96b7-2fc315ddf0f0"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("6f312cca-7b03-4f20-9c81-80616d526478"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("722182aa-18a6-4592-a7b9-f11349c301f1"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("7700d6bc-9b50-4707-bbcb-62f168c9c78d"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("8457b68e-4eb5-475c-9d1d-167814542e95"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("91c7cee7-3a25-4ce5-ad91-a2fb2d3584c9"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ad76ec6b-3321-4913-9dc8-a9748908f63d"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("d5c9b6a4-c675-462e-ac83-545571e03c18"));

            migrationBuilder.DeleteData(
                table: "speciality",
                keyColumn: "Id",
                keyValue: new Guid("ea34808b-bb2c-4357-93b1-9dde99aee1e7"));

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
        }
    }
}
