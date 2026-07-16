using Microsoft.AspNetCore.Mvc;
using PcConfiguratorApi.DTOs.Requests;
using PcConfiguratorApi.Services;

namespace PcConfiguratorApi.Controllers;

[ApiController]
[Route("api/pcs")]
public class PCController : ControllerBase
{
    private readonly IPCService _pcService;
    
    public PCController(IPCService pcService)
    {
        _pcService = pcService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllPCs()
    {
        var pcs = await _pcService.GetAllPCsAsync();
        return Ok(pcs);
    }


    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetPCDetails(int id)
    {
        var pcDetails = await _pcService.GetPCDetailsAsync(id);
        if (pcDetails == null)
            return NotFound($"Computer with Id {id} not found");
            
        return Ok(pcDetails);
    }


    [HttpPost]
    public async Task<IActionResult> CreatePC([FromBody] PCCreateRequestDTO request)
    {
        var createdPc = await _pcService.CreatePCAsync(request);
        return Created($"/api/pcs/{createdPc.Id}/components", createdPc);
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePC(int id, [FromBody] PCUpdateRequestDTO request)
    {
        bool isUpdated = await _pcService.UpdatePCAsync(id, request);
        if (!isUpdated)
        {
            return NotFound($"Cannot update. Computer with Id {id} does not exist.");
        }
        
        return Ok(new { message = $"PC with Id {id} updated successfully." });
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePC(int id)
    {
        bool isDeleted = await _pcService.DeletePCAsync(id);
        if (!isDeleted)
        {
            return NotFound($"Cannot delete. Computer with Id {id} does not exist.");
        }
        
        return NoContent();
    }
}