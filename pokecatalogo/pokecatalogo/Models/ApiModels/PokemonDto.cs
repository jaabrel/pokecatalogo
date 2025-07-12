using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    /// <summary>
    /// Data Transfer Object for Pokémon.
    /// </summary>
    public class PokemonDto
    {
        /// <summary>Pokémon ID.</summary>
        public int Id { get; set; }
        /// <summary>Pokémon name.</summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>Pokedex description.</summary>
        [Required]
        public string DescricaoPokedex { get; set; }
        /// <summary>Pokémon height in meters.</summary>
        [Range(0.01, float.MaxValue)]
        public float Altura { get; set; }
        /// <summary>Pokémon weight in kilograms.</summary>
        [Range(0.01, float.MaxValue)]
        public float Peso { get; set; }
        /// <summary>Pokémon species.</summary>
        public string Especie { get; set; }
        /// <summary>PokéAPI ID for sprite image.</summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int PokeApiId { get; set; }
        /// <summary>List of Tipo IDs for the Pokémon.</summary>
        public List<int> Tipos { get; set; } = new();
    }
} 