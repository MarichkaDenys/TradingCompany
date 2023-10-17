using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [Column("CategoryID")]
    public int CategoryId { get; set; }

    [StringLength(200)]
    public string ProductName { get; set; } = null!;

    public int Quantity { get; set; }

    public int UnitPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual Category Category { get; set; } = null!;
}
