using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Pokemon
{
    [Key] 
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    [Display(Name = "Descrição Pokedex")]
    public string DescricaoPokedex { get; set; }
    
    public float Altura { get; set; }
    
    public float Peso { get; set; }

    [Display(Name = "Espécie")]
    public string Especie { get; set; }
    
    [Display(Name = "Tipo Principal")]
    [ForeignKey(nameof(TipoPrincipal))]
    public int Tipo1Fk { get; set; }

    [Display(Name = "Tipo Principal")]
    public Tipo TipoPrincipal { get; set; }

    [Display(Name = "Tipo Secundário")]
    [ForeignKey(nameof(TipoSecundario))]
    public int? Tipo2Fk { get; set; }

    [Display(Name = "Tipo Secundário")]
    public Tipo TipoSecundario { get; set; }

    public string Imagem { get; set; }
    
    [Display(Name = "Imagem Shiny")]
    public string ImagemShiny { get; set; }
    
    public ICollection<PokemonAtaque> PokemonAtaques { get; set; }
    
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public ICollection<Evolucao> OrigemEvolucoes { get; set; }
    
    public ICollection<Evolucao> FinalEvolucoes { get; set; }
    
    public ICollection<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
    
    public ICollection<PokemonStats> PokemonStats { get; set; }
    
    
}

