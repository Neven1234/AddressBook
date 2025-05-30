using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBookRepository.Migrations
{
    /// <inheritdoc />
    public partial class fixMissbelingOfPasswordName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Passwrod",
                table: "AddressBook",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AddressBook",
                newName: "Passwrod");
        }
    }
}
