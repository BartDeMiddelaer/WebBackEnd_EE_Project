using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class MakeDeckController : Controller
    {
        readonly Random rand = new Random();
        readonly SiteContext dataBase;
        readonly HttpContext curentHttpContent;

        public MakeDeckController(SiteContext db, IHttpContextAccessor httpContextAccessor)
        {
            dataBase = db;
            curentHttpContent = httpContextAccessor.HttpContext;          
        }

        public IActionResult Index()
        {          
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<IActionResult> GetSelectidCards(int?[] indexOfcards)
        {          
            List<Pokemon> newDeck = new List<Pokemon>();
            // haalt alle indexsen uit indexOfcards arry en kent ze toe aan ActivePlayersDeck 
            // de index van pokedex in JS is het zelvde als alle indexen hier in pokedex
            // dus de geslecteerde kaart gaat de zevde index doorgeven in de string en kan zo weg gescreven worden naar ActivePlayersDeck

            for (int i = 0; i < indexOfcards.Length; i++)
            {
                if (indexOfcards[i] >= 0)
                {
                    if (int.TryParse(indexOfcards[i].ToString(), out int index))
                    {
                        Pokemon newPokemon = dataBase.Pokemons.ToArray()[index];
                        List<Skill> newSkillList = new List<Skill>();
                        List<Skill> thisTypeSkillList = dataBase.Skills.ToList().FindAll(skill => skill.SkillType == newPokemon.Type);
                        int countAlleSkills = thisTypeSkillList.Count();

                        // skill toekening ---> mss kan ik later nog een nieuwe view returnen hier zo dat ik ook alle skils kan kiezen
                        for (int c = 0; c < 2; c++)
                        {
                            if (dataBase.Skills.ToList().Where(skill => skill.SkillType == newPokemon.Type).Count() >= 2)
                            {
                                int newIndex = rand.Next(0, countAlleSkills);

                                while (newSkillList.Contains(thisTypeSkillList[newIndex]))
                                    newIndex = rand.Next(0, countAlleSkills);

                                newSkillList.Add(thisTypeSkillList[newIndex]);
                            }
                            else newSkillList.Add(GetEmptySkill(newPokemon.Type));

                        }

                        // Opvullen van ActivePlayersDeck + toekening skills van hierboven aan de pokemon
                        newPokemon.ThisPokemonsSkills = newSkillList;
                        newDeck.Add(newPokemon);
                    }
                }
            }
            await UploadPlayDeckAsync(newDeck,dataBase, curentHttpContent);

            return RedirectToAction(nameof(Index));
        }
    }

}