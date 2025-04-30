namespace pokecatalogo.Models;

public class PokemonTipo
{
    public int PokemonFk { get; set; }
    public Pokemon Pokemon { get; set; }
    
    public int TipoFk1 { get; set; }
    public Tipo Tipo1 { get; set; }
    
    public int TipoFk2 { get; set; }
    public Tipo Tipo2 { get; set; }
}