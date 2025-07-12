using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class PokemonStatsDto
    {
        public int Id { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int SpA { get; set; }
        public int SpD { get; set; }
        public int Speed { get; set; }
        [Required]
        public int PokemonFk { get; set; }
    }
} 