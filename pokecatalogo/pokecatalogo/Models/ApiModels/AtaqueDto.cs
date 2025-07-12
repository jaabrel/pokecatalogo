using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class AtaqueDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Descricao { get; set; }
        public int Dano { get; set; }
        public int Precisao { get; set; }
        public int PP { get; set; }
        public int Prioridade { get; set; }
        [Required]
        public int TipoFk { get; set; }
    }
} 