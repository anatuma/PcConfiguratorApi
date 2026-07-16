using System.ComponentModel.DataAnnotations.Schema;

namespace PcConfiguratorApi.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturer
{
    public int Id { get; set; }
    
    [Column(TypeName = "nvarchar(30)")]
    public string Abbreviation { get; set; } = string.Empty;
    
    [Column(TypeName = "nvarchar(300)")]
    public string FullName { get; set; } = string.Empty;
    
    [Column(TypeName = "date")]
    public DateTime FoundationDate { get; set; }
    
    public ICollection<Component> Components { get; set; } = new List<Component>();
}