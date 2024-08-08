using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodePulse.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class migrateauthdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14910704-5b5c-4483-aa56-10a0a8701f45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "473f18b7-bd99-4718-86ff-3ed6beaa00f7", "AQAAAAIAAYagAAAAEK7iQUMfknp3wJn4dvBU8X2a2Ae3fLMRxFpIxsMewvdXr/VbS5Qw5BtwT4S56dfyjQ==", "b3a7b330-135b-4e1b-9472-2a092145d7fd" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "14910704-5b5c-4483-aa56-10a0a8701f45",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed5515c9-f166-4753-9992-61f183adbf83", "AQAAAAIAAYagAAAAEMfLk1s62nSpvGC7iBqZf+yD5RBRpPmEqEWRksTqV0Dmobdxx7p6RTkkEX2FHpql4A==", "457fe00a-0d86-4a28-9685-0b0476ef9db9" });
        }
    }
}
