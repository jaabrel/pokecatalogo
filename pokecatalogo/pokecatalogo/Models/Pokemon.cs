using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Pokemon
{
    [Key] 
    public int Id { get; set; }
    
    [Required(ErrorMessage= "O pokémon tem de ter um Nome")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "A descrição da Pokedex é obrigatória")]
    [Display(Name = "Descrição Pokedex")]
    public string DescricaoPokedex { get; set; }
    
    public float Altura { get; set; }
    
    public float Peso { get; set; }

    [Display(Name = "Espécie")]
    public string Especie { get; set; }
    
    public ICollection<Tipo> Tipos { get; set; } = [];

    public string Imagem { get; set; }
    
    [Display(Name = "Imagem Shiny")]
    public string ImagemShiny { get; set; }

    public ICollection<Ataque> PokemonAtaques { get; set; } = [];
    
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }= [];
    
    [ForeignKey(nameof(EvolucaoAnterior))]
    public int EvolucaoAnteriorFk { get; set; }
    public Evolucao EvolucaoAnterior { get; set; }
    
    public ICollection<Evolucao> FinalEvolucoes { get; set; }= [];
    
    public ICollection<PokemonLocalizacao> PokemonLocalizacoes { get; set; }= [];
    
    public ICollection<PokemonStats> PokemonStats { get; set; }= [];
    
    
}

