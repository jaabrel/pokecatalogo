using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Equipa
{
    public int Id { get; set; }
    
    /// <summary>
    /// Nome da Equipa
    /// </summary>
    [Required(ErrorMessage = "O nome da equipa é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres")]
    [Display(Name = "Nome da Equipa")]
    public string NomeEquipa { get; set; }
    
    /// <summary>
    /// Descriçao da equipa, opcional
    /// </summary>
    [StringLength(500)]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    /// <summary>
    /// Data de criação da equipa
    /// </summary>
    [Display(Name = "Data de Criação")]
    public DateTime DataCriacao { get; set; }
    
    [ForeignKey(nameof(Dono))]
    public int DonoFk { get; set; }
    public Utilizadores Dono { get; set; }

    // Coleção de Pokémon na equipa (máximo 4)
    public ICollection<PokemonEquipa> Pokemons { get; set; }
    
}