using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokecatalogo.Models;

public class Utilizadores
{
    public int Id { get; set; }
    
    
    [Required(ErrorMessage = "É necessário informar o nome.")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "É necessário usar um email.")]
    public string Email { get; set; }
    
    [StringLength(50)]
    public string? IdentityUserName { get; set; }
    
}