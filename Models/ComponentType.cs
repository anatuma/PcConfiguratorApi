using System.ComponentModel.DataAnnotations.Schema;

namespace PcConfiguratorApi.Models;

[Table("ComponentTypes")]
public class ComponentType
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; } = string.Empty;

    public ICollection<Component> Components { get; set; } = new List<Component>();
}