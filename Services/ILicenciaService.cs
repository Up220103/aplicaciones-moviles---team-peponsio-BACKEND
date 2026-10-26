using MYBACK.Models;
namespace MYBACK.Services;

// Contrato: indica qué debe hacer el servicio de licencia
public interface ILicenciaService
{
    Licencia ObtenerInfo();
}
