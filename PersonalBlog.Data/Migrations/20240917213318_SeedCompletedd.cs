using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompletedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("570e3ff1-8604-4565-a2f9-df20295091a6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef787a06-b92f-4042-8d49-70637a6587b2"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("3a0532fd-df78-4cb8-983f-647498ac80f2"), new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "This is the first article content of the blog site.", "admin", new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(5170), null, null, new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "First Article", 5 },
                    { new Guid("463b8104-3eb3-477b-92d6-c2d2737b253b"), new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "This is the second article content of the blog site.", "admin", new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(5190), null, null, new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "Second Article", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(6010));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 18, 0, 33, 18, 766, DateTimeKind.Local).AddTicks(6590));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("3a0532fd-df78-4cb8-983f-647498ac80f2"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("463b8104-3eb3-477b-92d6-c2d2737b253b"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("570e3ff1-8604-4565-a2f9-df20295091a6"), new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "This is the second article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(5240), null, null, new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "Second Article", 10 },
                    { new Guid("ef787a06-b92f-4042-8d49-70637a6587b2"), new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "This is the first article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(5230), null, null, new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "First Article", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(5990));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(6000));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(6560));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 43, 36, 598, DateTimeKind.Local).AddTicks(6560));
        }
    }
}
