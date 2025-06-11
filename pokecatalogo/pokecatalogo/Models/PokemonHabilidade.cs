using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonHabilidade
{
    public int Id { get; set; }
    
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    
    public Pokemon Pokemon { get; set; }
    
    [Display(Name = "Habilidade")]
    [ForeignKey(nameof(Habilidade))]
    public int HabilidadeFk { get; set; }
    
    public Habilidade Habilidade { get; set; }
}