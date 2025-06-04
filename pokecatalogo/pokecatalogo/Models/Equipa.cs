using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Equipa
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome da equipa é obrigatório")]
    [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres")]
    [Display(Name = "Nome da Equipa")]
    public string NomeEquipa { get; set; }
    
    [StringLength(500)]
    [Display(Name = "Descrição")]
    public string? Descricao { get; set; }

    [Display(Name = "Data de Criação")]
    public DateTime DataCriacao { get; set; } = DateTime.Now;

    [Display(Name = "Data de Atualização")]
    public DateTime? DataAtualizacao { get; set; }
    
    [ForeignKey(nameof(Dono))]
    public int DonoFk { get; set; }
    public Utilizadores Dono { get; set; }

    // Coleção de Pokémon na equipa (máximo 6)
    public ICollection<PokemonEquipa> Pokemons { get; set; }

    // Likes e comentários
    public ICollection<Like> Likes { get; set; }
    public ICollection<Comentario> Comentarios { get; set; }

    public Equipa()
    {
        Pokemons = new List<PokemonEquipa>();
        Likes = new List<Like>();
        Comentarios = new List<Comentario>();
    }
}