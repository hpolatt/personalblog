using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonalBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Comments_ImageId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("8f2ecbe3-4f67-4a8e-b03c-bf9f7bec5261"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("f94daf07-6fc2-4350-bd53-2d3ed10628e8"));

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Images");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Categories",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Articles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Articles",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Articles",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Images",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Images",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Images",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Images",
                table: "Images",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Images_ImageId",
                table: "Articles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Images",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("570e3ff1-8604-4565-a2f9-df20295091a6"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("ef787a06-b92f-4042-8d49-70637a6587b2"));

            migrationBuilder.RenameTable(
                name: "Images",
                newName: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Articles",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeletedTime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Comments",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedTime", "DeletedBy", "DeletedTime", "ImageId", "IsActive", "IsDeleted", "ModifiedBy", "ModifiedTime", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("8f2ecbe3-4f67-4a8e-b03c-bf9f7bec5261"), new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"), "This is the first article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(730), null, null, new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "First Article", 5 },
                    { new Guid("f94daf07-6fc2-4350-bd53-2d3ed10628e8"), new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), "This is the second article content of the blog site.", "admin", new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(740), null, null, new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"), true, false, null, null, "Second Article", 10 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f1e3e0d-1d2b-4b4c-8b8a-5f5f9f5f6f6f"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("a6b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2160));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("f5b07384-d9a7-4f3b-8f3b-3b7b4b3b7b3b"),
                column: "CreatedTime",
                value: new DateTime(2024, 9, 17, 23, 39, 26, 606, DateTimeKind.Local).AddTicks(2150));

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Comments_ImageId",
                table: "Articles",
                column: "ImageId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
