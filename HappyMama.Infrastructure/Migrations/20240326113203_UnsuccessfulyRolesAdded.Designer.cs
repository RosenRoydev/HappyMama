﻿// <auto-generated />
using System;
using HappyMama.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HappyMama.Infrastructure.Migrations
{
    [DbContext(typeof(HappyMamaDbContext))]
    [Migration("20240326113203_AddRoles")]
    partial class AddRoles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Admin identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Nickname of the admin");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Admins");

                    b.HasComment("Class for the admins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nickname = "petrova",
                            UserId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92"
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("EventIdentifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<decimal>("AmountForPay")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Amount the parent must pay for the event");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Creator identifier");

                    b.Property<DateTime>("DeadTime")
                        .HasColumnType("datetime2")
                        .HasComment("The last date when the parents can pay for the event");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Event Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("EventName");

                    b.Property<decimal>("NeededAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Needed money for the event");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Events");

                    b.HasComment("Events for collecting money");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AmountForPay = 5m,
                            CreatorId = "579cfd9f-0dfd-4775-b05d-e2ca79d70b92",
                            DeadTime = new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(2820),
                            Description = "This year the present of the teacher will be two boxes of flowers",
                            Name = "Christmas gifts for the teachers",
                            NeededAmount = 80m
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.EventParent", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasComment("Event Identifier");

                    b.Property<int>("ParentId")
                        .HasColumnType("int")
                        .HasComment("Parent identifier");

                    b.HasKey("EventId", "ParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("EventsParents");

                    b.HasComment("Mapping table between parents and events because of payments");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("News identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Date of creating of the news");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Creator Identifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Description of the news");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasComment("News title");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("TeacherId");

                    b.ToTable("News");

                    b.HasComment("News section");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(2913),
                            CreatorId = "a05289cd-5411-45bb-b863-ba2394c21342",
                            Description = "All parents , who want their child to be vaccinated , please contact with me . The vaccination is organized by the Ministry of health and is for free!",
                            Title = "Vaccine against Flu"
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Parent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Parent identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("Decimal(18,2)")
                        .HasComment("Amount from where the parent can pay for events");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("First name of the parent");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Last name of the parent");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Parents");

                    b.HasComment("Class for parents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 180m,
                            FirstName = "Ani",
                            LastName = "Ivanova",
                            UserId = "228dfc0a-78a8-4163-aff3-94a5c1014fbb"
                        },
                        new
                        {
                            Id = 2,
                            Amount = 180m,
                            FirstName = "Petia",
                            LastName = "Dubarova",
                            UserId = "03d74db7-55ee-4ee0-ae1d-7c16a4578141"
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Post Identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)")
                        .HasComment("Post content");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Post date");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Creator identifier");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<int>("ThemeId")
                        .HasColumnType("int")
                        .HasComment("Post identifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Posts");

                    b.HasComment("Forum Section - Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Hello i want to write Toni has problem with food . Do you have this problem ?",
                            CreatedOn = new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3051),
                            CreatorId = "228dfc0a-78a8-4163-aff3-94a5c1014fbb",
                            ThemeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "I have the same problem",
                            CreatedOn = new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3052),
                            CreatorId = "03d74db7-55ee-4ee0-ae1d-7c16a4578141",
                            ThemeId = 1
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Teacher identifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("First name of the teacher");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("Last name of the teacher");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Identifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Teachers");

                    b.HasComment("Class for teachers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Snezhana",
                            LastName = "Ilieva",
                            UserId = "a05289cd-5411-45bb-b863-ba2394c21342"
                        });
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Theme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("PostIdentifier");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2")
                        .HasComment("Creating date of the theme for discussion");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("CreatorIdentifier");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("ThemeTitle");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("ParentId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Themes");

                    b.HasComment("Forum Section - Theme creating");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2024, 3, 26, 11, 32, 3, 509, DateTimeKind.Utc).AddTicks(3008),
                            CreatorId = "228dfc0a-78a8-4163-aff3-94a5c1014fbb",
                            Title = "Problem with Toni"
                        });
                });

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

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Admin", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Event", b =>
                {
                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Admin", null)
                        .WithMany("Events")
                        .HasForeignKey("AdminId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Teacher", null)
                        .WithMany("Events")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.EventParent", b =>
                {
                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Event", "Event")
                        .WithMany("Parents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Parent", "User")
                        .WithMany("Events")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.News", b =>
                {
                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Admin", null)
                        .WithMany("News")
                        .HasForeignKey("AdminId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Teacher", null)
                        .WithMany("News")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Parent", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Post", b =>
                {
                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Admin", null)
                        .WithMany("Posts")
                        .HasForeignKey("AdminId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Parent", null)
                        .WithMany("Posts")
                        .HasForeignKey("ParentId");

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Teacher", null)
                        .WithMany("Posts")
                        .HasForeignKey("TeacherId");

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Theme", "Theme")
                        .WithMany("Posts")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Theme", b =>
                {
                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Admin", null)
                        .WithMany("Theme")
                        .HasForeignKey("AdminId");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Parent", null)
                        .WithMany("Theme")
                        .HasForeignKey("ParentId");

                    b.HasOne("HappyMama.Infrastructure.Data.DataModels.Teacher", null)
                        .WithMany("Themes")
                        .HasForeignKey("TeacherId");

                    b.Navigation("Creator");
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

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Admin", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("News");

                    b.Navigation("Posts");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Event", b =>
                {
                    b.Navigation("Parents");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Parent", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Posts");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Teacher", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("News");

                    b.Navigation("Posts");

                    b.Navigation("Themes");
                });

            modelBuilder.Entity("HappyMama.Infrastructure.Data.DataModels.Theme", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
