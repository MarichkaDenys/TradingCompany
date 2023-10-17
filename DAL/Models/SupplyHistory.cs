using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

[Table("SupplyHistory")]
public partial class SupplyHistory
{
    [Key]
    [Column("SupplyHistoryID")]
    public int SupplyHistoryId { get; set; }

    [ForeignKey("PersonId")]
    public virtual Person Person { get; set; } = null!;

    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; } = null!;

    [StringLength(200)]
    public string Action { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }
}
