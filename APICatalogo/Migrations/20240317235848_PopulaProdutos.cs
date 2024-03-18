using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Produtos(NomeProduto, DescricaoProduto, Preco, Estoque, PedidoId) " +
                "Values('Cafe', 'Cafe torrado 250 g', 18.80, 15, 1)");

            mb.Sql("Insert into Produtos(NomeProduto, DescricaoProduto, Preco, Estoque, PedidoId) " +
                "Values('Suco', 'suco de uva 200 ml', 5.80, 8, 2)");

            mb.Sql("Insert into Produtos(NomeProduto, DescricaoProduto, Preco, Estoque, PedidoId) " +
                "Values('Arroz', 'Arroz Branco 1 kg', 13.30, 6, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Produtos");
        }
    }
}
