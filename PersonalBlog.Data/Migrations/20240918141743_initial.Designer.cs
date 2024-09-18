﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PersonalBlog.Data.Context;

#nullable disable

namespace PersonalBlog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240918141743_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("904c4ca3-6a70-461b-9739-fb4900e36fcf"),
                            ConcurrencyStamp = "0b799303-bdfe-479a-ac7c-78d36fa3d365",
                            Name = "Superadmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = new Guid("5d10d5f3-9e0b-47c5-b1ea-3551d4f93f9d"),
                            ConcurrencyStamp = "f0180693-c367-4d20-bdbd-85c1faf3af16",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("e460226b-25f8-4c57-a02b-2fa1de29d80c"),
                            ConcurrencyStamp = "7659a182-22b3-4b81-b759-e155d0238ef7",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("ClaimValue")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

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

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

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

                    b.HasIndex("ImageId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c92bed79-d89f-415e-8479-1b31e36b43b9",
                            Email = "superadmin@hpolat.com",
                            EmailConfirmed = true,
                            FirstName = "Huseyin",
                            ImageId = new Guid("2452dfe7-24e8-4a40-b456-b2b3ed699b3b"),
                            LastName = "Polat",
                            LockoutEnabled = false,
                            NormalizedEmail = "SUPERADMIN@HPOLAT.COM",
                            NormalizedUserName = "SUPERADMIN@HPOLAT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEG9FGS7iTfe3QD5ktmypszL+WYYXaQEWtPCJuqVrypd+M+xB59BwztUaDP14pHRkuw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "acd73fb1-a29f-41e0-a751-494889ee18ff",
                            TwoFactorEnabled = false,
                            UserName = "superadmin@hpolat.com"
                        },
                        new
                        {
                            Id = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "fa6ae0a6-5a25-4622-ac54-a7a1fd83c55c",
                            Email = "admin@hpolat.com",
                            EmailConfirmed = true,
                            FirstName = "Huseyin",
                            ImageId = new Guid("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37"),
                            LastName = "Polat",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@HPOLAT.COM",
                            NormalizedUserName = "ADMIN@HPOLAT.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAENLz53xHy5xrMUemXT+NMiSX+8oi+7uFz8/jtzqS6e709I9DAkfZAXWMAEJKP6lczg==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "e7a33642-f910-40f1-aae5-ba6e02765b6a",
                            TwoFactorEnabled = false,
                            UserName = "admin@hpolat.com"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId1")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserId1");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            RoleId = new Guid("904c4ca3-6a70-461b-9739-fb4900e36fcf")
                        },
                        new
                        {
                            UserId = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            RoleId = new Guid("5d10d5f3-9e0b-47c5-b1ea-3551d4f93f9d")
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("ViewCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c74dd2e-dd40-43d0-8a95-c1c17d7bb465"),
                            CategoryId = new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                            Content = "This is the first article content of the blog site.",
                            CreatedBy = "admin",
                            CreatedById = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(1180),
                            ImageId = new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            IsActive = true,
                            IsDeleted = false,
                            Title = "First Article",
                            ViewCount = 5
                        },
                        new
                        {
                            Id = new Guid("fe040b5d-ac46-45bf-97fe-839b583a1217"),
                            CategoryId = new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            Content = "This is the second article content of the blog site.",
                            CreatedBy = "admin",
                            CreatedById = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(1190),
                            ImageId = new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            IsActive = true,
                            IsDeleted = false,
                            Title = "Second Article",
                            ViewCount = 10
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                            CreatedBy = "admin",
                            CreatedById = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(1880),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Software"
                        },
                        new
                        {
                            Id = new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "admin",
                            CreatedById = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(1890),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Hardware"
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("DeletedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("FileType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedById")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "superadmin",
                            CreatedById = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(2500),
                            FileName = "Software Image",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "admin",
                            CreatedById = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(2510),
                            FileName = "Hardware Image",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("2452dfe7-24e8-4a40-b456-b2b3ed699b3b"),
                            CreatedBy = "superadmin",
                            CreatedById = new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(2520),
                            FileName = "SuperAdmin_Profile",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37"),
                            CreatedBy = "admin",
                            CreatedById = new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"),
                            CreatedTime = new DateTime(2024, 9, 18, 17, 17, 43, 132, DateTimeKind.Local).AddTicks(2520),
                            FileName = "Admin_Profile",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppRoleClaim", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUser", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserClaim", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBlog.Entity.Entities.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserLogin", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserRole", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.AppUserToken", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Article", b =>
                {
                    b.HasOne("PersonalBlog.Entity.Entities.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalBlog.Entity.Entities.Image", "Image")
                        .WithMany("Articles")
                        .HasForeignKey("ImageId");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("PersonalBlog.Entity.Entities.Image", b =>
                {
                    b.Navigation("Articles");
                });
#pragma warning restore 612, 618
        }
    }
}
