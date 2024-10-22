using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class AddSpecialitiesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "speciality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speciality", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "speciality");
        }
    }
}
