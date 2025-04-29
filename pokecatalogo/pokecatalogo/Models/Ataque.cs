using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Ataque
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public ICollection<PokemonAtaque> PokemonAtaques { get; set; }
}