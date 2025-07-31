using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using BusinessLayer.Services;
using BusinessLayer.Dto.Game;

namespace MVC.Controllers;

public class GameController : Controller
{
    private readonly ILogger<GameController> _logger;
    private readonly IGenericService<GameViewDto, GameCreateDto> _gameService;

    public GameController(ILogger<GameController> logger, IGenericService<GameViewDto, GameCreateDto> gameService)
    {
        _logger = logger;
        _gameService = gameService;
    }

    public async Task<IActionResult> Index()
    {
        var games = await _gameService.GetAllAsync();
        return View(games);
    }

    public async Task<IActionResult> Details(uint id)
    {
        var game = await _gameService.GetByIdAsync(id);
        if (game == null)
            return NotFound();

        return View(game);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
