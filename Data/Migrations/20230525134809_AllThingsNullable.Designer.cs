﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PXLApp3.Data;

#nullable disable

namespace PXLApp3.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230525134809_AllThingsNullable")]
    partial class AllThingsNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PXLApp.Models.AcademieJaar", b =>
                {
                    b.Property<int>("AcademieJaarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademieJaarId"), 1L, 1);

                    b.Property<DateTime?>("StartDatum")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("AcademieJaarId");

                    b.ToTable("academieJaren");
                });

            modelBuilder.Entity("PXLApp.Models.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GebruikerId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GebruikerId");

                    b.ToTable("gebruikers");
                });

            modelBuilder.Entity("PXLApp.Models.Handboek", b =>
                {
                    b.Property<int>("HandboekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HandboekId"), 1L, 1);

                    b.Property<string>("Afbeelding")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("KostPrijs")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("Uitgiftedatum")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("HandboekId");

                    b.ToTable("handboeken");
                });

            modelBuilder.Entity("PXLApp.Models.Inschrijving", b =>
                {
                    b.Property<int>("InschrijvingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InschrijvingId"), 1L, 1);

                    b.Property<int?>("AcademieJaarId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("VakLectorId")
                        .HasColumnType("int");

                    b.HasKey("InschrijvingId");

                    b.HasIndex("AcademieJaarId");

                    b.HasIndex("StudentId");

                    b.HasIndex("VakLectorId");

                    b.ToTable("inschrijvingen");
                });

            modelBuilder.Entity("PXLApp.Models.Lector", b =>
                {
                    b.Property<int>("LectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LectorId"), 1L, 1);

                    b.Property<int?>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("LectorId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("lectors");
                });

            modelBuilder.Entity("PXLApp.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"), 1L, 1);

                    b.Property<int?>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("GebruikerId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("PXLApp.Models.Vak", b =>
                {
                    b.Property<int>("VakId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VakId"), 1L, 1);

                    b.Property<int?>("HandboekId")
                        .HasColumnType("int");

                    b.Property<int?>("Studiepunten")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("VakNaam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VakId");

                    b.HasIndex("HandboekId");

                    b.ToTable("vakken");
                });

            modelBuilder.Entity("PXLApp.Models.VakLector", b =>
                {
                    b.Property<int>("VakLectorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VakLectorId"), 1L, 1);

                    b.Property<int?>("LectorId")
                        .HasColumnType("int");

                    b.Property<int?>("VakId")
                        .HasColumnType("int");

                    b.HasKey("VakLectorId");

                    b.HasIndex("LectorId");

                    b.HasIndex("VakId");

                    b.ToTable("vakLectoren");
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

            modelBuilder.Entity("PXLApp.Models.Inschrijving", b =>
                {
                    b.HasOne("PXLApp.Models.AcademieJaar", "AcademieJaar")
                        .WithMany()
                        .HasForeignKey("AcademieJaarId");

                    b.HasOne("PXLApp.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.HasOne("PXLApp.Models.VakLector", "VakLector")
                        .WithMany()
                        .HasForeignKey("VakLectorId");

                    b.Navigation("AcademieJaar");

                    b.Navigation("Student");

                    b.Navigation("VakLector");
                });

            modelBuilder.Entity("PXLApp.Models.Lector", b =>
                {
                    b.HasOne("PXLApp.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId");

                    b.Navigation("Gebruiker");
                });

            modelBuilder.Entity("PXLApp.Models.Student", b =>
                {
                    b.HasOne("PXLApp.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId");

                    b.Navigation("Gebruiker");
                });

            modelBuilder.Entity("PXLApp.Models.Vak", b =>
                {
                    b.HasOne("PXLApp.Models.Handboek", "Handboek")
                        .WithMany()
                        .HasForeignKey("HandboekId");

                    b.Navigation("Handboek");
                });

            modelBuilder.Entity("PXLApp.Models.VakLector", b =>
                {
                    b.HasOne("PXLApp.Models.Lector", "Lector")
                        .WithMany()
                        .HasForeignKey("LectorId");

                    b.HasOne("PXLApp.Models.Vak", "Vak")
                        .WithMany()
                        .HasForeignKey("VakId");

                    b.Navigation("Lector");

                    b.Navigation("Vak");
                });
#pragma warning restore 612, 618
        }
    }
}
