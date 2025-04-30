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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        
    }
    
    public DbSet<Ataque> Ataques { get; set; }
    
    public DbSet<Equipas> Equipas { get; set; }
    
    public DbSet<Evolucao> Evolucoes { get; set; }
    
    public DbSet<Habilidade> Habilidades { get; set; }
    
    public DbSet<Jogo> Jogos { get; set; }
    
    public DbSet<Localizacao> Localizacoes { get; set; }
    
    public DbSet<LocalizacaoJogo> LocalizacaoJogos { get; set; }
    
    public DbSet<Pokemon> Pokemons { get; set; }
    
    public DbSet<PokemonAtaque> PokemonAtaques { get; set; }
    
    public DbSet<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public DbSet<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
    
    public DbSet<PokemonTipo> PokemonTipos { get; set; }
    
    public DbSet<Tipo> Tipos { get; set; }
    
    public DbSet<Utilizadores> Utilizadores { get; set; }
    
}
