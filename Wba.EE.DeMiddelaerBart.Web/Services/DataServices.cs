using System;
using System.Collections.Generic;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using Newtonsoft.Json;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using System.Threading.Tasks;

namespace Wba.EE.DeMiddelaerBart.Web
{
    public static class DataServices
    {
        public static List<Pokemon> GetPokemonListFromDB(PokemonTypes prop, SiteContext db)
        {
            List<Pokemon> newDeck = new List<Pokemon>();
            Random rand = new Random();

            switch (prop)
            {
                case PokemonTypes.Alle:
                    newDeck = db.Pokemons.ToList();
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Normal:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Normal);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Fire:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Fire);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Water:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Water);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Electric:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Electric);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Grass:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Grass);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonTypes.Psychic:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Type == PokemonTypes.Psychic);
                    GiveSkillsFromDb(newDeck, db);
                    break;
            
                default:
                    break;
            }
          
            return newDeck;

        }
        public static List<Pokemon> GetPokemonListFromDB(PokemonPropery prop, float value, SiteContext db)
        {
            List<Pokemon> newDeck = new List<Pokemon>();
            Random rand = new Random();

            switch (prop)
            {              
                case PokemonPropery.Lvl:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Level == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                case PokemonPropery.BMI:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.BMI == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;
                case PokemonPropery.Weight:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Weight == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;
                case PokemonPropery.Height:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Height == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;
                case PokemonPropery.Mana:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.Mana == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;
                case PokemonPropery.Hp:
                    newDeck = db.Pokemons.ToList().FindAll(pokemon => pokemon.HealthPoints == value);
                    GiveSkillsFromDb(newDeck, db);
                    break;

                default:
                    break;
            }
            
            return newDeck;

        }
        public static List<Pokemon> GetRandomPokemonsFromDB(int aantal, SiteContext db)
        {
            int countOfAllePokemons = db.Pokemons.Count();
            List<Pokemon> newDeck = new List<Pokemon>();
            Random rand = new Random();

            Pokemon newPokemon = db.Pokemons.ToArray()[rand.Next(0, countOfAllePokemons)]; // <-- maat een rondom pokemon aandehand van countOfAllePokemons en random

            if (aantal > countOfAllePokemons) aantal = countOfAllePokemons; // <--- maakt dat je niet over countOfAllePokemons kan anders zit je vast in de while loop

            for (int i = 0; i < aantal; i++)
            {
                while (newDeck.Contains(newPokemon))
                    newPokemon = db.Pokemons.ToArray()[rand.Next(0, countOfAllePokemons)];

                newDeck.Add(newPokemon);
            }

            GiveSkillsFromDb(newDeck,db);
            return newDeck;
        }
        public static void GiveSkillsFromDb(List<Pokemon> newDeck, SiteContext db)
        {
            Random rand = new Random();

            foreach (var pokemon in newDeck)// <-- geeft skills aan deze pokemons
            {
                for (int c = 0; c < 2; c++)
                {
                    var countAlleSkills = db.Skills.ToList().FindAll(skills => skills.SkillType == pokemon.Type).Count();
                    var thisTypeSkillList = db.Skills.ToList().FindAll(skills => skills.SkillType == pokemon.Type);

                    if (countAlleSkills >= 2)
                    { 
                        List<Skill> newSkillList = new List<Skill>();
                        int newIndex = rand.Next(0, countAlleSkills); // random skill

                        while (newSkillList.Contains(thisTypeSkillList[newIndex]))// in het geval dat je 2keer de zelvde skill zoe hebben vraag je een nieuwe op
                            newIndex = rand.Next(0, countAlleSkills);

                        if(pokemon.ThisPokemonsSkills.Count() < 2) pokemon.ThisPokemonsSkills.Add(thisTypeSkillList[newIndex]);// <-- steekt de nieuwe random skill in de newSkillList
                                       
                    }
                    else pokemon.ThisPokemonsSkills.Add(GetEmptySkill(pokemon.Type));
                }

            }
        }
        public static Skill GetEmptySkill(PokemonTypes skillType)
        {
            return new Skill { 
                Acc=0,
                Dps=0,
                ManaCost=0,
                Name= "Empty",
                Effect="The Admin needs to meke some more skills Contect him if it takes to long",
                Pp=0,
                SkillType = skillType,
                Turns=0
            };
        }

       
        public static List<Pokemon> GetPreViewDeck(HttpContext currentHttpContext)
        {
            if(currentHttpContext.Session.GetString("priviewDeck") != null)
                return JsonConvert.DeserializeObject<List<Pokemon>>(currentHttpContext.Session.GetString("priviewDeck"));
            else
                return new List<Pokemon>();
        }
        public static void SetPreViewDeck(List<Pokemon> deck, HttpContext currentHttpContext)
        {
            currentHttpContext.Session.SetString("priviewDeck", JsonConvert.SerializeObject(deck));
        } 
        public static User GetUser(HttpContext currentHttpContext)
        {
            if (currentHttpContext.Session.GetString("UserInfo") != null)
                return JsonConvert.DeserializeObject<User>(currentHttpContext.Session.GetString("UserInfo"));
            else
                return null;
        }
        public static void SetUser(User user, HttpContext currentHttpContext)
        {
            currentHttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(user));
        }


        public static RedirectResult LogoutUser(HttpContext currentHttpContext)
        {
            currentHttpContext.Session.Clear();
            return new RedirectResult("~/Home/Index");
        }

        public static void SetPlayDeck(User user, SiteContext db, HttpContext currentHttpContext)
        {
            user.PlayDeck = new List<Pokemon>();

            List<PokemonCard> cardsOfUser = db.Cards.Where(card => card.User == user).ToList();

            cardsOfUser.ForEach(card => {

                var pokemon = db.Pokemons.ToList().Where(p => p.Id == card.PokemonId).FirstOrDefault();
                var skillOne = db.Skills.ToList().Where(s => s.Id == card.SkillOne).FirstOrDefault();
                var skillTwo = db.Skills.ToList().Where(s => s.Id == card.SkillTwo).FirstOrDefault();

                pokemon.ThisPokemonsSkills = new List<Skill> { skillOne, skillTwo };

                user.PlayDeck.Add(pokemon);
            });

            SetUser(user, currentHttpContext);
        }
        async public static Task UploadPlayDeckAsync(List<Pokemon> playDeck, SiteContext db, HttpContext currentHttpContext)
        {
            User findUser = db.Users.ToList()
               .Where(u => u.Name == GetUser(currentHttpContext).Name).FirstOrDefault();

            PokemonCard[] deleteCards = db.Cards.Where(card => card.User == findUser).ToArray();
            db.RemoveRange(deleteCards);

            playDeck.ToList().ForEach(card => {

                if(card != null)
                    db.Add(new PokemonCard{
                        User = findUser,
                        Pokemon = card,
                        SkillOne = card.ThisPokemonsSkills[0].Id,
                        SkillTwo = card.ThisPokemonsSkills[1].Id
                    });
            });

            await db.SaveChangesAsync();
            SetPlayDeck(findUser, db, currentHttpContext);
        }
    }
}
