using DataAccess.Db;
using Domain.Entities;
using GameDto = BusinessLayer.Dto.Game;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLayer.Interfaces;

namespace WebApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository _repo;

        public GameController(IGameRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
        {
            var games = await _repo.GetAllAsync();

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GameDto>> GetById(uint id)
        {
            var game = await _repo.GetByIdAsync(id);
            if (game == null) return NotFound();

            return Ok(new GameDto
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
        public async Task<IActionResult> Create(GameDto dto)
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

            await _repo.AddAsync(game);

            return CreatedAtAction(nameof(GetById), new { id = game.Id }, game);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(uint id, GameDto dto)
        {
            var game = await _repo.GetByIdAsync(id);
            if (game == null) return NotFound();

            game.Title = dto.Title;
            game.Slug = dto.Slug;
            game.Description = dto.Description;
            game.WebGLPath = dto.WebGLPath;
            game.CoverImagePath = dto.CoverImagePath;

            await _repo.UpdateAsync(game);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(uint id)
        {
            var game = await _repo.GetByIdAsync(id);
            if (game == null) return NotFound();

            await _repo.DeleteAsync(game.Id);

            return NoContent();
        }
    }
}