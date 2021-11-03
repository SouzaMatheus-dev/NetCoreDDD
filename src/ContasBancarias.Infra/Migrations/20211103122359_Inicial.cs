using Microsoft.EntityFrameworkCore.Migrations;

namespace ContasBancarias.Infra.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ContasBancarias");

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
                    EhAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contas",
                schema: "ContasBancarias");
        }
    }
}
