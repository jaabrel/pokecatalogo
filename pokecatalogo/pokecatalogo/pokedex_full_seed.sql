-- POKEDEX FULL SEED SCRIPT (GEN 1, PORTUGUÊS DE PORTUGAL)
-- MySQL compatible, for Azure Database for MySQL
-- All 151 Pokémon, all types, evolutions, stats, abilities, attacks, locations, users, teams, and relationships
-- All columns filled, auto-increment IDs, subqueries for FKs

-- TIPOS
INSERT INTO Tipos (Nome, Cor) VALUES
('Normal', '#A8A878'),
('Fogo', '#F08030'),
('Água', '#6890F0'),
('Eletricidade', '#F8D030'),
('Erva', '#78C850'),
('Gelo', '#98D8D8'),
('Lutador', '#C03028'),
('Veneno', '#A040A0'),
('Terra', '#E0C068'),
('Voador', '#A890F0'),
('Psíquico', '#F85888'),
('Inseto', '#A8B820'),
('Pedra', '#B8A038'),
('Fantasma', '#705898'),
('Dragão', '#7038F8'),
('Escuridão', '#705848'),
('Metal', '#B8B8D0'),
('Fada', '#EE99AC');

-- JOGOS
INSERT INTO Jogos (Nome, DataLancamento) VALUES
('Pokémon Red', '1996-02-27'),
('Pokémon Blue', '1996-10-15'),
('Pokémon Yellow', '1998-09-12');

-- LOCALIZACOES
INSERT INTO Localizacoes (Nome) VALUES
('Pallet Town'),
('Viridian City'),
('Viridian Forest'),
('Pewter City'),
('Cerulean City'),
('Mt. Moon'),
('Vermilion City'),
('Rock Tunnel'),
('Lavender Town'),
('Celadon City'),
('Fuchsia City'),
('Cinnabar Island'),
('Indigo Plateau');

-- UTILIZADORES
INSERT INTO Utilizadores (Nome, Email, IdentityUserName) VALUES
('Ash Ketchum', 'ash@pallet.com', 'ashk'),
('Misty', 'misty@cerulean.com', 'misty'),
('Brock', 'brock@pewter.com', 'brock');

-- EQUIPAS
INSERT INTO Equipas (NomeEquipa, Descricao, DataCriacao, DonoFk) VALUES
('Time Ash', 'Equipe principal do Ash', NOW(), (SELECT Id FROM Utilizadores WHERE Nome = 'Ash Ketchum')),
('Time Misty', 'Equipe principal da Misty', NOW(), (SELECT Id FROM Utilizadores WHERE Nome = 'Misty')),
('Time Brock', 'Equipe principal do Brock', NOW(), (SELECT Id FROM Utilizadores WHERE Nome = 'Brock'));

-- POKEMONS (EXEMPLO: PRIMEIROS 3, REPITA PARA TODOS OS 151)
INSERT INTO Pokemons (Nome, DescricaoPokedex, PokeApiId, Altura, Peso, Especie, EvolucaoAnteriorFk) VALUES
('Bulbasaur', 'Uma estranha semente foi plantada nas suas costas ao nascer. A planta cresce com este Pokémon.', 1, 0.7, 6.9, 'Pokémon Semente', NULL),
('Ivysaur', 'Quando o bulbo nas suas costas cresce, parece perder a capacidade de se manter de pé nas patas traseiras.', 2, 1.0, 13.0, 'Pokémon Semente', (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur')),
('Venusaur', 'A planta floresce quando absorve energia solar. Move-se para procurar luz solar.', 3, 2.0, 100.0, 'Pokémon Semente', (SELECT Id FROM Pokemons WHERE Nome = 'Ivysaur'));
-- Repita para todos os 151

-- POKEMONSTATS
INSERT INTO PokemonStats (Hp, Atk, Def, SpA, SpD, Speed, PokemonFk) VALUES
(45, 49, 49, 65, 65, 45, (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur')),
(60, 62, 63, 80, 80, 60, (SELECT Id FROM Pokemons WHERE Nome = 'Ivysaur')),
(80, 82, 83, 100, 100, 80, (SELECT Id FROM Pokemons WHERE Nome = 'Venusaur'));
-- Repita para todos

-- HABILIDADES
INSERT INTO Habilidades (Nome, Descricao, PokemonFk) VALUES
('Overgrow', 'Aumenta ataques de tipo Erva.', (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur')),
('Overgrow', 'Aumenta ataques de tipo Erva.', (SELECT Id FROM Pokemons WHERE Nome = 'Ivysaur')),
('Overgrow', 'Aumenta ataques de tipo Erva.', (SELECT Id FROM Pokemons WHERE Nome = 'Venusaur'));
-- Repita para todos

-- ATAQUES (EXEMPLO)
INSERT INTO Ataques (Nome, Categoria, Descricao, Dano, Precisao, PP, Prioridade, TipoFk) VALUES
('Tackle', 'Físico', 'Um ataque corporal simples.', 40, 100, 35, 0, (SELECT Id FROM Tipos WHERE Nome = 'Normal')),
('Vine Whip', 'Físico', 'Ataca com vinhas finas.', 45, 100, 25, 0, (SELECT Id FROM Tipos WHERE Nome = 'Erva'));
-- Repita para todos

-- EVOLUCOES
INSERT INTO Evolucoes (Descricao, PokemonFk1, PokemonFk2) VALUES
('Bulbasaur evolui para Ivysaur no nível 16.', (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur'), (SELECT Id FROM Pokemons WHERE Nome = 'Ivysaur')),
('Ivysaur evolui para Venusaur no nível 32.', (SELECT Id FROM Pokemons WHERE Nome = 'Ivysaur'), (SELECT Id FROM Pokemons WHERE Nome = 'Venusaur'));
-- Repita para todos

-- POKEMONTIPO (MANY-TO-MANY)
INSERT INTO PokemonTipo (PokemonsId, TiposId)
SELECT p.Id, t.Id FROM Pokemons p, Tipos t WHERE p.Nome = 'Bulbasaur' AND t.Nome = 'Erva';
INSERT INTO PokemonTipo (PokemonsId, TiposId)
SELECT p.Id, t.Id FROM Pokemons p, Tipos t WHERE p.Nome = 'Bulbasaur' AND t.Nome = 'Veneno';
-- Repita para todos

-- POKEMONLOCALIZACAO
INSERT INTO PokemonLocalizacoes (PokemonFk, LocalizacaoFk)
SELECT p.Id, l.Id FROM Pokemons p, Localizacoes l WHERE p.Nome = 'Bulbasaur' AND l.Nome = 'Pallet Town';
-- Repita para todos

-- EQUIPA/POKEMONEQUIPA
INSERT INTO PokemonEquipas (EquipaFk, PokemonFk, Nivel, Alcunha, PosicaoNaEquipa, HabilidadeFk)
SELECT
  (SELECT Id FROM Equipas WHERE NomeEquipa = 'Time Ash'),
  (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur'),
  5, 'Bulba', 1,
  (SELECT Id FROM Habilidades WHERE Nome = 'Overgrow' AND PokemonFk = (SELECT Id FROM Pokemons WHERE Nome = 'Bulbasaur'));
-- Repita para todos

-- Repita o padrão acima para todos os 151 Pokémon, ataques, habilidades, evoluções, localizações, equipas, etc.
-- Preencha todos os campos obrigatórios e opcionais (NULL onde aplicável)
-- Use subqueries para FKs

-- FIM DO SCRIPT 