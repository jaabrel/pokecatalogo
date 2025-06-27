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
    

    public TiposEnum Fraquezas { get; set; }

    public TiposEnum? Resistências { get; set; }
    
    public TiposEnum? Imunidades { get; set; }
    
    public TiposEnum? Efetivo { get; set; }
    
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