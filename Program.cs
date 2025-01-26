using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

var builder = WebApplication.CreateBuilder(args);

// Dodajemy usługę CORS
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowAll",
//         policy =>
//         {
//             policy.AllowAnyOrigin()  // Zezwala na dostęp z każdej domeny
//                   .AllowAnyMethod()  // Zezwala na wszystkie metody (GET, POST, itd.)
//                   .AllowAnyHeader(); // Zezwala na wszystkie nagłówki
//         });
// });

var app = builder.Build();

// app.UseCors("AllowAll");

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
