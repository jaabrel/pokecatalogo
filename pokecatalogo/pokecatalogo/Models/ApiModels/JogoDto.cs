using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class JogoDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
    }
} 