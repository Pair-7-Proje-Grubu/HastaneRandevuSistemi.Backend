using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class feedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Patients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFeedback = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4983));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4989));

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1,
                column: "FeedbackId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2,
                column: "FeedbackId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3,
                column: "FeedbackId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4949), new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4976), new byte[] { 21, 2, 89, 186, 54, 33, 33, 212, 103, 54, 251, 91, 123, 64, 126, 42, 1, 61, 194, 224, 121, 129, 22, 64, 110, 113, 204, 21, 105, 11, 103, 74, 7, 162, 54, 40, 69, 55, 166, 124, 33, 110, 58, 1, 30, 176, 217, 178, 116, 223, 73, 67, 119, 165, 234, 121, 153, 205, 129, 12, 52, 68, 201, 253 }, new byte[] { 57, 49, 82, 54, 135, 151, 46, 104, 112, 134, 91, 109, 201, 3, 101, 210, 79, 217, 156, 90, 84, 157, 53, 177, 41, 159, 210, 124, 184, 70, 248, 128, 242, 158, 244, 17, 66, 28, 215, 16, 67, 191, 241, 202, 226, 158, 91, 207, 66, 255, 239, 245, 38, 55, 31, 208, 198, 247, 37, 2, 1, 146, 133, 203, 121, 34, 121, 61, 148, 169, 157, 83, 226, 236, 61, 101, 206, 79, 187, 129, 184, 253, 246, 48, 102, 211, 59, 218, 138, 211, 123, 60, 164, 38, 91, 121, 69, 184, 138, 8, 4, 194, 131, 197, 62, 179, 127, 253, 217, 68, 84, 154, 247, 62, 182, 122, 63, 138, 45, 127, 42, 229, 207, 231, 156, 237, 232, 112 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4984), new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4985), new byte[] { 21, 2, 89, 186, 54, 33, 33, 212, 103, 54, 251, 91, 123, 64, 126, 42, 1, 61, 194, 224, 121, 129, 22, 64, 110, 113, 204, 21, 105, 11, 103, 74, 7, 162, 54, 40, 69, 55, 166, 124, 33, 110, 58, 1, 30, 176, 217, 178, 116, 223, 73, 67, 119, 165, 234, 121, 153, 205, 129, 12, 52, 68, 201, 253 }, new byte[] { 57, 49, 82, 54, 135, 151, 46, 104, 112, 134, 91, 109, 201, 3, 101, 210, 79, 217, 156, 90, 84, 157, 53, 177, 41, 159, 210, 124, 184, 70, 248, 128, 242, 158, 244, 17, 66, 28, 215, 16, 67, 191, 241, 202, 226, 158, 91, 207, 66, 255, 239, 245, 38, 55, 31, 208, 198, 247, 37, 2, 1, 146, 133, 203, 121, 34, 121, 61, 148, 169, 157, 83, 226, 236, 61, 101, 206, 79, 187, 129, 184, 253, 246, 48, 102, 211, 59, 218, 138, 211, 123, 60, 164, 38, 91, 121, 69, 184, 138, 8, 4, 194, 131, 197, 62, 179, 127, 253, 217, 68, 84, 154, 247, 62, 182, 122, 63, 138, 45, 127, 42, 229, 207, 231, 156, 237, 232, 112 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4990), new DateTime(2024, 7, 4, 13, 25, 11, 427, DateTimeKind.Local).AddTicks(4991), new byte[] { 21, 2, 89, 186, 54, 33, 33, 212, 103, 54, 251, 91, 123, 64, 126, 42, 1, 61, 194, 224, 121, 129, 22, 64, 110, 113, 204, 21, 105, 11, 103, 74, 7, 162, 54, 40, 69, 55, 166, 124, 33, 110, 58, 1, 30, 176, 217, 178, 116, 223, 73, 67, 119, 165, 234, 121, 153, 205, 129, 12, 52, 68, 201, 253 }, new byte[] { 57, 49, 82, 54, 135, 151, 46, 104, 112, 134, 91, 109, 201, 3, 101, 210, 79, 217, 156, 90, 84, 157, 53, 177, 41, 159, 210, 124, 184, 70, 248, 128, 242, 158, 244, 17, 66, 28, 215, 16, 67, 191, 241, 202, 226, 158, 91, 207, 66, 255, 239, 245, 38, 55, 31, 208, 198, 247, 37, 2, 1, 146, 133, 203, 121, 34, 121, 61, 148, 169, 157, 83, 226, 236, 61, 101, 206, 79, 187, 129, 184, 253, 246, 48, 102, 211, 59, 218, 138, 211, 123, 60, 164, 38, 91, 121, 69, 184, 138, 8, 4, 194, 131, 197, 62, 179, 127, 253, 217, 68, 84, 154, 247, 62, 182, 122, 63, 138, 45, 127, 42, 229, 207, 231, 156, 237, 232, 112 } });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_FeedbackId",
                table: "Patients",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Feedbacks_FeedbackId",
                table: "Patients",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Feedbacks_FeedbackId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Patients_FeedbackId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4454));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4439), new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4447), new byte[] { 145, 78, 55, 17, 34, 1, 229, 31, 65, 251, 46, 139, 111, 246, 158, 241, 221, 219, 35, 197, 111, 74, 162, 124, 145, 80, 31, 255, 222, 92, 234, 119, 205, 38, 16, 75, 12, 117, 65, 7, 231, 237, 186, 140, 181, 115, 89, 42, 223, 189, 244, 246, 209, 95, 75, 24, 102, 75, 245, 235, 191, 126, 168, 44 }, new byte[] { 22, 216, 141, 59, 205, 105, 118, 202, 52, 176, 147, 128, 125, 33, 66, 49, 92, 95, 146, 158, 200, 58, 83, 66, 116, 81, 91, 229, 184, 53, 123, 66, 25, 220, 82, 178, 169, 114, 207, 243, 45, 132, 92, 137, 244, 207, 74, 118, 72, 33, 154, 173, 60, 46, 251, 70, 222, 81, 46, 35, 141, 176, 211, 245, 176, 144, 38, 187, 46, 246, 138, 63, 226, 126, 9, 179, 47, 98, 104, 172, 3, 144, 216, 16, 50, 99, 86, 1, 98, 26, 138, 34, 68, 178, 93, 46, 119, 244, 235, 148, 57, 248, 128, 48, 229, 41, 206, 146, 89, 139, 177, 163, 103, 125, 44, 237, 255, 200, 6, 219, 18, 149, 146, 138, 213, 208, 99, 16 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4450), new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4451), new byte[] { 145, 78, 55, 17, 34, 1, 229, 31, 65, 251, 46, 139, 111, 246, 158, 241, 221, 219, 35, 197, 111, 74, 162, 124, 145, 80, 31, 255, 222, 92, 234, 119, 205, 38, 16, 75, 12, 117, 65, 7, 231, 237, 186, 140, 181, 115, 89, 42, 223, 189, 244, 246, 209, 95, 75, 24, 102, 75, 245, 235, 191, 126, 168, 44 }, new byte[] { 22, 216, 141, 59, 205, 105, 118, 202, 52, 176, 147, 128, 125, 33, 66, 49, 92, 95, 146, 158, 200, 58, 83, 66, 116, 81, 91, 229, 184, 53, 123, 66, 25, 220, 82, 178, 169, 114, 207, 243, 45, 132, 92, 137, 244, 207, 74, 118, 72, 33, 154, 173, 60, 46, 251, 70, 222, 81, 46, 35, 141, 176, 211, 245, 176, 144, 38, 187, 46, 246, 138, 63, 226, 126, 9, 179, 47, 98, 104, 172, 3, 144, 216, 16, 50, 99, 86, 1, 98, 26, 138, 34, 68, 178, 93, 46, 119, 244, 235, 148, 57, 248, 128, 48, 229, 41, 206, 146, 89, 139, 177, 163, 103, 125, 44, 237, 255, 200, 6, 219, 18, 149, 146, 138, 213, 208, 99, 16 } });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4455), new DateTime(2024, 7, 2, 15, 17, 23, 498, DateTimeKind.Local).AddTicks(4456), new byte[] { 145, 78, 55, 17, 34, 1, 229, 31, 65, 251, 46, 139, 111, 246, 158, 241, 221, 219, 35, 197, 111, 74, 162, 124, 145, 80, 31, 255, 222, 92, 234, 119, 205, 38, 16, 75, 12, 117, 65, 7, 231, 237, 186, 140, 181, 115, 89, 42, 223, 189, 244, 246, 209, 95, 75, 24, 102, 75, 245, 235, 191, 126, 168, 44 }, new byte[] { 22, 216, 141, 59, 205, 105, 118, 202, 52, 176, 147, 128, 125, 33, 66, 49, 92, 95, 146, 158, 200, 58, 83, 66, 116, 81, 91, 229, 184, 53, 123, 66, 25, 220, 82, 178, 169, 114, 207, 243, 45, 132, 92, 137, 244, 207, 74, 118, 72, 33, 154, 173, 60, 46, 251, 70, 222, 81, 46, 35, 141, 176, 211, 245, 176, 144, 38, 187, 46, 246, 138, 63, 226, 126, 9, 179, 47, 98, 104, 172, 3, 144, 216, 16, 50, 99, 86, 1, 98, 26, 138, 34, 68, 178, 93, 46, 119, 244, 235, 148, 57, 248, 128, 48, 229, 41, 206, 146, 89, 139, 177, 163, 103, 125, 44, 237, 255, 200, 6, 219, 18, 149, 146, 138, 213, 208, 99, 16 } });
        }
    }
}
