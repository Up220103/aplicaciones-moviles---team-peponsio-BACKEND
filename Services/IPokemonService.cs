using MYBACK.Models;
namespace MYBACK.Services;

// Contrato: CRUD de pokemones en MySQL
public interface IPokemonService
{
    List<Pokemon> ObtenerTodos();
    bool Crear(Pokemon pokemon);              // false si el numero ya existe
    bool Actualizar(int id, Pokemon pokemon); // false si no existe el id
    bool Eliminar(int id);                    // false si no existe el id
}
