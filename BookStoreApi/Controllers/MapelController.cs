using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]                                                                                         
[Route("api/[controller]")]
public class MapelController : ControllerBase
{
    private readonly MapelService _mapelService;

    public gurusController(GuruService gurusService) =>
        _mapelService = mapelsService;

    [HttpGet]
    // [Authorize]
    public async Task<List<Mapel>> Get() =>
        await _mapelService.GetAsync();

    
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    public async Task<ActionResult<Mapel>> Get(string id)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        return mapel;
    }

   // [HttpPost]
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> Post(Mapel newMapel)
    {
        await _mapelService.CreateAsync(newMapel);

        return CreatedAtAction(nameof(Get), new { id = newMapel.Id }, newMapel);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string id, Mapel updatedMapel)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        updatedMapel.Id = Mapel.Id;

        await _mapelService.UpdateAsync(id, updatedMapel);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var mapel = await _mapelService.GetAsync(id);

        if (mapel is null)
        {
            return NotFound();
        }

        await _mapelService.RemoveAsync(id);

        return NoContent();
    }
}