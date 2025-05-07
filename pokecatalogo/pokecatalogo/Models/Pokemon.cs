using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Pokemon
{
    [Key] 
    public int Id { get; set; }

    [Display(Name = "Nome")] 
    public string Nome { get; set; }

    [Display(Name = "Tipo Principal")]
    [ForeignKey(nameof(Tipo1))]
    public int Tipo1Fk { get; set; }

    public Tipo Tipo1 { get; set; }

    [Display(Name = "Tipo Secundário")]
    [ForeignKey(nameof(Tipo2))]
    public int? Tipo2Fk { get; set; }

    public Tipo Tipo2 { get; set; }

    public ICollection<PokemonAtaque> PokemonAtaques { get; set; }
    
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public ICollection<Evolucao> OrigemEvolucoes { get; set; }
    
    public ICollection<Evolucao> FinalEvolucoes { get; set; }
    
    public ICollection<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
}
