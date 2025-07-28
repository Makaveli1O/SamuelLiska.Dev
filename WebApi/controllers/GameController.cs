using Domain.Entities;
using BusinessLayer.Dto.Game;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _service;

        public GameController(IGameRepository service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewDto>>> GetAll()
        {
            var games = await _service.GetAllAsync();

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameViewDto>> GetById(uint id)
        {
            var game = await _service.GetByIdAsync(id);
            if (game == null) return NotFound();

            return Ok(new GameViewDto
            {
                Id = game.Id,
                Title = game.Title,
                Slug = game.Slug,
                Description = game.Description,
                WebGLPath = game.WebGLPath,
                CoverImagePath = game.CoverImagePath
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(GameViewDto dto)
        {
            var game = new Game
            {
                Id = 1,
                Title = dto.Title,
                Slug = dto.Slug,
                Description = dto.Description,
                WebGLPath = dto.WebGLPath,
                CoverImagePath = dto.CoverImagePath
            };

            await _service.AddAsync(game);

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(uint id, GameViewDto dto)
        {
            var game = await _service.GetByIdAsync(id);
            if (game == null) return NotFound();

            game.Title = dto.Title;
            game.Slug = dto.Slug;
            game.Description = dto.Description;
            game.WebGLPath = dto.WebGLPath;
            game.CoverImagePath = dto.CoverImagePath;

            await _service.UpdateAsync(game);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(uint id)
        {
            var game = await _service.GetByIdAsync(id);
            if (game == null) return NotFound();

            await _service.DeleteAsync(game.Id);

            return NoContent();
        }
    }
}