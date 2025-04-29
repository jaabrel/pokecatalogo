using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using pokecatalogo.Models;

namespace pokecatalogo.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) 
    {
    }
    public DbSet<Ataque> Ataques { get; set; }
    
    public DbSet<Jogo> Jogos { get; set; }
    
    public DbSet<Evolucao> Evolucoes { get; set; }
    
    public DbSet<Tipo> Tipos { get; set; }
    
    public DbSet<Pokemon> Pokemons { get; set; }
    
    public DbSet<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public DbSet<Habilidade> Habilidades { get; set; }
}
