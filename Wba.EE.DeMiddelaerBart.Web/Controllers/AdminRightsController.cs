using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;
using Microsoft.AspNetCore.Http;
using Wba.EE.DeMiddelaerBart.Web.Models;
using System.Threading.Tasks;

namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class AdminRightsController : Controller
    {
        readonly SiteContext _dataBase;
        readonly HttpContext _curentHttpContent;

        public AdminRightsController(SiteContext db, IHttpContextAccessor httpContextAccessor)
        {
            _dataBase = db;
            _curentHttpContent = httpContextAccessor.HttpContext;
        }

        public IActionResult AdminCheak(ViewResult ifAdminGoTO)
        {
            if (GetUser(_curentHttpContent) != null)
                if (GetUser(_curentHttpContent).TypeOfUser == UserType.Admin)
                    return ifAdminGoTO;
                else
                    return Redirect("~/Home/Index"); ;

            return Redirect("~/Home/Index");
        }
        public IActionResult AdminPanel() => AdminCheak(View());
        public IActionResult AddASkill() => AdminCheak(View());
        public IActionResult EditAPokemon() => AdminCheak(View());
        public IActionResult DeleteAPokemon() => AdminCheak(View());
        public IActionResult NewPokemon() => AdminCheak(View(new InPutNewPokemonModel()));
        public IActionResult DeleteASkill()
        {
            var skillListToReturn = _dataBase.Skills.ToList();
            skillListToReturn.Sort((a, b) => a.SkillType.CompareTo(b.SkillType));

            return AdminCheak(View(skillListToReturn));
        }


        [HttpPost][ValidateAntiForgeryToken]
        async public Task<IActionResult> AddASkillProssesing(InPutAddSkillModel addSkillInput)
        {
            if (ModelState.IsValid && _dataBase.Skills.ToList().Where(skill => skill.Name == addSkillInput.Name).Count() == 0)
            {
                if (addSkillInput.SkillType != PokemonTypes.Alle)
                {
                    _dataBase.Add(new Skill
                    {
                        Acc = addSkillInput.Acc,
                        Turns = addSkillInput.Turns,
                        SkillType = addSkillInput.SkillType,
                        Dps = addSkillInput.Dps,
                        Effect = addSkillInput.Effect,
                        ManaCost = addSkillInput.ManaCost,
                        Name = addSkillInput.Name,
                        Pp = addSkillInput.Pp
                    });

                    await _dataBase.SaveChangesAsync();
                }
                else
                {
                    // loopt door alle PokemonTypes en voegt hier een skill voor toe
                    foreach (var type in Enum.GetValues(typeof(PokemonTypes)))
                    {
                        if((PokemonTypes)type != PokemonTypes.Alle)
                        _dataBase.Add(new Skill
                        {
                            Acc = addSkillInput.Acc,
                            Turns = addSkillInput.Turns,
                            SkillType = (PokemonTypes)type,
                            Dps = addSkillInput.Dps,
                            Effect = addSkillInput.Effect,
                            ManaCost = addSkillInput.ManaCost,
                            // geeft ook 1st lette van Type aan de naam Bv: F_NaamSkill
                            Name = $"{type.ToString().ToCharArray()[0].ToString()}_{addSkillInput.Name}",
                            Pp = addSkillInput.Pp
                        });
                    }

                    await _dataBase.SaveChangesAsync();
                }

                return RedirectToAction(nameof(AdminPanel));
            }
            else
            {
                if (_dataBase.Skills.ToList().Where(skill => skill.Name == addSkillInput.Name).Count() != 0)
                    ModelState.AddModelError("Name", "Skill Bestaat al");

                return View(addSkillInput);
            }
        }

        [HttpPost][ValidateAntiForgeryToken]
        async public Task<IActionResult> DeleteASkillProssesing(string[] listOfSkills)
        {        
            List<Skill> skillsToDelete = new List<Skill>();
            List<PokemonCard> CardsToDelete = new List<PokemonCard>();

            foreach (var skillName in listOfSkills)
            {
                if (skillName != null)
                {
                    // verwijdert de skills met de naam skillName uit de foreach
                    var skillFromDatabase = _dataBase.Skills.ToList().Where(skill => skill.Name == skillName).FirstOrDefault();
                    skillsToDelete.Add(skillFromDatabase);


                    // verwijdert PokemonCards uit DB die deze skills bevatten
                    if (skillFromDatabase != null)
                        _dataBase.Cards.ToList().ForEach(card =>
                        {                            
                            if (card.SkillOne == skillFromDatabase.Id || card.SkillTwo == skillFromDatabase.Id)
                            {
                                if (!CardsToDelete.Contains(card))
                                    CardsToDelete.Add(card);
                            }                                                     
                        });
                }
            }

            _dataBase.RemoveRange(CardsToDelete);
            _dataBase.RemoveRange(skillsToDelete);
            await _dataBase.SaveChangesAsync();

            return RedirectToAction(nameof(AdminPanel));
        }


        [HttpPost][ValidateAntiForgeryToken]
        async public Task<IActionResult> EditAPokemonProssesSucses(InPutEditAPokemonModel pokemon)
        {
            if (ModelState.IsValid)
            {
                if (pokemon.Type == PokemonTypes.Alle)
                {
                    ModelState.AddModelError("Type", "Je kan een pokemon niet alle types geven");
                    return View(pokemon);
                }

                var pokemonToUpdate = _dataBase.Pokemons.ToList().Where(p => p.Name == pokemon.Name).FirstOrDefault();

                pokemonToUpdate.Name = pokemon.NewName;
                pokemonToUpdate.Mana = pokemon.Mana;
                pokemonToUpdate.HealthPoints = pokemon.HealthPoints;
                pokemonToUpdate.Level = pokemon.Level;
                pokemonToUpdate.Type = pokemon.Type;
                pokemonToUpdate.PokemonPictureUrl = pokemon.PokemonPictureUrl;

                pokemonToUpdate.BMI = pokemon.Weight / (pokemon.Height * pokemon.Height);
                pokemonToUpdate.Height = pokemon.Height;
                pokemonToUpdate.Weight = pokemon.Weight;

                _dataBase.Update(pokemonToUpdate);
                await _dataBase.SaveChangesAsync();

                return RedirectToAction(nameof(AdminPanel));
            }

            return View(pokemon);
        }
        [HttpPost][ValidateAntiForgeryToken]
        public IActionResult EditAPokemonProsses(string[] pokemonNames)
        {
            // je bewerkt maar 1 pokemon en het script selecteert er maar een en het zit op de 1ste positie van de arry
            string nameOfPokemonToEdit = pokemonNames[0];

            Pokemon selectidPokemon = nameOfPokemonToEdit != null
                ? _dataBase.Pokemons.ToList().Where(p => p.Name == nameOfPokemonToEdit).FirstOrDefault()
                : null;

            // geeft het door aan de View die het dan door geeft aan EditAPokemonProssesSucses indien alle juist is
            if (nameOfPokemonToEdit != null)
                return View(new InPutEditAPokemonModel
                {
                    NewName = selectidPokemon.Name,
                    Name = selectidPokemon.Name,
                    Mana = selectidPokemon.Mana,
                    HealthPoints = selectidPokemon.HealthPoints,
                    Level = selectidPokemon.Level,
                    Type = selectidPokemon.Type,
                    PokemonPictureUrl = selectidPokemon.PokemonPictureUrl,

                    BMI = selectidPokemon.BMI,
                    Height = selectidPokemon.Height,
                    Weight = selectidPokemon.Weight,
                });

            else
                return RedirectToAction(nameof(AdminPanel));
        }


        [HttpPost][ValidateAntiForgeryToken]
        async public Task<IActionResult> DeleteAPokemonProsses(string[] pokemonNames)
        {            
            List<Pokemon> pokemonsToDelete = new List<Pokemon>();
            List<PokemonCard> CardsToDelete = new List<PokemonCard>();
            List<Skill> skillsToUpdate = new List<Skill>();

            pokemonNames.ToList().ForEach(name => {
                if (name != null)
                {
                    var pokemon = _dataBase.Pokemons.ToList().Where(p => p.Name == name).FirstOrDefault();
                    var skills = _dataBase.Skills.Where(s => s.PokemonId == pokemon.Id);
                    var cards = _dataBase.Cards.Where(c => c.PokemonId == pokemon.Id);

                    pokemonsToDelete.Add(pokemon);
                    skillsToUpdate.AddRange(skills);
                    CardsToDelete.AddRange(cards);
                }
            });

            skillsToUpdate.ForEach(skill => skill.PokemonId = null);

            _dataBase.UpdateRange(skillsToUpdate);
            _dataBase.RemoveRange(CardsToDelete);
            _dataBase.RemoveRange(pokemonsToDelete);
            await _dataBase.SaveChangesAsync();


            return RedirectToAction(nameof(AdminPanel));
        }


        [HttpPost][ValidateAntiForgeryToken]
        async public Task<IActionResult> NewPokemonSucses(InPutNewPokemonModel pokemon)
        {          
            // voorwaarden --------------------------------------------------------------------------------
            if (_dataBase.Pokemons.ToList().Where(dbPokemon => dbPokemon.Name == pokemon.Name).Count() != 0)
                ModelState.AddModelError("Name", "Pokemon Bestaat al");
            if (pokemon.Height == 0)
                ModelState.AddModelError("Height", "Height kan niet 0 zijn");
            if (pokemon.Weight == 0)
                ModelState.AddModelError("Weight", "Weight kan niet 0 zijn");
            //---------------------------------------------------------------------------------------------

            if (ModelState.IsValid)
            {
                if (pokemon.Type == PokemonTypes.Alle)
                {
                    ModelState.AddModelError("Type", "Je kan een pokemon niet alle types geven");
                    return View(pokemon);
                }

                var newPokemon = new Pokemon{
                    Name = pokemon.Name,
                    Mana = pokemon.Mana,
                    HealthPoints = pokemon.HealthPoints,
                    Level = pokemon.Level,
                    Type = pokemon.Type,
                    PokemonPictureUrl = pokemon.PokemonPictureUrl,
                    Height = pokemon.Height,
                    Weight = pokemon.Weight
                };

                newPokemon.BMI = pokemon.Weight / (pokemon.Height * pokemon.Height);

                await _dataBase.AddAsync(newPokemon);
                await _dataBase.SaveChangesAsync();

                return RedirectToAction(nameof(AdminPanel));
            }
            
            return View(pokemon);
        }

    }
}