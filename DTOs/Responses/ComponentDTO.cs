namespace PcConfiguratorApi.DTOs.Responses;

public class ComponentDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Amount { get; set; }
}