using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Ataque
{
    public int Id { get; set; }
    
    public string Nome { get; set; }
    
    public string Categoria { get; set; }
    
    public string Descricao { get; set; }
    
    public int Dano { get; set; }
    
    public int Precisao { get; set; }
    
    public int PP { get; set; }
    
    public int Prioridade { get; set; }
    
    [Display(Name = "Tipo")]
    [ForeignKey(nameof(Tipo))]
    public int TipoFk { get; set; }
    public Tipo Tipo { get; set; }
    
    public ICollection<Pokemon> Pokemon { get; set; }
    
    public ICollection<Equipa> Equipas { get; set; }
}