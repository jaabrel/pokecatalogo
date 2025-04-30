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
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }
    public ICollection<Evolucao> Evolucoes { get; set; }
    public ICollection<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
    
    
}