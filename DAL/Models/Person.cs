using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL;

[Table("Person")]
public partial class Person
{
    [Key]
    [Column("PersonID")]
    public int PersonId { get; set; }

    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(200)]
    public string FirstName { get; set; } = null!;

    [StringLength(200)]
    public string LastName { get; set; } = null!;

    [StringLength(200)]
    public string Login { get; set; } = null!;

    [StringLength(200)]
    public string Password { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime Date { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("People")]
    public virtual Role Role { get; set; } = null!;
}
