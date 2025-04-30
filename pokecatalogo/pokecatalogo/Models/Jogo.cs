using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Jogo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public ICollection<LocalizacaoJogo> Localizacao  { get; set; }
}