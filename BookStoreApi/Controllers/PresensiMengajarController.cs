using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]                                                                                         
[Route("api/[controller]")]
public class PresensiMengajarController : ControllerBase
{

    private readonly PresensiMengajarService _presensiMengajarService;

    public gurusController(PresensiMengajar presensiMengajarService) =>
        _presensiMengajarService = presensiMengajarService;

    [HttpGet]
    // [Authorize]
    public async Task<List<PresensiMengajar>> Get() =>
        await _presensiMengajarService.GetAsync();

    
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    public async Task<ActionResult<Guru>> Get(string nip)
    {
        var presensiMengajar = await _presensiMengajarService.GetAsync(nip);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        return presensiMengajar;
    }

   // [HttpPost]
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> Post(PresensiMengajar newPresensiMengajar)
    {
        await _presensiMengajarService.CreateAsync(newPresensiMengajar);

        return CreatedAtAction(nameof(Get), new { nip = newPresensiMengajar.Nip }, newPresensiMengajar);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string nip, PresensiMengajar updatedPresensiMengajar)
    {
        var presensiMengajar = await _presensiMengajarService.GetAsync(nip);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        updatedPresensiMengajar.Nip = presensiMengajar.Nip;

        await _presensiHarianGuruService.UpdateAsync(nip, updatedPresensiMengajar);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string nip)
    {
        var presensiMengajar = await _presensiMengajarService.GetAsync(nip);

        if (presensiMengajar is null)
        {
            return NotFound();
        }

        await _presensiMengajarService.RemoveAsync(nip);

        return NoContent();
    }
}