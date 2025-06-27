using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonStats
{
    public int Id { get; set; }
    
    [Display(Name = "Pontos de Vida")]
    public int Hp { get; set; }
    
    [Display(Name = "Ataque")]
    public int Atk { get; set; }
    
    [Display(Name = "Defesa")]
    public int Def { get; set; }
    
    [Display(Name = "Ataque Especial")]
    public int SpA { get; set; }
    
    [Display(Name = "Defesa Especial")]
    public int SpD { get; set; }
    
    [Display(Name = "Velocidade")]
    public int Speed { get; set; }
    
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    
    public Pokemon Pokemon { get; set; }
    
}