using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/greet", (HttpRequest request) =>
{
    // Pobranie parametru 'name' z zapytania
    var name = request.Query["name"].ToString();

    // Sprawdzenie, czy parametr 'name' został podany
    if (string.IsNullOrEmpty(name))
    {
        return Results.BadRequest(new { error = "Brak parametru 'name'" });
    }

    // Przygotowanie odpowiedzi
    var currentDate = DateTime.Now.ToString("yyyy-MM-dd");
    var message = $"Cześć, {name}, dziś jest {currentDate}";

    return Results.Json(new { message });
});

app.Run();
