using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Habilidade
{
    public int Id { get; set; }
    public string nome { get; set; }
    
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    public Pokemon Pokemon { get; set; }
    
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }
}