using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopulaPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Pedidos(Descricao, NomeFornecedor, ValorTotal,Quantidade) " +
                "Values('Compras parceladas','Fornecedor1',10.50, 1)");
            mb.Sql("Insert into Pedidos(Descricao, NomeFornecedor, ValorTotal, Quantidade) " +
                "Values('Compras com desconto','Fornecedor2',15.30, 2)");
            mb.Sql("Insert into Pedidos(Descricao, NomeFornecedor, ValorTotal, Quantidade) " +
                "Values('Compras a prazo','Fornecedor3',45.20, 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Pedidos");
        }
    }
}
