using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Medical_Information_System_API.Migrations
{
    /// <inheritdoc />
    public partial class RestoreMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Speciality = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "speciality",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_speciality", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "speciality",
                columns: new[] { "Id", "CreateTime", "Name" },
                values: new object[,]
                {
                    { new Guid("028dabe8-a18a-498b-a42d-c8b138626061"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1977), "Офтальмолог" },
                    { new Guid("0f0a9716-b504-4309-8d7c-e56f1f9a17cf"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1958), "Кардиолог" },
                    { new Guid("1a6c20e8-197b-4b02-ac30-6ef234d210bf"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1953), "Анестезиолог-реаниматолог" },
                    { new Guid("2064937c-a9ad-40db-b4ed-144dd37179d1"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1976), "Отоларинголог" },
                    { new Guid("2a31ebd2-13bc-41d1-ab14-35903e88bb52"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1955), "Дерматовенеролог" },
                    { new Guid("2e30f292-0501-44b0-b7ef-d83d2fa9f558"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1981), "Психолог" },
                    { new Guid("4b7c0bda-442a-4c63-8103-2bc877c6620f"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1992), "Хирург" },
                    { new Guid("4c4eccee-8d83-46bf-ac4b-1e1634f50d05"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1956), "Инфекционист" },
                    { new Guid("66c89551-1152-4d65-846b-94d9d0e3842b"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1990), "Уролог" },
                    { new Guid("6a3bb26b-8252-4a36-bd8b-56479917fbcf"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1984), "Стоматолог" },
                    { new Guid("6d4e91da-68be-4eb1-a899-371f0fb367df"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1974), "Онколог" },
                    { new Guid("75fbfb64-0b80-433b-9ec0-94b9c0c38646"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1985), "Терапевт" },
                    { new Guid("7971de8f-f342-4fd1-8a98-4b7718223bfd"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1979), "Психиатр" },
                    { new Guid("7f30a93c-b63f-4a8c-8d5d-f08c7aa5c61d"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1983), "Рентгенолог" },
                    { new Guid("bf451687-00f5-48a7-9fca-6875d91a35b6"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1989), "УЗИ-специалист" },
                    { new Guid("c1ca9963-c0ce-47b9-8e54-0763a67fb052"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1994), "Эндокринолог" },
                    { new Guid("cc56202f-97a2-4187-a8f0-15e72902c724"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1961), "Невролог" },
                    { new Guid("fe784982-782e-4f93-a7cb-96db1ef7cd1b"), new DateTime(2024, 10, 27, 5, 5, 31, 266, DateTimeKind.Utc).AddTicks(1912), "Акушер-гинеколог" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "speciality");

            migrationBuilder.DropTable(
                name: "tokenBlacklist");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
