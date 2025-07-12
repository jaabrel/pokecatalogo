using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    /// <summary>
    /// Data Transfer Object for Equipa (team).
    /// </summary>
    public class EquipaDto
    {
        /// <summary>Equipa ID.</summary>
        public int Id { get; set; }
        /// <summary>Team name.</summary>
        [Required]
        [StringLength(50)]
        public string NomeEquipa { get; set; }
        /// <summary>Team description (optional).</summary>
        [StringLength(500)]
        public string? Descricao { get; set; }
        /// <summary>Creation date.</summary>
        public DateTime DataCriacao { get; set; }
        /// <summary>Owner user ID.</summary>
        [Required]
        public int DonoFk { get; set; }
        /// <summary>List of Pokémon IDs in the team.</summary>
        public List<int> Pokemons { get; set; } = new();
    }
} 