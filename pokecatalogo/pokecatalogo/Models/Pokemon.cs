using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Pokemon
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Nome")]
    public string Name { get; set; }
    
    public ICollection<PokemonAtaque> PokemonAtaques { get; set; }
    public ICollection<PokemonTipo> PokemonTipos { get; set; }
    public ICollection<PokemonHabilidades> PokemonHabilidades { get; set; }
    
    public int LocalizacaoId { get; set; }
    public Localizacao Localizacao { get; set; }
    
    public ICollection<Evolucao> Evolucoes { get; set; }
}