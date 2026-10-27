using MYBACK.Models;
namespace MYBACK.Services;

// Hace GET a https://pokeapi.co y convierte la respuesta a nuestro modelo Pokemon.
// No toca la base de datos: eso lo hace PokemonService.
public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _http;

    // HttpClient ya trae la URL base (se configura en Program.cs)
    public PokeApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Pokemon>> ObtenerPokemones(int cantidad)
    {
        var lista = new List<Pokemon>();
        for (int numero = 1; numero <= cantidad; numero++)
        {
            // GET /pokemon/{numero}; el JSON se convierte solo a PokeApiPokemon
            var p = await _http.GetFromJsonAsync<PokeApiPokemon>($"pokemon/{numero}");

            // Mapeo: modelo de PokeAPI -> modelo de nuestra tabla
            lista.Add(new Pokemon
            {
                Numero = numero,
                Nombre = p!.name,
                Tipo   = string.Join(", ", p.types.Select(t => t.type.name)),
                Altura = p.height / 10m,  // decimetros -> metros
                Peso   = p.weight / 10m,  // hectogramos -> kilos
                Imagen = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{numero}.png",
            });
        }
        return lista;
    }
}
