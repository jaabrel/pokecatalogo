using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class PokemonEquipaDto
    {
        public int Id { get; set; }
        [Required]
        public int EquipaFk { get; set; }
        [Required]
        public int PokemonFk { get; set; }
        [Range(1, 100)]
        public int Nivel { get; set; } = 50;
        public string? Alcunha { get; set; }
        [Range(1, 6)]
        public int PosicaoNaEquipa { get; set; }
        public List<int> Ataques { get; set; } = new();
        public int? HabilidadeFk { get; set; }
    }
} 