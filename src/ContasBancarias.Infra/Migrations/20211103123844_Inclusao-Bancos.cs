using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasBancarias.Infra.Migrations
{
    public partial class InclusaoBancos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "id",
                schema: "ContasBancarias",
                table: "Contas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contas",
                schema: "ContasBancarias",
                table: "Contas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bancos",
                schema: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ContasBancarias",
                table: "Bancos",
                columns: new[] { "Id", "Ativo", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, false, "001", "BANCO DO BRASIL" },
                    { 2, false, "070", "BRB" },
                    { 3, false, "104", "CAIXA ECONÔMICA FEDERAL" },
                    { 4, false, "429", "BANCO INTER" },
                    { 6, false, "237", "BRADESCO" },
                    { 7, false, "008", "SANTANDER" },
                    { 8, false, "756", "SICOOB" },
                    { 9, false, "048", "ITAU" },
                    { 10, false, "422", "SAFRA" },
                    { 11, false, "477", "CITIBANK" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "ContasBancarias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contas",
                schema: "ContasBancarias",
                table: "Contas");

            migrationBuilder.AddPrimaryKey(
                name: "id",
                schema: "ContasBancarias",
                table: "Contas",
                column: "Id");
        }
    }
}
