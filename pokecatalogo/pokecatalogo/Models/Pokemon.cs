using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Pokemon
{
    [Key]
    public int Id { get; set; }
    
    [Display(Name = "Nome")]
    public string Name { get; set; }
    
    [Display(Name = "Número da Pokédex")]
    public int NumeroPokedex { get; set; }
}