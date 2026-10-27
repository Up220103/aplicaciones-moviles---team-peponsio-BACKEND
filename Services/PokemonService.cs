using MySql.Data.MySqlClient;
using MYBACK.Data;
using MYBACK.Models;
namespace MYBACK.Services;

// CRUD en la tabla "pokemon" con ADO.NET.
// Cada metodo: abre conexion -> prepara comando SQL -> agrega parametros -> ejecuta.
// "using" cierra la conexion sola al terminar.
public class PokemonService : IPokemonService
{
    private readonly ConexionDb _db;

    public PokemonService(ConexionDb db)
    {
        _db = db;
    }

    public List<Pokemon> ObtenerTodos()
    {
        var lista = new List<Pokemon>();
        using var conexion = _db.AbrirConexion();
        var comando = new MySqlCommand("SELECT * FROM pokemon ORDER BY numero", conexion);
        using var lector = comando.ExecuteReader();

        // Read() avanza fila por fila; cada fila se convierte en un Pokemon
        while (lector.Read())
        {
            lista.Add(new Pokemon
            {
                Id     = lector.GetInt32("id"),
                Numero = lector.GetInt32("numero"),
                Nombre = lector.GetString("nombre"),
                Tipo   = lector.GetString("tipo"),
                Altura = lector.GetDecimal("altura"),
                Peso   = lector.GetDecimal("peso"),
                Imagen = lector["imagen"] as string, // NULL de SQL -> null
            });
        }
        return lista;
    }

    // INSERT IGNORE: si el numero ya existe (UNIQUE) no inserta y regresa false
    public bool Crear(Pokemon pokemon)
    {
        using var conexion = _db.AbrirConexion();
        var comando = new MySqlCommand(
            @"INSERT IGNORE INTO pokemon (numero, nombre, tipo, altura, peso, imagen)
              VALUES (@numero, @nombre, @tipo, @altura, @peso, @imagen)", conexion);
        AgregarParametros(comando, pokemon);
        return comando.ExecuteNonQuery() > 0;
    }

    public bool Actualizar(int id, Pokemon pokemon)
    {
        using var conexion = _db.AbrirConexion();
        var comando = new MySqlCommand(
            @"UPDATE pokemon SET numero = @numero, nombre = @nombre, tipo = @tipo,
                     altura = @altura, peso = @peso, imagen = @imagen
              WHERE id = @id", conexion);
        AgregarParametros(comando, pokemon);
        comando.Parameters.AddWithValue("@id", id);
        return comando.ExecuteNonQuery() > 0;
    }

    public bool Eliminar(int id)
    {
        using var conexion = _db.AbrirConexion();
        var comando = new MySqlCommand("DELETE FROM pokemon WHERE id = @id", conexion);
        comando.Parameters.AddWithValue("@id", id);
        return comando.ExecuteNonQuery() > 0;
    }

    // Parametros que comparten Crear y Actualizar (evitan SQL injection)
    private static void AgregarParametros(MySqlCommand comando, Pokemon p)
    {
        comando.Parameters.AddWithValue("@numero", p.Numero);
        comando.Parameters.AddWithValue("@nombre", p.Nombre);
        comando.Parameters.AddWithValue("@tipo", p.Tipo);
        comando.Parameters.AddWithValue("@altura", p.Altura);
        comando.Parameters.AddWithValue("@peso", p.Peso);
        comando.Parameters.AddWithValue("@imagen", p.Imagen);
    }
}
