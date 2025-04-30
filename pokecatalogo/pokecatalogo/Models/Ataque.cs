using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Ataque
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    [Display(Name = "Tipo")]
    [ForeignKey(nameof(Tipo))]
    public int TipoFk { get; set; }
    public Tipo Tipo { get; set; }
    
    public ICollection<PokemonAtaque> PokemonAtaques { get; set; }
}