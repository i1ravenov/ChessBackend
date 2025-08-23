using ChessEngine;
using ChessEngine.Entity;

namespace ChessBackend;

public class GameService
{
    private readonly Dictionary<Guid, Game> _games = new();

    public Guid CreateGame()
    {
        var id = Guid.NewGuid();
        _games[id] = new Game();
        return id;
    }

    public Game? GetGame(Guid id) =>
        _games.TryGetValue(id, out var game) ? game : null;

    public MoveResult MakeMove(Guid id, string from, string to)
    {
        if (!_games.TryGetValue(id, out var game))
            return MoveResult.Fail("Game not found");

        var result = game.MakeMove(new Square(from), new Square(to));
        return result;
    }
}