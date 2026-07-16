using Microsoft.EntityFrameworkCore;
using PcConfiguratorApi.Contexts;
using PcConfiguratorApi.DTOs.Requests;
using PcConfiguratorApi.DTOs.Responses;
using PcConfiguratorApi.Models;

namespace PcConfiguratorApi.Services;

public class PCService : IPCService
{
    private readonly AppDbContext _dbContext;
    public PCService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<PCResponseDTO>> GetAllPCsAsync()
    {
        return await _dbContext.PCs
            .Select(p => new PCResponseDTO
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }

    public async Task<PCDetailsResponseDTO?> GetPCDetailsAsync(int id)
    {
        var pc = await _dbContext.PCs
            .Include(p => p.PCComponents)
                .ThenInclude(pcc => pcc.Component)
            .FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null) return null;

        return new PCDetailsResponseDTO
        {
            Id = pc.Id,
            Name = pc.Name,
            Components = pc.PCComponents.Select(pcc => new ComponentDto
            {
                Code = pcc.ComponentCode,
                Name = pcc.Component.Name,
                Amount = pcc.Amount
            }).ToList()
        };
    }

    public async Task<PCResponseDTO> CreatePCAsync(PCCreateRequestDTO request)
    {
        var pc = new PC
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };
        
        await _dbContext.PCs.AddAsync(pc);
        await _dbContext.SaveChangesAsync();

        return new PCResponseDTO
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> UpdatePCAsync(int id, PCUpdateRequestDTO request)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null) return false;
        pc.Name = request.Name;
        pc.Weight = request.Weight;
        pc.Warranty = request.Warranty;
        pc.CreatedAt = request.CreatedAt;
        pc.Stock = request.Stock;
        
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeletePCAsync(int id)
    {
        var pc = await _dbContext.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc == null) return false;
        _dbContext.PCs.Remove(pc);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}