using MYBACK.Endpoints;
using MYBACK.Services;
using MYBACK.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddSingleton<ITareaService, TareaService>();
builder.Services.AddSingleton<ILicenciaService, LicenciaService>();

// Pokedex con MySQL (ADO.NET). La cadena de conexion viene de user-secrets.
builder.Services.AddSingleton<ConexionDb>();
builder.Services.AddScoped<IPokemonService, PokemonService>();
// HttpClient para hacer GET a PokeAPI y llenar la base de datos
builder.Services.AddHttpClient<IPokeApiService, PokeApiService>(client =>
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.MapTareasEndpoints();
app.MapLicenciaEndpoints();
app.MapPokemonEndpoints();

app.Run();
