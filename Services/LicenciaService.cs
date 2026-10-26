using MYBACK.Models;
namespace MYBACK.Services;

public class LicenciaService : ILicenciaService
{
    private readonly Licencia _licencia = new Licencia
    {
        Nombre = "Bob Esponja Pantalones Cuadrados",
        NumeroLicencia = "FQ-000112",
        FechaNacimiento = "14/07/1986",
        FechaVencimiento = "14/07/2030",
        TipoLicencia = "Clase B",
        Direccion = "Piña 124, Fondo de Bikini",
        Estado = "Activa",
        Foto = "https://placekitten.com/150/150"
    };
    public Licencia ObtenerInfo() => _licencia;
}
