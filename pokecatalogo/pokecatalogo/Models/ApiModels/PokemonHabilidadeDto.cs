using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class PokemonHabilidadeDto
    {
        public int Id { get; set; }
        [Required]
        public int PokemonFk { get; set; }
        [Required]
        public int HabilidadeFk { get; set; }
    }
} 