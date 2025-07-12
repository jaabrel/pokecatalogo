using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class LocalizacaoJogoDto
    {
        public int Id { get; set; }
        [Required]
        public int JogoFk { get; set; }
        [Required]
        public int LocalizacaoFk { get; set; }
    }
} 