using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;
using static Wba.EE.DeMiddelaerBart.Domain.EncryptionServise;


namespace Wba.EE.DeMiddelaerBart.Domain.DataAccess
{
    public class SiteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonCard> Cards { get; set; }

        public SiteContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            GetAllePokemonsFromCatolog(modelBuilder);
            GetAlleSkillsFromCatolog(modelBuilder);
            GetMockUpUsers(modelBuilder);
        
            base.OnModelCreating(modelBuilder);
        }

        private void GetMockUpUsers(ModelBuilder modelBuilder)
        {
            int idTeller = 1;

            User admin = new User
            {
                Id = 1,
                TypeOfUser = UserType.Admin,
                Name = "a",
                PasswordSalt = CreateSalt(PasswordSaldLeght),
                Country = "Belgium",
                Email = "OtenToten@Tontoonstelling.com",
                DayOfBirth = new DateTime(1920, 02, 15),
                GenderId = 5,
                Bio = @"So perhaps, you've generated some fancy text, and you're content
                    that you can now copy and paste your fancy text in the comments section of funny cat videos,
                    but perhaps you're wondering how it's even possible to
                    change the font of your text? Is it some sort of hack? 
                    Are you copying and pasting an actual font?

                    Well, the answer is actually no - rather than generating fancy fonts, this converter creates fancy 
                    symbols. The explanation starts with unicode; an industry standard which creates the specification for 
                    thousands of different symbols and characters. All the characters that you see on your electronic devices,
                    and printed in books, are likely specified by the unicode standard.",
                PhoneNumber = "0499855224",
                IndexOfAvatarSelectit = 1,
                IndexOfTeamSelectit = 1,
                HighScore = 1024
            };
            admin.Password = GenerateHash("a", admin.PasswordSalt);
            modelBuilder.Entity<User>().HasData(admin);

            for (int c = 0; c < new Random().Next(1, 7); c++)
            {
                modelBuilder.Entity<PokemonCard>().HasData(new PokemonCard
                {
                    Id = idTeller,
                    UserId = admin.Id,
                    PokemonId = new Random().Next(1, new PokeDexDBFiller().AlleThePokemon.Count),
                    SkillOne = 1,
                    SkillTwo = 2
                });

                idTeller++;
            }

            for (int i = 2; i <= 15; i++)
            {
                User seedUser = new User
                {
                    Id = i,
                    TypeOfUser = UserType.User,
                    Name = $"Seed User {i}",
                    PasswordSalt = CreateSalt(PasswordSaldLeght),
                    Country = "Belgium",
                    Email = "OtenToten@Tontoonstelling.com",
                    DayOfBirth = new DateTime(1920, 02, 15),
                    GenderId = new Random().Next(1, 5),
                    Bio = @"So perhaps, you've generated some fancy text, and you're content
                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                but perhaps you're wondering how it's even possible to
                                change the font of your text? Is it some sort of hack? 
                                Are you copying and pasting an actual font?
                    ",

                    PhoneNumber = $"04998552{i}",
                    IndexOfAvatarSelectit = new Random().Next(1, 15),
                    IndexOfTeamSelectit = new Random().Next(1, 4),
                    HighScore = new Random().Next(0, 1000)
                };
                seedUser.Password = GenerateHash($"SeedUser{i}", seedUser.PasswordSalt);
                modelBuilder.Entity<User>().HasData(seedUser);

                for (int c = 0; c < new Random().Next(1, 7); c++)
                {
                    modelBuilder.Entity<PokemonCard>().HasData(new PokemonCard
                    {
                        Id = idTeller,
                        UserId = seedUser.Id,
                        PokemonId = new Random().Next(1, new PokeDexDBFiller().AlleThePokemon.Count),
                        SkillOne = 1,
                        SkillTwo = 2
                    });

                    idTeller++;
                }
                
            }

        }
        private void GetAllePokemonsFromCatolog(ModelBuilder modelBuilder)
        {
            List<PokemonCatolog> catologPokemon = new PokeDexDBFiller().AlleThePokemon;

            for (int i = 0; i < catologPokemon.Count; i++)
            {
                modelBuilder.Entity<Pokemon>().HasData(new Pokemon()
                {
                    Id = 1 + i,
                    Name = catologPokemon[i].Name,
                    PokemonPictureUrl = catologPokemon[i].PokemonPictureUrl,
                    HealthPoints = catologPokemon[i].HealthPoints,
                    Mana = catologPokemon[i].Mana,
                    Height = catologPokemon[i].Height,
                    Weight = catologPokemon[i].Weight,
                    BMI = catologPokemon[i].BMI,
                    Level = catologPokemon[i].Level,
                    Type = catologPokemon[i].Type                   
                });
            }
        }
        private void GetAlleSkillsFromCatolog(ModelBuilder modelBuilder)
        {
            var catologSkills = new PokeDexDBFiller().AllSkills;

            for (int i = 0; i < catologSkills.Count; i++)
            {
                modelBuilder.Entity<Skill>().HasData(new Skill()
                {
                    Id = i + 1,
                    Name = catologSkills[i].Name,
                    ManaCost = catologSkills[i].ManaCost,
                    Dps = catologSkills[i].Dps,
                    Acc = catologSkills[i].Acc,
                    Pp = catologSkills[i].Pp,
                    Turns = catologSkills[i].Turns,
                    Effect = catologSkills[i].Effect,
                    SkillType = catologSkills[i].SkillType
                });
            };
        }
    }
}