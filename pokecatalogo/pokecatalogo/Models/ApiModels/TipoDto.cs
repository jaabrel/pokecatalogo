using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    /// <summary>
    /// Data Transfer Object for Tipo (type).
    /// </summary>
    public class TipoDto
    {
        /// <summary>Tipo ID.</summary>
        public int Id { get; set; }
        /// <summary>Tipo name (enum as string).</summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>Tipo color.</summary>
        [Required]
        public string Cor { get; set; }
    }
} 