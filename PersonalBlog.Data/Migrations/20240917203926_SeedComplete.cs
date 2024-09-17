using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Comments",
                type: "character varying(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Comments",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "Description", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime", "Name" },
                values: new object[,]
                {
                    { new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1490), null, null, null, true, false, null, null, "Software" },
                    { new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1500), null, null, null, true, false, null, null, "Hardware" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "FileName", "FileType", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime" },
                values: new object[,]
                {
                    { new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2160), null, null, "Hardware Image", "image/jpeg", true, false, null, null },
                    { new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2150), null, null, "Software Image", "image/jpeg", true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8f2ecbe3-4f67-4a8e-b03c-bf9f7bec5261"), new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "This is the first article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(730), null, null, new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "First Article", 5 },
                    { new Guid("f94daf07-6fc2-4350-bd53-2d3ed10628e8"), new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "This is the second article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(740), null, null, new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "Second Article", 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8f2ecbe3-4f67-4a8e-b03c-bf9f7bec5261"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f94daf07-6fc2-4350-bd53-2d3ed10628e8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"));

            migrationBuilder.AlterColumn<string>(
                name: "FileType",
                table: "Comments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "Comments",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Articles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);
        }
    }
}
