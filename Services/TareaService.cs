using MYBACK.Models;
namespace MYBACK.Services;

public class TareaService : ITareaService
{
    private readonly List<Tarea> _tareas = new (){
            new Tarea { Id = 1, Titulo = "Tarea 1", Descripcion = "Descripción de la tarea 1", Completada = false },
            new Tarea { Id = 2, Titulo = "Tarea 2", Descripcion = "Descripción de la tarea 2", Completada = true },
            new Tarea { Id = 3, Titulo = "Tarea 3", Descripcion = "Descripción de la tarea 3", Completada = false }
    };
    public IEnumerable<Tarea> ObtenerTodas() => _tareas;
    public Tarea? ObtenerPorId(int id)
    {
        return _tareas.FirstOrDefault(t => t.Id == id);
    }
    public Tarea Crear(Tarea tareaNueva)
    {
        tareaNueva.Id = _tareas.Count > 0 ? _tareas.Max(t => t.Id) + 1 : 1;
        _tareas.Add(tareaNueva);
        return tareaNueva;
    }

    public bool Actualizar(int id, Tarea tareaActualizada)
    {
        var tareaExistente = ObtenerPorId(id);
        if (tareaExistente == null) return false;
        tareaExistente.Titulo = tareaActualizada.Titulo;
        tareaExistente.Descripcion = tareaActualizada.Descripcion;
        tareaExistente.Completada = tareaActualizada.Completada;
        return true;
    }

    // Nuevo: busca la tarea y la quita de la lista
    public bool Eliminar(int id)
    {
        var tareaExistente = ObtenerPorId(id);
        if (tareaExistente == null) return false;
        _tareas.Remove(tareaExistente);
        return true;
    }
}
