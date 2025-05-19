using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities;

[Table("products")]
public class ProductEntity : IEntity
{
    [Key]
    [Column("product_id")]
    public int Id { get; set; }

    [Column("product_name")]
    public string Name { get; set; }

    [Column("product_category1_id")]
    [ForeignKey(nameof(Category1))]
    public int Category1Id { get; set; }

    [Column("product_category2_id")]
    [ForeignKey(nameof(Category2))]
    public int Category2Id { get; set; }

    [Column("product_category3_id")]
    [ForeignKey(nameof(Category3))]
    public int? Category3Id { get; set; }

    public CategoryEntity Category1 { get; set; }

    public CategoryEntity Category2 { get; set; }

    public CategoryEntity? Category3 { get; set; }
}
