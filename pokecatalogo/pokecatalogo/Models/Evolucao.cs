using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Evolucao
{
    [Key]
    public int Id { get; set; }
    public string Descricao { get; set; }
    
    [Display(Name = "Pokemon Inicial")]
    [ForeignKey(nameof(PokemonOrigem))]
    public int PokemonFk1 { get; set; }
    public Pokemon PokemonOrigem { get; set; }
    
    [Display(Name = "Evolução")]
    [ForeignKey(nameof(PokemonEvoluido))]
    public int PokemonFk2 { get; set; }
    
    public Pokemon PokemonEvoluido { get; set; }
}