using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class LocalizacaoJogo
{
    
    public int Id { get; set; }
    
    [Display(Name = "Jogo")]
    [ForeignKey(nameof(Jogo))]
    public int JogoFk { get; set; }
    
    public Jogo Jogo { get; set; }
    
    [Display(Name = "Localização")]
    [ForeignKey(nameof(Localizacao))]
    public int LocalizacaoFk { get; set; }
    
    public Localizacao Localizacao { get; set; }
    
    
}