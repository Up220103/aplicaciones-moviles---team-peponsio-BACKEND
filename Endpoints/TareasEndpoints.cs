using MYBACK.Models;
using MYBACK.Services;

namespace MYBACK.Endpoints;

public static class TareasEndpoints
{
    public static void MapTareasEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/tareas");
        group.MapGet("/", (ITareaService Service) =>
        {
            var tareas = Service.ObtenerTodas();
            return Results.Ok(tareas);
        });

        group.MapGet("/{id}", (int id, ITareaService Service) =>
        {
            var tarea = Service.ObtenerPorId(id);
            return tarea is null
                ? Results.NotFound(new { message = $"Tarea con id {id} no encontrada" })
                : Results.Ok(tarea);
        });
        group.MapPost("/", (Tarea tareaNueva, ITareaService Service) =>
        {
            var tareaCreada = Service.Crear(tareaNueva);
            return Results.Created($"/tareas/{tareaCreada.Id}", tareaCreada);
        });

        group.MapPut("/{id}", (int id, Tarea tarea, ITareaService Service) =>
        {
            return Service.Actualizar(id, tarea)
               ? Results.NoContent()
               : Results.NotFound(new { message = $"Tarea con id {id} no encontrada" });
        });

        group.MapDelete("/{id}", (int id, ITareaService Service) =>
        {
            return Service.Eliminar(id)
                ? Results.NoContent()
                : Results.NotFound(new { message = $"Tarea con id {id} no encontrada" });
        });
    }
}
