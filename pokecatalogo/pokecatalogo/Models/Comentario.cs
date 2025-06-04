using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Comentario
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O comentário não pode estar vazio")]
    [StringLength(500, ErrorMessage = "O comentário não pode ter mais de 500 caracteres")]
    public string Conteudo { get; set; }

    public DateTime DataComentario { get; set; }

    [ForeignKey(nameof(Utilizador))]
    public int UtilizadorFk { get; set; }
    public Utilizadores Utilizador { get; set; }

    [ForeignKey(nameof(Equipa))]
    public int EquipaFk { get; set; }
    public Equipa Equipa { get; set; }
} 