using MYBACK.Services;

namespace MYBACK.Endpoints;

public static class LicenciaEndpoints
{
    public static void MapLicenciaEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/licencia");
        group.MapGet("/", (ILicenciaService Service) =>
        {
            var licencia = Service.ObtenerInfo();
            return Results.Ok(licencia);
        });
    }
}
