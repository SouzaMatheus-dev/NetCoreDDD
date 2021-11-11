using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasBancarias.Infra.Migrations
{
    public partial class ContasBancarias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ContasBancarias");

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

            migrationBuilder.CreateTable(
                name: "Contas",
                schema: "ContasBancarias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroConta = table.Column<int>(type: "int", nullable: false),
                    NumeroAgencia = table.Column<int>(type: "int", nullable: false),
                    CpfOuCnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeOuRazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EhAtivo = table.Column<bool>(type: "bit", nullable: false),
                    BancoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contas_Bancos_BancoId",
                        column: x => x.BancoId,
                        principalSchema: "ContasBancarias",
                        principalTable: "Bancos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Contas_BancoId",
                schema: "ContasBancarias",
                table: "Contas",
                column: "BancoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas",
                schema: "ContasBancarias");

            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "ContasBancarias");
        }
    }
}
