using Microsoft.AspNetCore.Mvc;

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
        return CreatedAtAction(nameof(Get), new { id }, new { GameId = id });
    }

    // GET api/games/{id}
    [HttpGet("{id:guid}")]
    public IActionResult Get(Guid id)
    {
        var game = _games.GetGame(id);
        if (game is null) return NotFound(new { message = "Game not found" });

        return Ok(new
        {
            GameId = id,
            Fen = game.ToFen(),
            Turn = game.NextTurn,
            Status = "active"
        });
    }

    // POST api/games/{id}/move
    [HttpPost("{id:guid}/move")]
    public IActionResult Move(Guid id, [FromBody] MakeMoveDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.From) || string.IsNullOrWhiteSpace(dto.To))
            return BadRequest(new { message = "from/to are required" });

        var result = _games.MakeMove(id, dto.From, dto.To);

        if (!result.Success)
            return BadRequest(new { message = "Illegal move" }); // or 409 if illegal move

        return Ok(new
        {
            Success = true,
            Fen = _games.GetGame(id)?.ToFen(),
        });
    }
}

public record MakeMoveDto(string From, string To);
