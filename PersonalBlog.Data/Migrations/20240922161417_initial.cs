using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FileName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FileType = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClaimValue = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
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
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedById = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedById = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    ModifiedBy = table.Column<string>(type: "text", nullable: true),
                    DeletedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ModifiedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ImageId = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5d10d5f3-9e0b-47c5-b1ea-3551d4f93f9d"), "19bca985-802e-4e5c-bc86-3cc36ee8fddf", "Admin", "ADMIN" },
                    { new Guid("904c4ca3-6a70-461b-9739-fb4900e36fcf"), "bce94284-9945-4386-949e-d1c6f6ce1dae", "Superadmin", "SUPERADMIN" },
                    { new Guid("e460226b-25f8-4c57-a02b-2fa1de29d80c"), "b6d354d6-ae3b-43f1-8fac-c1595d2d4df7", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedById", "CreatedTime", "DeletedBy", "DeletedById", "DeletedTime", "Description", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedById", "ModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "admin", new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(340), null, null, null, null, true, false, null, null, null, "Software" },
                    { new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "admin", new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(350), null, null, null, null, true, false, null, null, null, "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedById", "CreatedTime", "DeletedBy", "DeletedById", "DeletedTime", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedById", "ModifiedTime" },
                values: new object[,]
                {
                    { new Guid("2452dfe7-24e8-4a40-b456-b2b3ed699b3b"), "superadmin", new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(1130), null, null, null, "SuperAdmin_Profile", "image/jpeg", true, false, null, null, null },
                    { new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "admin", new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(1120), null, null, null, "Hardware Image", "image/jpeg", true, false, null, null, null },
                    { new Guid("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37"), "admin", new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(1140), null, null, null, "Admin_Profile", "image/jpeg", true, false, null, null, null },
                    { new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "superadmin", new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"), new DateTime(2024, 9, 22, 19, 14, 16, 516, DateTimeKind.Local).AddTicks(1110), null, null, null, "Software Image", "image/jpeg", true, false, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedById", "CreatedTime", "DeletedBy", "DeletedById", "DeletedTime", "ImageId", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedById", "ModifiedTime", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("e0683799-521d-47df-b2e0-396f4685f4e8"), new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi volutpat consequat dui quis volutpat. Nullam nec pretium neque. Donec eleifend nec leo in blandit. Cras tristique sapien vitae aliquet semper. Aenean sed leo vitae quam ultrices pellentesque sed nec nulla. Nam in nisi ultrices, porta urna nec, facilisis mi. Cras quis felis vitae neque tristique semper vel venenatis libero. Suspendisse lobortis orci ac ullamcorper fringilla. Cras congue mi non semper ultrices. Nunc gravida dui et justo tempus, eu venenatis erat viverra. Nullam sagittis molestie mauris vel rhoncus.", "Admin", new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"), new DateTime(2024, 9, 22, 19, 14, 16, 515, DateTimeKind.Local).AddTicks(9410), null, null, null, new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, null, "Second Article", 0 },
                    { new Guid("ed460622-69bd-4a0d-b293-6b6128f4444f"), new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "Pellentesque augue dolor, dapibus at ante at, venenatis pharetra diam. Ut in ipsum at sapien laoreet venenatis ac in ipsum. Vivamus id ligula dapibus, mattis ex eu, egestas ex. Etiam vel metus a felis ornare feugiat. Pellentesque nulla purus, volutpat at velit eget, aliquet vulputate odio. Mauris facilisis ligula massa, ac ullamcorper diam fermentum et. Sed pulvinar nulla sapien, ac finibus sem aliquet eu. Vivamus fermentum at risus eu mattis. Cras vitae rhoncus arcu, eu rhoncus elit. Nulla sem augue, lobortis id luctus ac, placerat quis libero. Sed laoreet lorem quis nulla scelerisque, in rhoncus ligula lobortis. Aliquam auctor lectus enim, et mattis elit iaculis quis. Morbi quam sem, sodales at vestibulum ac, interdum et lectus. Aliquam efficitur est accumsan euismod aliquet. Duis quam enim, pellentesque in pellentesque non, eleifend egestas lacus. Vivamus scelerisque lectus quis magna fermentum pharetra.", "Admin", new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"), new DateTime(2024, 9, 22, 19, 14, 16, 515, DateTimeKind.Local).AddTicks(9360), null, null, null, new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, null, "First Article", 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5"), 0, "d69807d8-2fab-441b-b4dd-265287e6a37f", "admin@hpolat.com", true, "Huseyin", new Guid("b5aa4b7b-431c-46f3-bf7f-cec3b4569b37"), "Polat", false, null, "ADMIN@HPOLAT.COM", "ADMIN@HPOLAT.COM", "AQAAAAIAAYagAAAAEDF4wx5+jCOosRI4Mf+JMj/6tpmLraJy9llS0Vyyd2QLTHQGfHiMgWr37FQlVAlkPg==", "1234567890", true, "893047a4-1c05-48c2-8421-25ee583dc1d3", false, "admin@hpolat.com" },
                    { new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513"), 0, "e85b9160-ffa1-4cab-968b-5dbad887de3c", "superadmin@hpolat.com", true, "Huseyin", new Guid("2452dfe7-24e8-4a40-b456-b2b3ed699b3b"), "Polat", false, null, "SUPERADMIN@HPOLAT.COM", "SUPERADMIN@HPOLAT.COM", "AQAAAAIAAYagAAAAEBBTxO21Ja/T+MRENbs1KBVEM6YUY7saLDDFO1X1SF1k680iABvb69aKXWbaLJ864Q==", "1234567890", true, "7c302b67-dcbf-4e1f-8521-c7c23bb0cfee", false, "superadmin@hpolat.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5d10d5f3-9e0b-47c5-b1ea-3551d4f93f9d"), new Guid("75f470f5-85fd-46ae-bac8-1e2045718eb5") },
                    { new Guid("904c4ca3-6a70-461b-9739-fb4900e36fcf"), new Guid("8df24b15-63fd-4faf-9020-d8ce712a0513") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

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
                name: "IX_AspNetUserClaims_UserId1",
                table: "AspNetUserClaims",
                column: "UserId1");

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
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

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
                name: "Articles");

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
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
