using MYBACK.Models;
using MYBACK.Services;

namespace MYBACK.Endpoints;

// Rutas del CRUD (apuntan a MySQL). Las consume services/PokemonDbService.js de la app.
public static class PokemonEndpoints
{
    public static void MapPokemonEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/pokemon");

        group.MapGet("/", (IPokemonService service) =>
            Results.Ok(service.ObtenerTodos()));

        group.MapPost("/", (Pokemon nuevo, IPokemonService service) =>
            service.Crear(nuevo)
                ? Results.Created()
                : Results.Conflict(new { message = "Ese numero ya existe" }));

        group.MapPut("/{id}", (int id, Pokemon pokemon, IPokemonService service) =>
            service.Actualizar(id, pokemon) ? Results.NoContent() : Results.NotFound());

        group.MapDelete("/{id}", (int id, IPokemonService service) =>
            service.Eliminar(id) ? Results.NoContent() : Results.NotFound());

        // Llena la BD: GET a PokeAPI y guarda cada uno (los repetidos se ignoran)
        group.MapPost("/importar", async (IPokeApiService pokeApi, IPokemonService service) =>
        {
            var pokemones = await pokeApi.ObtenerPokemones(151);
            var guardados = pokemones.Count(p => service.Crear(p));
            return Results.Ok(new { message = $"Se guardaron {guardados} pokemones nuevos" });
        });
    }
}
