using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonAtaque
{
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    
    public Pokemon Pokemon { get; set; }
    
    [Display(Name = "Ataque")]
    [ForeignKey(nameof(Ataque))]
    public int AtaqueFk { get; set; }
    
    public Ataque Ataque { get; set; }
}