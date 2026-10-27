namespace MYBACK.Models;

// Modelo de lo que RESPONDE PokeAPI (GET /pokemon/{numero}).
// Solo se declaran los campos que usamos; los demas se ignoran.
// Los nombres van igual que en el JSON (name, height...) para que se llenen solos.
public record PokeApiPokemon(string name, int height, int weight, List<PokeApiTipo> types);
public record PokeApiTipo(PokeApiNombre type);
public record PokeApiNombre(string name);
