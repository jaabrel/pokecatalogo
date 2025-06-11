
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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

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
        
        builder.Entity<Tipo>().HasData(
        new Tipo { Id = 1, Nome = TiposEnum.Normal,       Cor = "#A8A878", Fraquezas = TiposEnum.Lutador,     Resistências = null,             Imunidades = TiposEnum.Fantasma,  Efetivo = null },
        new Tipo { Id = 2, Nome = TiposEnum.Fogo,         Cor = "#F08030", Fraquezas = TiposEnum.Água,        Resistências = TiposEnum.Metal,      Imunidades = null,             Efetivo = TiposEnum.Erva },
        new Tipo { Id = 3, Nome = TiposEnum.Água,         Cor = "#6890F0", Fraquezas = TiposEnum.Erva,        Resistências = TiposEnum.Fogo,       Imunidades = null,             Efetivo = TiposEnum.Pedra },
        new Tipo { Id = 4, Nome = TiposEnum.Eletricidade, Cor = "#F8D030", Fraquezas = TiposEnum.Terra,       Resistências = TiposEnum.Voador,     Imunidades = null,             Efetivo = TiposEnum.Água },
        new Tipo { Id = 5, Nome = TiposEnum.Erva,         Cor = "#78C850", Fraquezas = TiposEnum.Fogo,        Resistências = TiposEnum.Água,       Imunidades = null,             Efetivo = TiposEnum.Terra },
        new Tipo { Id = 6, Nome = TiposEnum.Gelo,         Cor = "#98D8D8", Fraquezas = TiposEnum.Fogo,        Resistências = TiposEnum.Gelo,       Imunidades = null,             Efetivo = TiposEnum.Voador },
        new Tipo { Id = 7, Nome = TiposEnum.Lutador,      Cor = "#C03028", Fraquezas = TiposEnum.Psíquico,    Resistências = TiposEnum.Pedra,      Imunidades = null,             Efetivo = TiposEnum.Normal },
        new Tipo { Id = 8, Nome = TiposEnum.Veneno,       Cor = "#A040A0", Fraquezas = TiposEnum.Terra,       Resistências = TiposEnum.Erva,       Imunidades = null,             Efetivo = TiposEnum.Fada },
        new Tipo { Id = 9, Nome = TiposEnum.Terra,        Cor = "#E0C068", Fraquezas = TiposEnum.Água,        Resistências = TiposEnum.Veneno,     Imunidades = TiposEnum.Eletricidade, Efetivo = TiposEnum.Metal },
        new Tipo { Id = 10, Nome = TiposEnum.Voador,      Cor = "#A890F0", Fraquezas = TiposEnum.Eletricidade, Resistências = TiposEnum.Erva,     Imunidades = TiposEnum.Terra,      Efetivo = TiposEnum.Lutador },
        new Tipo { Id = 11, Nome = TiposEnum.Psíquico,    Cor = "#F85888", Fraquezas = TiposEnum.Escuridão,   Resistências = TiposEnum.Lutador,    Imunidades = null,             Efetivo = TiposEnum.Veneno },
        new Tipo { Id = 12, Nome = TiposEnum.Inseto,      Cor = "#A8B820", Fraquezas = TiposEnum.Fogo,        Resistências = TiposEnum.Erva,       Imunidades = null,             Efetivo = TiposEnum.Psíquico },
        new Tipo { Id = 13, Nome = TiposEnum.Pedra,       Cor = "#B8A038", Fraquezas = TiposEnum.Água,        Resistências = TiposEnum.Normal,     Imunidades = null,             Efetivo = TiposEnum.Inseto },
        new Tipo { Id = 14, Nome = TiposEnum.Fantasma,    Cor = "#705898", Fraquezas = TiposEnum.Escuridão,   Resistências = TiposEnum.Veneno,     Imunidades = TiposEnum.Normal,     Efetivo = TiposEnum.Psíquico },
        new Tipo { Id = 15, Nome = TiposEnum.Dragão,      Cor = "#7038F8", Fraquezas = TiposEnum.Fada,        Resistências = TiposEnum.Fogo,       Imunidades = null,             Efetivo = TiposEnum.Dragão },
        new Tipo { Id = 16, Nome = TiposEnum.Escuridão,   Cor = "#705848", Fraquezas = TiposEnum.Lutador,     Resistências = TiposEnum.Fantasma,   Imunidades = TiposEnum.Psíquico,   Efetivo = TiposEnum.Fantasma },
        new Tipo { Id = 17, Nome = TiposEnum.Metal,       Cor = "#B8B8D0", Fraquezas = TiposEnum.Fogo,        Resistências = TiposEnum.Fada,       Imunidades = TiposEnum.Veneno,     Efetivo = TiposEnum.Pedra },
        new Tipo { Id = 18, Nome = TiposEnum.Fada,        Cor = "#EE99AC", Fraquezas = TiposEnum.Metal,       Resistências = TiposEnum.Lutador,    Imunidades = TiposEnum.Dragão,     Efetivo = TiposEnum.Escuridão }
    );

        
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
