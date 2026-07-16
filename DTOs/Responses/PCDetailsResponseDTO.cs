namespace PcConfiguratorApi.DTOs.Responses;

public class PCDetailsResponseDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<ComponentDto> Components { get; set; } = new();
}