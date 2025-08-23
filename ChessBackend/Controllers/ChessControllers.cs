using Microsoft.AspNetCore.Mvc;
using ChessBackend;
using ChessEngine;         // For MoveResult
using ChessEngine.Entity; // For Game if you want to return it

namespace ChessBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly GameService _games;

    public GamesController(GameService games) => _games = games;

    // POST api/games
    [HttpPost]
    public IActionResult Create()
    {
        var id = _games.CreateGame();
        // Return 201 with a Location header to fetch state
        return CreatedAtAction(nameof(Get), new { id }, new { GameId = id });
    }

    // GET api/games/{id}
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var game = _games.GetGame(id);
        if (game is null) return NotFound(new { message = "Game not found" });

        // Shape the response as you like (FEN, whose turn, etc.)
        return Ok(new
        {
            GameId = id,
            Fen = game.(),         // assuming your Game exposes this
            Turn = game.CurrentTurn,     // adjust to your actual API
            Status = "active"
        });
    }

    // POST api/games/{id}/move
    [HttpPost("{id:guid}/move")]
    public IActionResult Move(Guid id, [FromBody] MakeMoveDto dto)
    {
        if (dto is null || string.IsNullOrWhiteSpace(dto.From) || string.IsNullOrWhiteSpace(dto.To))
            return BadRequest(new { message = "from/to are required" });

        var result = _games.MakeMove(id, dto.From, dto.To);

        if (!result.Success)
            return BadRequest(new { message = result.Message }); // or 409 if illegal move

        // Optionally return the updated FEN or move info
        return Ok(new
        {
            Success = true,
            San = result.SAN,          // if your MoveResult has SAN
            Fen = result.FEN,          // or compute from Game again
            Checkmate = result.IsMate, // adapt to your MoveResult
        });
    }
}

public record MakeMoveDto(string From, string To);
