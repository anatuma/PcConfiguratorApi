using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcConfiguratorApi.Models;

[Table("Components")]
public class Component
{
    [Key]
    [Column(TypeName = "char(10)")]
    public string Code  { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(300)")]
    public string Name { get; set; } = string.Empty;
    [Column(TypeName = "nvarchar(max)")]
    public string Description { get; set; } = string.Empty;
    
    public int ComponentManufacturersId { get; set; }

    [ForeignKey("ComponentManufacturersId")]
    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;
    
    public int ComponentTypesId { get; set; }
    [ForeignKey("ComponentTypesId")] public ComponentType ComponentType { get; set; } = null!;
    
    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}