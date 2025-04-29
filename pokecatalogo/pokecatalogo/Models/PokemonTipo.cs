namespace pokecatalogo.Models;

public class PokemonTipo
{
    public int PokemonId { get; set; }
    public int TipoId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Tipo Tipo { get; set; }
}