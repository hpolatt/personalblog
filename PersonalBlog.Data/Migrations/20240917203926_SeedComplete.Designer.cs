﻿// <auto-generated />
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
    [Migration("20240917203926_SeedComplete")]
    partial class SeedComplete
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

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

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ImageId")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

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
                            Id = new Guid("8f2ecbe3-4f67-4a8e-b03c-bf9f7bec5261"),
                            CategoryId = new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                            Content = "This is the first article content of the blog site.",
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(730),
                            ImageId = new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            IsActive = true,
                            IsDeleted = false,
                            Title = "First Article",
                            ViewCount = 5
                        },
                        new
                        {
                            Id = new Guid("f94daf07-6fc2-4350-bd53-2d3ed10628e8"),
                            CategoryId = new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            Content = "This is the second article content of the blog site.",
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(740),
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

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

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
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1490),
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Software"
                        },
                        new
                        {
                            Id = new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1500),
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

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DeletedTime")
                        .HasColumnType("timestamp with time zone");

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

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2150),
                            FileName = "Software Image",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        },
                        new
                        {
                            Id = new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                            CreatedBy = "admin",
                            CreatedTime = new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2160),
                            FileName = "Hardware Image",
                            FileType = "image/jpeg",
                            IsActive = true,
                            IsDeleted = false
                        });
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
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
