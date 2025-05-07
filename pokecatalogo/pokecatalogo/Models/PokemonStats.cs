using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonStats
{
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int FkPokemon { get; set; }
    
    
    public int Hp { get; set; }
    public int Atk { get; set; }
    public int Def { get; set; }
    public int SpA { get; set; }
    public int SpD { get; set; }
    public int Speed { get; set; }
}