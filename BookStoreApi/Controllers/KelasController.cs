using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]                                                                                         
[Route("api/[controller]")]
public class KelasController : ControllerBase
{

    private readonly KelasService _kelasService;

    public gurusController(KelasService kelasService) =>
        _kelasService = kelasService;

    [HttpGet]
    // [Authorize]
    public async Task<List<Kelas>> Get() =>
        await _kelasService.GetAsync();

    
    [HttpGet("{id:length(24)}")]
    // [Authorize]
    public async Task<ActionResult<Kelas>> Get(string id)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        return kelas;
    }

   // [HttpPost]
    [HttpPost]
    // [Authorize]
    public async Task<IActionResult> Post(Kelas newKelas)
    {
        await _kelasService.CreateAsync(newKelas);

        return CreatedAtAction(nameof(Get), new { id = newKelas.Id }, newKelas);
    }

    [HttpPut("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Update(string id, Kelas updatedKelas)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        updatedKelas.Id = kelas.Id;

        await _kelasService.UpdateAsync(id, updatedKelas);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    // [Authorize]
    public async Task<IActionResult> Delete(string id)
    {
        var kelas = await _kelasService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _kelasService.RemoveAsync(id);

        return NoContent();
    }
}