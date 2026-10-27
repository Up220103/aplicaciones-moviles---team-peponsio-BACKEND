namespace MYBACK.Models;

public class Pokemon
{
    public int     Id     { get; set; }
    public int     Numero { get; set; }
    public string  Nombre { get; set; } = string.Empty;
    public string  Tipo   { get; set; } = string.Empty;
    public decimal Altura { get; set; }
    public decimal Peso   { get; set; }
    public string? Imagen { get; set; }   
}
