using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PcConfiguratorApi.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponent
{
    public int PCId { get; set; }
    public PC Pc { get; set; } = null!;
    
    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; } = string.Empty;

    public Component Component { get; set; } = null!;
    
    public int Amount { get; set; }
}