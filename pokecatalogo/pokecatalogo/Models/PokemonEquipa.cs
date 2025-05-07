using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonEquipa
{
    [Key]
    public int Id { get; set; }
    
    [ForeignKey(nameof(Equipa))]
    public int EquipaFk { get; set; }
    public Equipa Equipa { get; set; }
    
    [ForeignKey(nameof(Pokemon))]
    public int PokemonFk { get; set; }
    public Pokemon Pokemon { get; set; }
}