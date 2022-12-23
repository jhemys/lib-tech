using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingConstraintSlotPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Slot_Position",
                table: "Slot",
                column: "Position",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Slot_Position",
                table: "Slot");
        }
    }
}
