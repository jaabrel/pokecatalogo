using Microsoft.AspNetCore.Identity;
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "a", Name = "Administrador", NormalizedName = "ADMINISTRADOR"});

        var hasher = new PasswordHasher<IdentityUser>();
        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "admin",
                UserName = "admin@mail.pt",
                NormalizedUserName = "ADMIN@MAIL.PT",
                Email = "admin@mail.pt",
                NormalizedEmail = "ADMIN@MAIL.PT",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = hasher.HashPassword(null, "Aa0_aa")
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "admin", RoleId = "a" });
        
        modelBuilder.Entity<LocalizacaoJogo>().HasKey(lg => new { lg.LocalizacaoFk, lg.JogoFk });
        
        modelBuilder.Entity<PokemonAtaque>().HasKey(pa => new { pa.PokemonFk, pa.AtaqueFk });
        modelBuilder.Entity<PokemonEquipa>().HasKey(pe => pe.Id);
        
        modelBuilder.Entity<PokemonHabilidade>().HasKey(ph => new { ph.PokemonFk, ph.HabilidadeFk });
        
        modelBuilder.Entity<PokemonLocalizacao>().HasKey(pl => new { pl.PokemonFk, pl.LocalizacaoFk });

        modelBuilder.Entity<PokemonStats>().HasKey(ps => new { ps.PokemonFk });
        
        modelBuilder.Entity<LocalizacaoJogo>().HasKey(lj => new { lj.LocalizacaoFk, lj.JogoFk });
        
        modelBuilder.Entity<LocalizacaoJogo>()
            .HasOne<Localizacao>(lg => lg.Localizacao)
            .WithMany(l => l.LocalizacaoJogos)
            .HasForeignKey(lg => lg.LocalizacaoFk);

        modelBuilder.Entity<LocalizacaoJogo>()
            .HasOne<Jogo>(lg => lg.Jogo)
            .WithMany(l => l.LocalizacaoJogos)
            .HasForeignKey(lg => lg.JogoFk);

        modelBuilder.Entity<PokemonHabilidade>()
            .HasOne<Habilidade>(ph => ph.Habilidade)
            .WithMany(h => h.PokemonHabilidades)
            .HasForeignKey(ph => ph.HabilidadeFk);
        
        modelBuilder.Entity<PokemonHabilidade>()
            .HasOne<Pokemon>(ph => ph.Pokemon)
            .WithMany(p => p.PokemonHabilidades)
            .HasForeignKey(ph => ph.PokemonFk);
        
        modelBuilder.Entity<Evolucao>()
            .HasOne<Pokemon>(e => e.PokemonOrigem)
            .WithMany(p => p.OrigemEvolucoes)
            .HasForeignKey(e => e.PokemonFk1);
        
        modelBuilder.Entity<Evolucao>()
            .HasOne<Pokemon>(e => e.PokemonEvoluido)
            .WithMany(p => p.FinalEvolucoes)
            .HasForeignKey(e => e.PokemonFk2);
        
        modelBuilder.Entity<Pokemon>()
            .HasOne<Tipo>(p => p.Tipo1)
            .WithMany(t => t.PokemonsPrimarios)
            .HasForeignKey(p => p.Tipo1Fk);
        
        modelBuilder.Entity<Pokemon>()
            .HasOne<Tipo>(p => p.Tipo2)
            .WithMany(t => t.PokemonsSecundarios)
            .HasForeignKey(p => p.Tipo2Fk);

        modelBuilder.Entity<PokemonAtaque>()
            .HasOne<Pokemon>(pa => pa.Pokemon)
            .WithMany(p => p.PokemonAtaques)
            .HasForeignKey(pa => pa.PokemonFk);
        modelBuilder.Entity<PokemonAtaque>()
            .HasOne<Ataque>(pa => pa.Ataque)
            .WithMany(p => p.PokemonAtaques)
            .HasForeignKey(pa => pa.AtaqueFk);
        
    }
    
    public DbSet<Ataque> Ataques { get; set; }
    
    public DbSet<Evolucao> Evolucoes { get; set; }
    
    public DbSet<Habilidade> Habilidades { get; set; }
    
    public DbSet<Jogo> Jogos { get; set; }
    
    public DbSet<Localizacao> Localizacoes { get; set; }
    
    public DbSet<LocalizacaoJogo> LocalizacaoJogos { get; set; }
    
    public DbSet<Pokemon> Pokemons { get; set; }
    
    public DbSet<PokemonAtaque> PokemonAtaques { get; set; }
    
    public DbSet<PokemonEquipa> PokemonEquipas { get; set; }
    
    public DbSet<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public DbSet<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
    
    public DbSet<PokemonStats> PokemonStats { get; set; }
    
    public DbSet<Tipo> Tipos { get; set; }
    
    public DbSet<Utilizadores> Utilizadores { get; set; }

public DbSet<pokecatalogo.Models.Equipa> Equipa { get; set; }
    
}
