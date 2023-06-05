using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Commarce_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedBrand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Address", "ContactPerson", "Email", "IsShowLogo", "IsShowNavLogo", "Logo", "Name", "NavLogo", "Phone", "Slogan" },
                values: new object[] { 1, "Brand Address", "Brand Contact Person", "brand@email.com", false, false, "", "Brand", "", "0000000000", "Brand Slogan" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brand",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
