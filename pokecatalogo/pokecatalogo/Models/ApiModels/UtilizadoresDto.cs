using System.ComponentModel.DataAnnotations;

namespace pokecatalogo.Models.ApiModels
{
    public class UtilizadoresDto
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        public string? IdentityUserName { get; set; }
    }
} 