using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Tipo
{

    public enum Tipos
    {
        Normal,
        Fogo,
        Água,
        Eletricidade,
        Erva,
        Gelo,
        Lutador,
        Veneno,
        Terra,
        Voador,
        Psíquico,
        Inseto,
        Pedra,
        Fantasma,
        Dragão,
        Escuridão,
        Metal,
        Fada
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public Tipos Nome { get; set; }
    
    [Required]
    public string Cor { get; set; }
    
    [Required]
    public Tipos Fraquezas { get; set; }
    
    [Required]
    public Tipos? Resistências { get; set; }
    
    public Tipos? Imunidades { get; set; }
    
    public Tipos? Efetivo { get; set; }
    
    public ICollection<Pokemon> PokemonsPrimarios { get; set; }
    
    public ICollection<Pokemon> PokemonsSecundarios { get; set; }
}
