using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class PokemonLocalizacaoDto
    {
        public int Id { get; set; }
        [Required]
        public int PokemonFk { get; set; }
        [Required]
        public int LocalizacaoFk { get; set; }
    }
} 