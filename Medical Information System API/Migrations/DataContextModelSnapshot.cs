﻿// <auto-generated />
using System;
using Medical_Information_System_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Medical_Information_System_API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Medical_Information_System_API.Classes.BlacklistToken", b =>
                {
                    b.Property<string>("Token")
                        .HasColumnType("text");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Token");

                    b.ToTable("tokenBlacklist", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ConsultationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ConsultationId");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Consultation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("InspectionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SpecialityId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("InspectionId");

                    b.ToTable("consultation", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.DoctorDatabase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Speciality")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("doctor", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Icd10Record", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("icd10", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Inspection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Anamnesis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("BaseInspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Complaints")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Conclusion")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeathDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("NextVisitDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PreviousInspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("inspection", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Models.DiagnosisModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("InspectionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InspectionId");

                    b.ToTable("diagnose", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Models.PatientModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("patient", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Models.SpecialityModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("speciality", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("1037bc07-e1d7-48d4-affe-bd232c1d6d1f"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8342),
                            Name = "Акушер-гинеколог"
                        },
                        new
                        {
                            Id = new Guid("779a4701-c66e-44df-ad56-274b5a4eee53"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8391),
                            Name = "Анестезиолог-реаниматолог"
                        },
                        new
                        {
                            Id = new Guid("90516672-83f2-433c-97b5-d422ff4be25a"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8406),
                            Name = "Дерматовенеролог"
                        },
                        new
                        {
                            Id = new Guid("c6cd7076-f38b-47d2-b38f-1fc9e185dfe4"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8408),
                            Name = "Инфекционист"
                        },
                        new
                        {
                            Id = new Guid("bb95b963-ecc5-4271-8f1c-169e31b346cb"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8410),
                            Name = "Кардиолог"
                        },
                        new
                        {
                            Id = new Guid("853e5542-4d38-40f9-ac2f-1b3871ae8141"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8413),
                            Name = "Невролог"
                        },
                        new
                        {
                            Id = new Guid("45f60b30-a051-4158-81ae-5ffd7e8d1ef1"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8415),
                            Name = "Онколог"
                        },
                        new
                        {
                            Id = new Guid("fbcc7a5e-ba4a-4ca4-b059-d8bfba7e2d18"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8417),
                            Name = "Отоларинголог"
                        },
                        new
                        {
                            Id = new Guid("d22edc09-2e09-48ce-befd-aece3a3738ec"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8418),
                            Name = "Офтальмолог"
                        },
                        new
                        {
                            Id = new Guid("27b6f2b4-9645-4c9b-8853-ab598c005af4"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8421),
                            Name = "Психиатр"
                        },
                        new
                        {
                            Id = new Guid("ea4291b1-7c4b-4bea-b7a8-bb905dcc4217"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8425),
                            Name = "Психолог"
                        },
                        new
                        {
                            Id = new Guid("c712a3e7-03e8-4561-9081-90a85cb1b2cb"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8426),
                            Name = "Рентгенолог"
                        },
                        new
                        {
                            Id = new Guid("4c34c43b-be0b-421b-88b5-b83d38195252"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8428),
                            Name = "Стоматолог"
                        },
                        new
                        {
                            Id = new Guid("4b14d8fe-d8aa-42a6-8c8b-a74b7aa37d7c"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8429),
                            Name = "Терапевт"
                        },
                        new
                        {
                            Id = new Guid("a4db63c8-85d8-4bca-882c-df501189cfe9"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8431),
                            Name = "УЗИ-специалист"
                        },
                        new
                        {
                            Id = new Guid("c36da27f-e268-4112-8e17-c2ecae8a94c5"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8432),
                            Name = "Уролог"
                        },
                        new
                        {
                            Id = new Guid("a5f3be46-1d40-4153-a2fe-03dacd17edea"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8434),
                            Name = "Хирург"
                        },
                        new
                        {
                            Id = new Guid("1d1ec024-2282-4543-9d16-8a76f5ce0970"),
                            CreateTime = new DateTime(2024, 10, 28, 9, 14, 1, 792, DateTimeKind.Utc).AddTicks(8520),
                            Name = "Эндокринолог"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Comment", b =>
                {
                    b.HasOne("Medical_Information_System_API.Classes.Consultation", null)
                        .WithMany("Comments")
                        .HasForeignKey("ConsultationId");
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Consultation", b =>
                {
                    b.HasOne("Medical_Information_System_API.Classes.Inspection", null)
                        .WithMany("Consultations")
                        .HasForeignKey("InspectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medical_Information_System_API.Models.DiagnosisModel", b =>
                {
                    b.HasOne("Medical_Information_System_API.Classes.Inspection", null)
                        .WithMany("Diagnoses")
                        .HasForeignKey("InspectionId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Consultation", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Medical_Information_System_API.Classes.Inspection", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Diagnoses");
                });
#pragma warning restore 612, 618
        }
    }
}
