using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCommerce.Data.Migrations
{
    public partial class primea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentaDetalle_VentaCabecera_VentaCabeceraId",
                table: "VentaDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentaDetalle",
                table: "VentaDetalle");

            migrationBuilder.RenameTable(
                name: "VentaDetalle",
                newName: "VentasDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_VentaDetalle_VentaCabeceraId",
                table: "VentasDetalles",
                newName: "IX_VentasDetalles_VentaCabeceraId");

            migrationBuilder.AlterColumn<int>(
                name: "VentaCabeceraId",
                table: "VentasDetalles",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentasDetalles",
                table: "VentasDetalles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VentasDetalles_VentaCabecera_VentaCabeceraId",
                table: "VentasDetalles",
                column: "VentaCabeceraId",
                principalTable: "VentaCabecera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VentasDetalles_VentaCabecera_VentaCabeceraId",
                table: "VentasDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VentasDetalles",
                table: "VentasDetalles");

            migrationBuilder.RenameTable(
                name: "VentasDetalles",
                newName: "VentaDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_VentasDetalles_VentaCabeceraId",
                table: "VentaDetalle",
                newName: "IX_VentaDetalle_VentaCabeceraId");

            migrationBuilder.AlterColumn<int>(
                name: "VentaCabeceraId",
                table: "VentaDetalle",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VentaDetalle",
                table: "VentaDetalle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VentaDetalle_VentaCabecera_VentaCabeceraId",
                table: "VentaDetalle",
                column: "VentaCabeceraId",
                principalTable: "VentaCabecera",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
