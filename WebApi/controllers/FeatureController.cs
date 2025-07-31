using BusinessLayer.Dto.Feature;
using BusinessLayer.Dto.Game;
using BusinessLayer.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeatureController : ControllerBase
{
    private readonly IGenericService<FeatureViewDto, FeatureCreateDto> _service;

    public FeatureController(IGenericService<FeatureViewDto, FeatureCreateDto> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FeatureViewDto>>> GetAll()
    {
        var features = await _service.GetAllAsync();
        return Ok(features);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FeatureViewDto>> GetById(uint id)
    {
        var feature = await _service.GetByIdAsync(id);
        if (feature == null) return NotFound();

        return Ok(new FeatureViewDto
        {
            Id = feature.Id,
            Name = feature.Name
        });
    }

    [HttpPost]
    public async Task<ActionResult> Create(FeatureCreateDto createDto)
    {
        FeatureViewDto viewDto = await _service.CreateAsync(createDto);

        return CreatedAtAction(nameof(GetById), new { id = viewDto.Id }, viewDto);
    }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(uint id, FeatureViewDto dto)
        {
            var feature = await _service.GetByIdAsync(id);
            if (feature == null) return NotFound();

            feature.Name = dto.Name;

            await _service.UpdateAsync(feature);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(uint id)
        {
            var feature = await _service.GetByIdAsync(id);
            if (feature == null) return NotFound();

            await _service.DeleteAsync(feature.Id);

            return NoContent();
        }
}