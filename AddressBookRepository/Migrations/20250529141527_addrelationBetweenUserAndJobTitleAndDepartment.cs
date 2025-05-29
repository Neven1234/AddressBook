using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBookRepository.Migrations
{
    /// <inheritdoc />
    public partial class addrelationBetweenUserAndJobTitleAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "jobTitle",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "userId",
                table: "Department",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_jobTitle_userId",
                table: "jobTitle",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_userId",
                table: "Department",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_User_userId",
                table: "Department",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_jobTitle_User_userId",
                table: "jobTitle",
                column: "userId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_User_userId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_jobTitle_User_userId",
                table: "jobTitle");

            migrationBuilder.DropIndex(
                name: "IX_jobTitle_userId",
                table: "jobTitle");

            migrationBuilder.DropIndex(
                name: "IX_Department_userId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "jobTitle");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Department");
        }
    }
}
