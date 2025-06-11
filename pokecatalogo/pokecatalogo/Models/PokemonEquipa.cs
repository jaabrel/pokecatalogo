using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonEquipa
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey(nameof(Equipa))]
    public int EquipaFk { get; set; }
    public Equipa Equipa { get; set; }
    
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    public Pokemon Pokemon { get; set; }

    [Range(1, 100)]
    [Display(Name = "Nível")]
    public int Nivel { get; set; } = 50;

    [StringLength(50)]
    [Display(Name = "Alcunha")]
    public string? Alcunha { get; set; }

    [Display(Name = "Posição na Equipa")]
    [Range(1, 6, ErrorMessage = "A posição deve estar entre 1 e 6")]
    public int PosicaoNaEquipa { get; set; }

    // Movimentos do Pokémon na equipa (máximo 4)
    public ICollection<Ataque> Ataques { get; set; }

    // Habilidade escolhida para o Pokémon na equipa
    [ForeignKey(nameof(Habilidade))]
    public int? HabilidadeFk { get; set; }
    public Habilidade? Habilidade { get; set; }

    public PokemonEquipa()
    {
        Ataques = new List<Ataque>();
    }
}