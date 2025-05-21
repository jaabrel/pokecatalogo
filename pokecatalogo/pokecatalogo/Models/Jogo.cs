using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Jogo
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O {} é de preenchimento obrigatório")]
    public string Nome { get; set; }
    
    [Display(Name = "Data de Lançamento")]
    [Required(ErrorMessage = "A {} é de preenchimento obrigatório")]
    public DateTime DataLancamento { get; set; }
    
    public ICollection<LocalizacaoJogo> LocalizacaoJogos  { get; set; }
}