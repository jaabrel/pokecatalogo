using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Utilizadores
{
    /// <summary>
    /// Identificador único do utilizador
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Nome do utilizador
    /// </summary>
    [Required(ErrorMessage = "O {0} é de preenchimento obrigatório.")]
    public string Nome { get; set; }
    
    /// <summary>
    /// Email do Utilizador
    /// </summary>
    [Required(ErrorMessage = "É necessário usar um email.")]
    public string Email { get; set; }
  
    /// <summary>
    /// Ligação do utilizador da base de dados criada e da tabela ASPNet Users
    /// </summary>
    
    [StringLength(50)]
    public string? IdentityUserName { get; set; }
}