using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Evolucao
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    
    public int PokemonId { get; set; }
    public Pokemon Pokemon { get; set; }
}