using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBookRepository.Migrations
{
    /// <inheritdoc />
    public partial class addUserAndAddressRelationAndMissingFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AddressBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Passwrod",
                table: "AddressBook",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "AddressBook");

            migrationBuilder.DropColumn(
                name: "Passwrod",
                table: "AddressBook");
        }
    }
}
