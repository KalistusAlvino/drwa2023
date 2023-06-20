using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]                                                                                         
[Route("api/[controller]")]
public class GurusController : ControllerBase
{

    // / <response code="201">Returns the newly created item</response>
    // / <response code="400">If the item is null</response>
    // / <response code="401">If the item is Unauthorized</response>
    // / <response code="404">If the item is not Found</response>
    // / <response code="500">Internal server Error</response>
    private readonly GuruService _gurusService;

    public gurusController(GuruService gurusService) =>
        _guruService = gurusService;

    [HttpGet]
    // [Authorize]
    public async Task<List<Guru>> Get() =>
        await _gurusService.GetAsync();

    
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var guru = await _gurusService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

   // [HttpPost]
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _gurusService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string nip, Guru updatedGuru)
    {
        var guru = await _gurusService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.Nip = book.Nip;

        await _gurusService.UpdateAsync(nip, updatedGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string nip)
    {
        var guru = await _gurusService.GetAsync(nip);

        if (guru is null)
        {
            return NotFound();
        }

        await _gurusService.RemoveAsync(nip);

        return NoContent();
    }
}