using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VendingMachines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoneyInsideOneCentCount = table.Column<int>(name: "MoneyInside_OneCentCount", type: "int", nullable: false),
                    MoneyInsideTenCentCount = table.Column<int>(name: "MoneyInside_TenCentCount", type: "int", nullable: false),
                    MoneyInsideQuarterCount = table.Column<int>(name: "MoneyInside_QuarterCount", type: "int", nullable: false),
                    MoneyInsideOneDollarCount = table.Column<int>(name: "MoneyInside_OneDollarCount", type: "int", nullable: false),
                    MoneyInsideFiveDollarCount = table.Column<int>(name: "MoneyInside_FiveDollarCount", type: "int", nullable: false),
                    MoneyInsideTwentyDollarCount = table.Column<int>(name: "MoneyInside_TwentyDollarCount", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendingMachines", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendingMachines");
        }
    }
}
