using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using pokecatalogo.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

        // Value converter for List<TiposEnum> <-> string
        var tiposEnumListConverter = new ValueConverter<List<TiposEnum>, string>(
            v => string.Join(",", v.Select(e => e.ToString())),
            v => string.IsNullOrEmpty(v)
                ? new List<TiposEnum>()
                : v.Split(',', System.StringSplitOptions.RemoveEmptyEntries).Select(e => (TiposEnum)Enum.Parse(typeof(TiposEnum), e)).ToList()
        );

        builder.Entity<Tipo>()
            .Property(t => t.Fraquezas)
            .HasConversion(tiposEnumListConverter);
        builder.Entity<Tipo>()
            .Property(t => t.Resistências)
            .HasConversion(tiposEnumListConverter);
        builder.Entity<Tipo>()
            .Property(t => t.Imunidades)
            .HasConversion(tiposEnumListConverter);
        builder.Entity<Tipo>()
            .Property(t => t.Efetivo)
            .HasConversion(tiposEnumListConverter);

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "a", Name = "Administrador", NormalizedName = "ADMINISTRADOR"});

        var hasher = new PasswordHasher<IdentityUser>();
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "admin",
                UserName = "admin@mail.pt",
                NormalizedUserName = "ADMIN@MAIL.PT",
                Email = "admin@mail.pt",
                NormalizedEmail = "ADMIN@MAIL.PT",
                EmailConfirmed = true,
                SecurityStamp = "1bcbd0a7-5c9d-4510-811a-cd5eee6c0dbe",
                ConcurrencyStamp ="fe626d10-17f8-4768-8818-895627758300",
                PasswordHash = hasher.HashPassword(null, "Aa0_aa")
            }
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = "admin", RoleId = "a" });
        

        
        // builder.Entity<PokemonHabilidade>()
        //     .HasOne<Habilidade>(ph => ph.Habilidade)
        //     .WithMany(h => h.PokemonHabilidades)
        //     .HasForeignKey(ph => ph.HabilidadeFk);
        //
        // builder.Entity<PokemonHabilidade>()
        //     .HasOne<Pokemon>(ph => ph.Pokemon)
        //     .WithMany(p => p.PokemonHabilidades)
        //     .HasForeignKey(ph => ph.PokemonFk);
        //
        builder.Entity<Evolucao>()
            .HasOne<Pokemon>(e => e.PokemonOrigem)
            .WithMany(p => p.FinalEvolucoes)
            .HasForeignKey(e => e.PokemonFk1);
        
        builder.Entity<Evolucao>()
            .HasOne<Pokemon>(e => e.PokemonEvoluido)
            .WithOne(p => p.EvolucaoAnterior)
            .HasForeignKey<Evolucao>(e => e.PokemonFk2);
        
        
        // builder.Entity<PokemonAtaque>()
        //     .HasOne<Pokemon>(pa => pa.Pokemon)
        //     .WithMany(p => p.PokemonAtaques)
        //     .HasForeignKey(pa => pa.PokemonFk);
        // builder.Entity<PokemonAtaque>()
        //     .HasOne<Ataque>(pa => pa.Ataque)
        //     .WithMany(p => p.PokemonAtaques)
        //     .HasForeignKey(pa => pa.AtaqueFk);
    }
    
    public DbSet<Ataque> Ataques { get; set; }
    
    public DbSet<Equipa> Equipas { get; set; }

    public DbSet<Evolucao> Evolucoes { get; set; }
    
    public DbSet<Habilidade> Habilidades { get; set; }
    
    public DbSet<Jogo> Jogos { get; set; }
    

    public DbSet<Localizacao> Localizacoes { get; set; }
    
    public DbSet<LocalizacaoJogo> LocalizacaoJogos { get; set; }
    
    public DbSet<Pokemon> Pokemons { get; set; }
    
    public DbSet<PokemonEquipa> PokemonEquipas { get; set; }
    
    public DbSet<PokemonHabilidade> PokemonHabilidades { get; set; }
    
    public DbSet<PokemonLocalizacao> PokemonLocalizacoes { get; set; }
    
    public DbSet<PokemonStats> PokemonStats { get; set; }
    
    public DbSet<Tipo> Tipos { get; set; }
    
    public DbSet<Utilizadores> Utilizadores { get; set; }
}
