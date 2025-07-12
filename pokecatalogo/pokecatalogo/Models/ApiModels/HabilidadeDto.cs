using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class HabilidadeDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int PokemonFk { get; set; }
    }
} 