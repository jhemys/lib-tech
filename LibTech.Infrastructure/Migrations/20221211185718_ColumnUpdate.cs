using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ColumnUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoneyInside_TwentyDollarCount",
                table: "VendingMachines",
                newName: "TwentyDollarCount");

            migrationBuilder.RenameColumn(
                name: "MoneyInside_TenCentCount",
                table: "VendingMachines",
                newName: "TenCentCount");

            migrationBuilder.RenameColumn(
                name: "MoneyInside_QuarterCount",
                table: "VendingMachines",
                newName: "QuarterCount");

            migrationBuilder.RenameColumn(
                name: "MoneyInside_OneDollarCount",
                table: "VendingMachines",
                newName: "OneDollarCount");

            migrationBuilder.RenameColumn(
                name: "MoneyInside_OneCentCount",
                table: "VendingMachines",
                newName: "OneCentCount");

            migrationBuilder.RenameColumn(
                name: "MoneyInside_FiveDollarCount",
                table: "VendingMachines",
                newName: "FiveDollarCount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TwentyDollarCount",
                table: "VendingMachines",
                newName: "MoneyInside_TwentyDollarCount");

            migrationBuilder.RenameColumn(
                name: "TenCentCount",
                table: "VendingMachines",
                newName: "MoneyInside_TenCentCount");

            migrationBuilder.RenameColumn(
                name: "QuarterCount",
                table: "VendingMachines",
                newName: "MoneyInside_QuarterCount");

            migrationBuilder.RenameColumn(
                name: "OneDollarCount",
                table: "VendingMachines",
                newName: "MoneyInside_OneDollarCount");

            migrationBuilder.RenameColumn(
                name: "OneCentCount",
                table: "VendingMachines",
                newName: "MoneyInside_OneCentCount");

            migrationBuilder.RenameColumn(
                name: "FiveDollarCount",
                table: "VendingMachines",
                newName: "MoneyInside_FiveDollarCount");
        }
    }
}
