using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]                                                                                         
[Route("api/[controller]")]
public class PresesiHarianGuruController : ControllerBase
{

    private readonly PresesiHarianGuruService _presensiHarianGuruService;

    public gurusController(PresesiHarianGuruService presensiHarianGuruService) =>
        _presensiHarianGuruService = presensiHarianGuruService;

    [HttpGet]
    // [Authorize]
    public async Task<List<PresesiHarianGuru>> Get() =>
        await _presensiHarianGuruService.GetAsync();

    
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    public async Task<ActionResult<PresesiHarianGuru>> Get(string nip)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(nip);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        return presensiHarianGuru;
    }

   // [HttpPost]
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> Post(PresesiHarianGuru newPresensiHarianGuru)
    {
        await _presensiHarianGuruService.CreateAsync(newPresensiHarianGuru);

        return CreatedAtAction(nameof(Get), new { nip = newPresensiHarianGuru.Nip }, newPresensiHarianGuru);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string nip, PresesiHarianGuru updatedPresensiHarianGuru)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(nip);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        updatedPresensiHarianGuru.Nip = presensiHarianGuru.Nip;

        await _presensiHarianGuruService.UpdateAsync(nip, updatedPresensiHarianGuru);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string nip)
    {
        var presensiHarianGuru = await _presensiHarianGuruService.GetAsync(nip);

        if (presensiHarianGuru is null)
        {
            return NotFound();
        }

        await _presensiHarianGuruService.RemoveAsync(nip);

        return NoContent();
    }
}