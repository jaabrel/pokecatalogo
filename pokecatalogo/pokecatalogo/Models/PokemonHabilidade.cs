using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class PokemonHabilidade
{
    public int PokemonId { get; set; }
    public int HabilidadeId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Habilidade Habilidade { get; set; }
}