using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Pedidos")]
public class Pedido
{
    public Pedido()
    {
        Produtos = new Collection<Produto>();
    }

    [Key]
    public int PedidoId { get; set; }

    [Required]
    [StringLength(300)]
    public string? Descricao { get; set; }

    [Required]
    [StringLength(80)]
    public string? NomeFornecedor { get; set; }

    [Required]
    public int Quantidade { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal ValorTotal {  get; set; }
    

    public ICollection<Produto>? Produtos { get; set; }
}
