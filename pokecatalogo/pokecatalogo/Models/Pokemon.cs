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
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "O PokeApiId deve ser positivo")]
    public int PokeApiId { get; set; }

    [NotMapped]
    public string ImagemUrl => $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{PokeApiId}.png";

    [Range(0.01, float.MaxValue, ErrorMessage = "A altura deve ser positiva")]
    public float Altura { get; set; }
    
    [Range(0.01, float.MaxValue, ErrorMessage = "O peso deve ser positivo")]
    public float Peso { get; set; }

    [Display(Name = "Espécie")]
    [StringLength(50)]
    public string Especie { get; set; }
    
    public ICollection<Tipo> Tipos { get; set; } = [];

    
    public ICollection<Ataque> PokemonAtaques { get; set; } = [];
    
    public ICollection<PokemonHabilidade> PokemonHabilidades { get; set; }= [];
    
    [ForeignKey(nameof(EvolucaoAnterior))]
    public int EvolucaoAnteriorFk { get; set; }
    public Evolucao EvolucaoAnterior { get; set; }
    
    public ICollection<Evolucao> FinalEvolucoes { get; set; }= [];
    
    public ICollection<PokemonLocalizacao> PokemonLocalizacoes { get; set; }= [];
    
    public ICollection<PokemonStats> PokemonStats { get; set; }= [];
    
    
}

