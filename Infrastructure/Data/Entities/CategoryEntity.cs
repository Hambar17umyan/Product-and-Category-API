using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

[Table("categories")]
public class CategoryEntity : IEntity
{
    [Key]
    [Column("category_id")]
    public int Id { get; set; }

    [Column("category_name")]
    public string Name { get; set; }

    [Column("category_description")]
    public string Description { get; set; }
}
