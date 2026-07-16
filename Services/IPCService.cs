using PcConfiguratorApi.DTOs.Requests;
using PcConfiguratorApi.DTOs.Responses;

namespace PcConfiguratorApi.Services;

public interface IPCService
{
    Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync();
    Task<PCDetailsResponseDTO?> GetPCDetailsAsync(int id);
    Task<PCResponseDTO> CreatePCAsync(PCCreateRequestDTO request);
    Task<bool> UpdatePCAsync(int id, PCUpdateRequestDTO request);
    Task<bool> DeletePCAsync(int id);
}