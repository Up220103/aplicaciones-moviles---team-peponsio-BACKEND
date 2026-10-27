using MYBACK.Models;
namespace MYBACK.Services;

// Contrato: trae pokemones de la API publica PokeAPI
public interface IPokeApiService
{
    Task<List<Pokemon>> ObtenerPokemones(int cantidad);
}
