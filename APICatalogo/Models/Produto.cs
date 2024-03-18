using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APICatalogo.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required]
    [StringLength(80)]
    public string? NomeProduto { get; set; }

    [Required]
    [StringLength(300)]
    public string? DescricaoProduto { get; set; }

    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
    [Required]
    public float Estoque { get; set; }

    [Required]
    public int PedidoId { get; set; }

    [JsonIgnore]
    public Pedido? Pedido { get; set; }
}
