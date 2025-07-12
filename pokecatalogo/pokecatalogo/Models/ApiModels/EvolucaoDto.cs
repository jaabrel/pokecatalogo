using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class EvolucaoDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int PokemonFk1 { get; set; }
        public int? PokemonFk2 { get; set; }
    }
} 