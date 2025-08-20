namespace ChessEngine;

public record MoveResult(bool Success, string? Error)
{
    public static MoveResult Ok() => new(true, null);
    public static MoveResult Fail(string error) => new(false, error);
}