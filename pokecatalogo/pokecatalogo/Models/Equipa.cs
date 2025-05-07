using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Equipa
{
    public int Id { get; set; }
    
    public string NomeEquipa { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    [ForeignKey(nameof(Dono))]
    public int DonoFk { get; set; }
    public Utilizadores Dono { get; set; }
    
    public  virtual ICollection<PokemonEquipa> PokemonEquipas { get; set; }
}