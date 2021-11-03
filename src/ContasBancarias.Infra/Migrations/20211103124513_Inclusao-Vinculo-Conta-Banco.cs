using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasBancarias.Infra.Migrations
{
    public partial class InclusaoVinculoContaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                schema: "ContasBancarias",
                table: "Contas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contas_BancoId",
                schema: "ContasBancarias",
                table: "Contas",
                column: "BancoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contas_Bancos_BancoId",
                schema: "ContasBancarias",
                table: "Contas",
                column: "BancoId",
                principalSchema: "ContasBancarias",
                principalTable: "Bancos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contas_Bancos_BancoId",
                schema: "ContasBancarias",
                table: "Contas");

            migrationBuilder.DropIndex(
                name: "IX_Contas_BancoId",
                schema: "ContasBancarias",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "BancoId",
                schema: "ContasBancarias",
                table: "Contas");
        }
    }
}
