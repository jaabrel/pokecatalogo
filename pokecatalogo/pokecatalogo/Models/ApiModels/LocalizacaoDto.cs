using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class LocalizacaoDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
} 