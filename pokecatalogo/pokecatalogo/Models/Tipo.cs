using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Tipo
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Fraquezas { get; set; }
    
    public ICollection<Pokemon> PokemonsPrimarios { get; set; }
    
    public ICollection<Pokemon> PokemonsSecundarios { get; set; }
}