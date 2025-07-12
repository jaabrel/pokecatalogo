using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Tipo
{
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    public TiposEnum Nome { get; set; }
    
    [Required]
    public string Cor { get; set; }
    

    public List<TiposEnum> Fraquezas { get; set; } = new();

    public List<TiposEnum> Resistências { get; set; } = new();
    
    public List<TiposEnum> Imunidades { get; set; } = new();
    
    /// <summary>
    /// List of types this type is effective against (Efetivo). Nullable if none.
    /// </summary>
    public List<TiposEnum>? Efetivo { get; set; }
    
    public ICollection<Pokemon> Pokemons { get; set; }
    
}

public enum TiposEnum
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