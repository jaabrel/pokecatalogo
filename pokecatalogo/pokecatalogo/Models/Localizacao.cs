using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Localizacao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public ICollection<Pokemon> Pokemons { get; set; }
    public ICollection<LocalizacaoJogo> LocalizacaoJogos { get; set; }
}