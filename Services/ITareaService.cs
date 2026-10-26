using MYBACK.Models;
namespace MYBACK.Services;

// Contrato: indica qué debe hacer el servicio de tareas
public interface ITareaService
{
    IEnumerable<Tarea> ObtenerTodas();
    Tarea? ObtenerPorId(int id);
    Tarea Crear(Tarea tareaNueva);
    bool Actualizar(int id, Tarea tareaActualizada);
    bool Eliminar(int id);
}
