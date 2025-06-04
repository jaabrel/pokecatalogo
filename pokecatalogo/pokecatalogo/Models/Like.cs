using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Like
{
    public int Id { get; set; }

    public DateTime DataLike { get; set; }

    [ForeignKey(nameof(Utilizador))]
    public int UtilizadorFk { get; set; }
    public Utilizadores Utilizador { get; set; }

    [ForeignKey(nameof(Equipa))]
    public int EquipaFk { get; set; }
    public Equipa Equipa { get; set; }
} 