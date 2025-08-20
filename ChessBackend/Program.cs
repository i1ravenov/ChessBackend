using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Register your services (ChessEngine lives as a library)
builder.Services.AddSingleton<GameService>();

var app = builder.Build();

// Minimal API endpoints
app.MapPost("/games", (GameService svc) =>
{
    var id = svc.CreateGame();
    return Results.Created($"/games/{id}", new { id });
});

app.MapGet("/games/{id}", (GameService svc, Guid id) =>
{
    var game = svc.GetGame(id);
    return game is null ? Results.NotFound() : Results.Ok(game);
});

app.MapPost("/games/{id}/moves", (GameService svc, Guid id, MoveDto move) =>
{
    var result = svc.MakeMove(id, move.From, move.To);
    return result.Success ? Results.Ok(result) : Results.BadRequest(result.Error);
});

app.Run();

public record MoveDto(string From, string To);