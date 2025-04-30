using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonLocalizacao
{
    [Display(Name = "Pokemon")]
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    
    public Pokemon Pokemon { get; set; }
    
    [Display(Name = "Localizacao")]
    [ForeignKey(nameof(Localizacao))]
    public int LocalizacaoFk { get; set; }
    public Localizacao Localizacao { get; set; }
}