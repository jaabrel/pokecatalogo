using pokecatalogo.Models;
using Microsoft.AspNetCore.Identity;

namespace pokecatalogo.Data.DbInitializerDev;

public class DbInitializer
{
    internal static async void Initialize(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
        dbContext.Database.EnsureCreated();

        
        // 1. Seed Tipos (already present, but remove Id assignment)
        if (!dbContext.Tipos.Any())
        {
            dbContext.Tipos.AddRange(new[]
            {
                new Tipo {
                    Nome = TiposEnum.Normal,
                    Cor = "#A8A878",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Lutador },
                    Resistências = new List<TiposEnum>(),
                    Imunidades = new List<TiposEnum> { TiposEnum.Fantasma },
                    Efetivo = new List<TiposEnum>()
                },
                new Tipo {
                    Nome = TiposEnum.Fogo,
                    Cor = "#F08030",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Terra, TiposEnum.Pedra },
                    Resistências = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Erva, TiposEnum.Gelo, TiposEnum.Inseto, TiposEnum.Metal, TiposEnum.Fada },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Gelo, TiposEnum.Inseto, TiposEnum.Metal }
                },
                new Tipo {
                    Nome = TiposEnum.Água,
                    Cor = "#6890F0",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Eletricidade },
                    Resistências = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Água, TiposEnum.Gelo, TiposEnum.Metal },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Pedra, TiposEnum.Terra }
                },
                new Tipo {
                    Nome = TiposEnum.Eletricidade,
                    Cor = "#F8D030",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Terra },
                    Resistências = new List<TiposEnum> { TiposEnum.Eletricidade, TiposEnum.Voador, TiposEnum.Metal },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Voador }
                },
                new Tipo {
                    Nome = TiposEnum.Erva,
                    Cor = "#78C850",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Gelo, TiposEnum.Voador, TiposEnum.Inseto, TiposEnum.Veneno },
                    Resistências = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Erva, TiposEnum.Terra, TiposEnum.Eletricidade },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Terra, TiposEnum.Pedra }
                },
                new Tipo {
                    Nome = TiposEnum.Gelo,
                    Cor = "#98D8D8",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Lutador, TiposEnum.Pedra, TiposEnum.Metal },
                    Resistências = new List<TiposEnum> { TiposEnum.Gelo },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Terra, TiposEnum.Voador, TiposEnum.Dragão }
                },
                new Tipo {
                    Nome = TiposEnum.Lutador,
                    Cor = "#C03028",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Voador, TiposEnum.Psíquico, TiposEnum.Fada },
                    Resistências = new List<TiposEnum> { TiposEnum.Pedra, TiposEnum.Inseto, TiposEnum.Escuridão },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Normal, TiposEnum.Pedra, TiposEnum.Metal, TiposEnum.Gelo, TiposEnum.Escuridão }
                },
                new Tipo {
                    Nome = TiposEnum.Veneno,
                    Cor = "#A040A0",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Terra, TiposEnum.Psíquico },
                    Resistências = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Lutador, TiposEnum.Veneno, TiposEnum.Inseto, TiposEnum.Fada },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Fada }
                },
                new Tipo {
                    Nome = TiposEnum.Terra,
                    Cor = "#E0C068",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Erva, TiposEnum.Gelo },
                    Resistências = new List<TiposEnum> { TiposEnum.Veneno, TiposEnum.Pedra },
                    Imunidades = new List<TiposEnum> { TiposEnum.Eletricidade },
                    Efetivo = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Eletricidade, TiposEnum.Veneno, TiposEnum.Metal, TiposEnum.Pedra }
                },
                new Tipo {
                    Nome = TiposEnum.Voador,
                    Cor = "#A890F0",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Eletricidade, TiposEnum.Gelo, TiposEnum.Pedra },
                    Resistências = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Lutador, TiposEnum.Inseto },
                    Imunidades = new List<TiposEnum> { TiposEnum.Terra },
                    Efetivo = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Lutador, TiposEnum.Inseto }
                },
                new Tipo {
                    Nome = TiposEnum.Psíquico,
                    Cor = "#F85888",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Inseto, TiposEnum.Fantasma, TiposEnum.Escuridão },
                    Resistências = new List<TiposEnum> { TiposEnum.Lutador, TiposEnum.Psíquico },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Lutador, TiposEnum.Veneno }
                },
                new Tipo {
                    Nome = TiposEnum.Inseto,
                    Cor = "#A8B820",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Voador, TiposEnum.Pedra },
                    Resistências = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Lutador, TiposEnum.Terra },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Erva, TiposEnum.Psíquico, TiposEnum.Escuridão }
                },
                new Tipo {
                    Nome = TiposEnum.Pedra,
                    Cor = "#B8A038",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Água, TiposEnum.Erva, TiposEnum.Lutador, TiposEnum.Terra, TiposEnum.Metal },
                    Resistências = new List<TiposEnum> { TiposEnum.Normal, TiposEnum.Fogo, TiposEnum.Veneno, TiposEnum.Voador },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Gelo, TiposEnum.Voador, TiposEnum.Inseto }
                },
                new Tipo {
                    Nome = TiposEnum.Fantasma,
                    Cor = "#705898",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Fantasma, TiposEnum.Escuridão },
                    Resistências = new List<TiposEnum> { TiposEnum.Veneno, TiposEnum.Inseto },
                    Imunidades = new List<TiposEnum> { TiposEnum.Normal, TiposEnum.Lutador },
                    Efetivo = new List<TiposEnum> { TiposEnum.Fantasma, TiposEnum.Psíquico }
                },
                new Tipo {
                    Nome = TiposEnum.Dragão,
                    Cor = "#7038F8",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Gelo, TiposEnum.Dragão, TiposEnum.Fada },
                    Resistências = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Água, TiposEnum.Eletricidade, TiposEnum.Erva },
                    Imunidades = new List<TiposEnum>(),
                    Efetivo = new List<TiposEnum> { TiposEnum.Dragão }
                },
                new Tipo {
                    Nome = TiposEnum.Escuridão,
                    Cor = "#705848",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Lutador, TiposEnum.Inseto, TiposEnum.Fada },
                    Resistências = new List<TiposEnum> { TiposEnum.Fantasma, TiposEnum.Escuridão },
                    Imunidades = new List<TiposEnum> { TiposEnum.Psíquico },
                    Efetivo = new List<TiposEnum> { TiposEnum.Fantasma, TiposEnum.Psíquico }
                },
                new Tipo {
                    Nome = TiposEnum.Metal,
                    Cor = "#B8B8D0",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Fogo, TiposEnum.Lutador, TiposEnum.Terra },
                    Resistências = new List<TiposEnum> { TiposEnum.Normal, TiposEnum.Erva, TiposEnum.Gelo, TiposEnum.Voador, TiposEnum.Psíquico, TiposEnum.Inseto, TiposEnum.Pedra, TiposEnum.Dragão, TiposEnum.Metal, TiposEnum.Fada },
                    Imunidades = new List<TiposEnum> { TiposEnum.Veneno },
                    Efetivo = new List<TiposEnum> { TiposEnum.Fada, TiposEnum.Gelo, TiposEnum.Pedra }
                },
                new Tipo {
                    Nome = TiposEnum.Fada,
                    Cor = "#EE99AC",
                    Fraquezas = new List<TiposEnum> { TiposEnum.Metal, TiposEnum.Veneno },
                    Resistências = new List<TiposEnum> { TiposEnum.Lutador, TiposEnum.Inseto, TiposEnum.Escuridão },
                    Imunidades = new List<TiposEnum> { TiposEnum.Dragão },
                    Efetivo = new List<TiposEnum> { TiposEnum.Lutador, TiposEnum.Dragão, TiposEnum.Escuridão }
                }
            });
            dbContext.SaveChanges();
        }

        // 2. Assign variables for all types by Nome
        var tipoNormal = dbContext.Tipos.First(t => t.Nome == TiposEnum.Normal);
        var tipoFogo = dbContext.Tipos.First(t => t.Nome == TiposEnum.Fogo);
        var tipoAgua = dbContext.Tipos.First(t => t.Nome == TiposEnum.Água);
        var tipoEletricidade = dbContext.Tipos.First(t => t.Nome == TiposEnum.Eletricidade);
        var tipoErva = dbContext.Tipos.First(t => t.Nome == TiposEnum.Erva);
        var tipoGelo = dbContext.Tipos.First(t => t.Nome == TiposEnum.Gelo);
        var tipoLutador = dbContext.Tipos.First(t => t.Nome == TiposEnum.Lutador);
        var tipoVeneno = dbContext.Tipos.First(t => t.Nome == TiposEnum.Veneno);
        var tipoTerra = dbContext.Tipos.First(t => t.Nome == TiposEnum.Terra);
        var tipoVoador = dbContext.Tipos.First(t => t.Nome == TiposEnum.Voador);
        var tipoPsiquico = dbContext.Tipos.First(t => t.Nome == TiposEnum.Psíquico);
        var tipoInseto = dbContext.Tipos.First(t => t.Nome == TiposEnum.Inseto);
        var tipoPedra = dbContext.Tipos.First(t => t.Nome == TiposEnum.Pedra);
        var tipoFantasma = dbContext.Tipos.First(t => t.Nome == TiposEnum.Fantasma);
        var tipoDragao = dbContext.Tipos.First(t => t.Nome == TiposEnum.Dragão);
        var tipoEscuridao = dbContext.Tipos.First(t => t.Nome == TiposEnum.Escuridão);
        var tipoMetal = dbContext.Tipos.First(t => t.Nome == TiposEnum.Metal);
        var tipoFada = dbContext.Tipos.First(t => t.Nome == TiposEnum.Fada);

        // 3. Seed Jogos
        if (!dbContext.Jogos.Any())
        {
            dbContext.Jogos.AddRange(
                new Jogo { Nome = "Pokémon Red", DataLancamento = new DateTime(1996, 2, 27) },
                new Jogo { Nome = "Pokémon Blue", DataLancamento = new DateTime(1996, 10, 15) }
            );
            dbContext.SaveChanges();
        }
        var jogoRedVar = dbContext.Jogos.First(j => j.Nome == "Pokémon Red");
        var jogoBlueVar = dbContext.Jogos.First(j => j.Nome == "Pokémon Blue");

        // 4. Seed Localizacoes
        if (!dbContext.Localizacoes.Any())
        {
            dbContext.Localizacoes.AddRange(
                new Localizacao { Nome = "Pallet Town" },
                new Localizacao { Nome = "Viridian City" }
            );
            dbContext.SaveChanges();
        }
        var palletTownVar = dbContext.Localizacoes.First(l => l.Nome == "Pallet Town");
        var viridianCityVar = dbContext.Localizacoes.First(l => l.Nome == "Viridian City");

        // 5. Seed LocalizacaoJogo (no Id)
        if (!dbContext.LocalizacaoJogos.Any())
        {
            dbContext.LocalizacaoJogos.AddRange(
                new LocalizacaoJogo { JogoFk = jogoRedVar.Id, LocalizacaoFk = palletTownVar.Id },
                new LocalizacaoJogo { JogoFk = jogoRedVar.Id, LocalizacaoFk = viridianCityVar.Id }
            );
            dbContext.SaveChanges();
        }

        // 6. Seed Utilizadores (no Id)
        if (!dbContext.Utilizadores.Any())
        {
            dbContext.Utilizadores.Add(new Utilizadores { Nome = "Ash Ketchum", Email = "ash@pallet.com", IdentityUserName = "ashk" });
            dbContext.SaveChanges();
        }
        var userAshVar = dbContext.Utilizadores.First(u => u.Nome == "Ash Ketchum");

        // 7. Seed Equipa (no Id)
        if (!dbContext.Equipas.Any())
        {
            dbContext.Equipas.Add(new Equipa { NomeEquipa = "Time Ash", Descricao = "Equipe principal do Ash", DataCriacao = DateTime.Now, DonoFk = userAshVar.Id });
            dbContext.SaveChanges();
        }
        var equipeAshVar = dbContext.Equipas.First(e => e.NomeEquipa == "Time Ash");

        // 8. Seed Pokemons (no Id, assign Tipos by reference)
        if (!dbContext.Pokemons.Any())
        {
            dbContext.Pokemons.AddRange(
                new Pokemon { Nome = "Bulbasaur", DescricaoPokedex = "Uma estranha semente foi plantada nas suas costas ao nascer. A planta cresce com este Pokémon.", PokeApiId = 1, Altura = 0.7f, Peso = 6.9f, Especie = "Pokémon Semente", Tipos = new List<Tipo> { tipoErva, tipoVeneno } },
                new Pokemon { Nome = "Charmander", DescricaoPokedex = "Prefere lugares quentes. Diz-se que, quando chove, sai vapor da ponta da sua cauda.", PokeApiId = 4, Altura = 0.6f, Peso = 8.5f, Especie = "Pokémon Lagarto", Tipos = new List<Tipo> { tipoFogo } }
            );
            dbContext.SaveChanges();
        }
        var bulbasaurVar = dbContext.Pokemons.First(p => p.Nome == "Bulbasaur");
        var charmanderVar = dbContext.Pokemons.First(p => p.Nome == "Charmander");

        // 9. Seed Ataques (no Id, assign TipoFk by reference)
        if (!dbContext.Ataques.Any())
        {
            dbContext.Ataques.AddRange(
                new Ataque { Nome = "Tackle", Categoria = "Físico", Descricao = "Um ataque corporal simples.", Dano = 40, Precisao = 100, PP = 35, Prioridade = 0, TipoFk = tipoNormal.Id },
                new Ataque { Nome = "Ember", Categoria = "Especial", Descricao = "Um ataque de fogo básico.", Dano = 40, Precisao = 100, PP = 25, Prioridade = 0, TipoFk = tipoFogo.Id }
            );
            dbContext.SaveChanges();
        }
        var tackleVar = dbContext.Ataques.First(a => a.Nome == "Tackle");
        var emberVar = dbContext.Ataques.First(a => a.Nome == "Ember");

        // 10. Seed Habilidades (no Id, assign PokemonFk by reference)
        if (!dbContext.Habilidades.Any())
        {
            dbContext.Habilidades.AddRange(
                new Habilidade { Nome = "Overgrow", Descricao = "Aumenta ataques de tipo Erva.", PokemonFk = bulbasaurVar.Id },
                new Habilidade { Nome = "Blaze", Descricao = "Aumenta ataques de tipo Fogo.", PokemonFk = charmanderVar.Id }
            );
            dbContext.SaveChanges();
        }
        var overgrowVar = dbContext.Habilidades.First(h => h.Nome == "Overgrow");
        var blazeVar = dbContext.Habilidades.First(h => h.Nome == "Blaze");

        // 11. Seed PokemonStats (no Id, assign PokemonFk by reference)
        if (!dbContext.PokemonStats.Any())
        {
            dbContext.PokemonStats.AddRange(
                new PokemonStats { Hp = 45, Atk = 49, Def = 49, SpA = 65, SpD = 65, Speed = 45, PokemonFk = bulbasaurVar.Id },
                new PokemonStats { Hp = 39, Atk = 52, Def = 43, SpA = 60, SpD = 50, Speed = 65, PokemonFk = charmanderVar.Id }
            );
            dbContext.SaveChanges();
        }

        // 12. Seed PokemonHabilidade (no Id, assign FKs by reference)
        if (!dbContext.PokemonHabilidades.Any())
        {
            dbContext.PokemonHabilidades.AddRange(
                new PokemonHabilidade { PokemonFk = bulbasaurVar.Id, HabilidadeFk = overgrowVar.Id },
                new PokemonHabilidade { PokemonFk = charmanderVar.Id, HabilidadeFk = blazeVar.Id }
            );
            dbContext.SaveChanges();
        }

        // 13. Seed PokemonLocalizacao (no Id, assign FKs by reference)
        if (!dbContext.PokemonLocalizacoes.Any())
        {
            dbContext.PokemonLocalizacoes.AddRange(
                new PokemonLocalizacao { PokemonFk = bulbasaurVar.Id, LocalizacaoFk = palletTownVar.Id },
                new PokemonLocalizacao { PokemonFk = charmanderVar.Id, LocalizacaoFk = palletTownVar.Id }
            );
            dbContext.SaveChanges();
        }

        // 14. Seed Evolucao (no Id, assign FKs by reference)
        if (!dbContext.Evolucoes.Any())
        {
            dbContext.Evolucoes.Add(new Evolucao { Descricao = "Bulbasaur evolui para Ivysaur no nível 16.", PokemonFk1 = bulbasaurVar.Id, PokemonFk2 = null });
            dbContext.SaveChanges();
        }

        // 15. Seed PokemonEquipa (no Id, assign FKs and navigation by reference)
        if (!dbContext.PokemonEquipas.Any())
        {
            dbContext.PokemonEquipas.Add(new PokemonEquipa { EquipaFk = equipeAshVar.Id, PokemonFk = bulbasaurVar.Id, Nivel = 5, Alcunha = "Bulba", PosicaoNaEquipa = 1, Ataques = new List<Ataque> { tackleVar }, HabilidadeFk = overgrowVar.Id });
            dbContext.SaveChanges();
        }

        // --- BATCH 1: Gen 1 Pokémon #1–10 (Bulbasaur to Caterpie) ---
        // Add more Pokémon if not present
        if (!dbContext.Pokemons.Any(p => p.Nome == "Ivysaur"))
        {
            dbContext.Pokemons.AddRange(
                new Pokemon { Nome = "Ivysaur", DescricaoPokedex = "Quando o bulbo nas suas costas cresce, parece perder a capacidade de se manter de pé nas patas traseiras.", PokeApiId = 2, Altura = 1.0f, Peso = 13.0f, Especie = "Pokémon Semente", Tipos = new List<Tipo> { tipoErva, tipoVeneno } },
                new Pokemon { Nome = "Venusaur", DescricaoPokedex = "A planta floresce quando absorve energia solar. Move-se para procurar luz solar.", PokeApiId = 3, Altura = 2.0f, Peso = 100.0f, Especie = "Pokémon Semente", Tipos = new List<Tipo> { tipoErva, tipoVeneno } },
                new Pokemon { Nome = "Squirtle", DescricaoPokedex = "Após o nascimento, as suas costas incham e endurecem formando uma carapaça.", PokeApiId = 7, Altura = 0.5f, Peso = 9.0f, Especie = "Pokémon Tartaruga", Tipos = new List<Tipo> { tipoAgua } },
                new Pokemon { Nome = "Wartortle", DescricaoPokedex = "Costuma esconder-se na água para caçar presas desprevenidas. Move as orelhas para manter o equilíbrio ao nadar.", PokeApiId = 8, Altura = 1.0f, Peso = 22.5f, Especie = "Pokémon Tartaruga", Tipos = new List<Tipo> { tipoAgua } },
                new Pokemon { Nome = "Blastoise", DescricaoPokedex = "Um Pokémon brutal com jatos de água pressurizada na carapaça. Usa-os para tackles a alta velocidade.", PokeApiId = 9, Altura = 1.6f, Peso = 85.5f, Especie = "Pokémon Tartaruga", Tipos = new List<Tipo> { tipoAgua } },
                new Pokemon { Nome = "Caterpie", DescricaoPokedex = "Para proteção, liberta um cheiro horrível pelos seus bigodes.", PokeApiId = 10, Altura = 0.3f, Peso = 2.9f, Especie = "Pokémon Lagarta", Tipos = new List<Tipo> { tipoInseto } }
            );
            dbContext.SaveChanges();
        }
        var ivysaurVar = dbContext.Pokemons.First(p => p.Nome == "Ivysaur");
        var venusaurVar = dbContext.Pokemons.First(p => p.Nome == "Venusaur");
        var squirtleVar = dbContext.Pokemons.First(p => p.Nome == "Squirtle");
        var wartortleVar = dbContext.Pokemons.First(p => p.Nome == "Wartortle");
        var blastoiseVar = dbContext.Pokemons.First(p => p.Nome == "Blastoise");
        var caterpieVar = dbContext.Pokemons.First(p => p.Nome == "Caterpie");

        // Add base stats for new Pokémon
        if (!dbContext.PokemonStats.Any(s => s.PokemonFk == ivysaurVar.Id))
        {
            dbContext.PokemonStats.AddRange(
                new PokemonStats { Hp = 60, Atk = 62, Def = 63, SpA = 80, SpD = 80, Speed = 60, PokemonFk = ivysaurVar.Id },
                new PokemonStats { Hp = 80, Atk = 82, Def = 83, SpA = 100, SpD = 100, Speed = 80, PokemonFk = venusaurVar.Id },
                new PokemonStats { Hp = 44, Atk = 48, Def = 65, SpA = 50, SpD = 64, Speed = 43, PokemonFk = squirtleVar.Id },
                new PokemonStats { Hp = 59, Atk = 63, Def = 80, SpA = 65, SpD = 80, Speed = 58, PokemonFk = wartortleVar.Id },
                new PokemonStats { Hp = 79, Atk = 83, Def = 100, SpA = 85, SpD = 105, Speed = 78, PokemonFk = blastoiseVar.Id },
                new PokemonStats { Hp = 45, Atk = 30, Def = 35, SpA = 20, SpD = 20, Speed = 45, PokemonFk = caterpieVar.Id }
            );
            dbContext.SaveChanges();
        }

        // Add abilities for new Pokémon
        if (!dbContext.Habilidades.Any(h => h.Nome == "Torrent"))
        {
            dbContext.Habilidades.AddRange(
                new Habilidade { Nome = "Overgrow", Descricao = "Aumenta ataques de tipo Erva.", PokemonFk = ivysaurVar.Id },
                new Habilidade { Nome = "Overgrow", Descricao = "Aumenta ataques de tipo Erva.", PokemonFk = venusaurVar.Id },
                new Habilidade { Nome = "Torrent", Descricao = "Aumenta ataques de tipo Água.", PokemonFk = squirtleVar.Id },
                new Habilidade { Nome = "Torrent", Descricao = "Aumenta ataques de tipo Água.", PokemonFk = wartortleVar.Id },
                new Habilidade { Nome = "Torrent", Descricao = "Aumenta ataques de tipo Água.", PokemonFk = blastoiseVar.Id },
                new Habilidade { Nome = "Escudo de Pó", Descricao = "Protege de efeitos de pó e esporos.", PokemonFk = caterpieVar.Id }
            );
            dbContext.SaveChanges();
        }
        var torrentVar = dbContext.Habilidades.First(h => h.Nome == "Torrent" && h.PokemonFk == squirtleVar.Id);
        var escudoPoVar = dbContext.Habilidades.First(h => h.Nome == "Escudo de Pó");

        // Add attacks for new Pokémon (sample)
        if (!dbContext.Ataques.Any(a => a.Nome == "Water Gun"))
        {
            dbContext.Ataques.AddRange(
                new Ataque { Nome = "Water Gun", Categoria = "Especial", Descricao = "Dispara água ao adversário.", Dano = 40, Precisao = 100, PP = 25, Prioridade = 0, TipoFk = tipoAgua.Id },
                new Ataque { Nome = "Vine Whip", Categoria = "Físico", Descricao = "Ataca com vinhas finas.", Dano = 45, Precisao = 100, PP = 25, Prioridade = 0, TipoFk = tipoErva.Id },
                new Ataque { Nome = "String Shot", Categoria = "Status", Descricao = "Dispara seda para baixar a velocidade.", Dano = 0, Precisao = 95, PP = 40, Prioridade = 0, TipoFk = tipoInseto.Id }
            );
            dbContext.SaveChanges();
        }
        var waterGunVar = dbContext.Ataques.First(a => a.Nome == "Water Gun");
        var vineWhipVar = dbContext.Ataques.First(a => a.Nome == "Vine Whip");
        var stringShotVar = dbContext.Ataques.First(a => a.Nome == "String Shot");

        // Add evolutions for new Pokémon
        if (!dbContext.Evolucoes.Any(e => e.PokemonFk1 == ivysaurVar.Id))
        {
            dbContext.Evolucoes.AddRange(
                new Evolucao { Descricao = "Bulbasaur evolui para Ivysaur no nível 16.", PokemonFk1 = bulbasaurVar.Id, PokemonFk2 = ivysaurVar.Id },
                new Evolucao { Descricao = "Ivysaur evolui para Venusaur no nível 32.", PokemonFk1 = ivysaurVar.Id, PokemonFk2 = venusaurVar.Id },
                new Evolucao { Descricao = "Squirtle evolui para Wartortle no nível 16.", PokemonFk1 = squirtleVar.Id, PokemonFk2 = wartortleVar.Id },
                new Evolucao { Descricao = "Wartortle evolui para Blastoise no nível 36.", PokemonFk1 = wartortleVar.Id, PokemonFk2 = blastoiseVar.Id },
                new Evolucao { Descricao = "Caterpie evolui para Metapod no nível 7.", PokemonFk1 = caterpieVar.Id, PokemonFk2 = null } // Metapod to be added in next batch
            );
            dbContext.SaveChanges();
        }

        // Add Pokémon locations (sample)
        if (!dbContext.PokemonLocalizacoes.Any(pl => pl.PokemonFk == caterpieVar.Id))
        {
            dbContext.PokemonLocalizacoes.AddRange(
                new PokemonLocalizacao { PokemonFk = bulbasaurVar.Id, LocalizacaoFk = palletTownVar.Id },
                new PokemonLocalizacao { PokemonFk = squirtleVar.Id, LocalizacaoFk = palletTownVar.Id },
                new PokemonLocalizacao { PokemonFk = caterpieVar.Id, LocalizacaoFk = viridianCityVar.Id }
            );
            dbContext.SaveChanges();
        }
    }
}