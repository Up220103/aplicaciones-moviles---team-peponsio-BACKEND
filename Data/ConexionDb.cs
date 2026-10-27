using MySql.Data.MySqlClient;

namespace MYBACK.Data;

// Conexion a MySQL con ADO.NET.
// La cadena NO esta en el codigo: se lee de user-secrets (no se sube a Git).
public class ConexionDb
{
    private readonly string _cadena;

    public ConexionDb(IConfiguration configuracion)
    {
        _cadena = configuracion.GetConnectionString("PokedexDb")
            ?? throw new InvalidOperationException("Falta 'PokedexDb' en user-secrets");
    }

    // Crea y abre una conexion nueva
    public MySqlConnection AbrirConexion()
    {
        var conexion = new MySqlConnection(_cadena);
        conexion.Open();
        return conexion;
    }
}
