using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Tipo
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Nome { get; set; }
    
    [Required]
    public string Cor { get; set; }
    
    [Required]
    public string Fraquezas { get; set; }
    
    public ICollection<Pokemon> PokemonsPrimarios { get; set; }
    
    public ICollection<Pokemon> PokemonsSecundarios { get; set; }
}
