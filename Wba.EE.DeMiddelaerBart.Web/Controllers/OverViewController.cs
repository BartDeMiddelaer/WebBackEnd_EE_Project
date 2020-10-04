using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using Wba.EE.DeMiddelaerBart.Web.Models;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;


namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class OverViewController : Controller
    {
        readonly SiteContext _dataBase;
        readonly HttpContext _curentHttpContent;

        public OverViewController(SiteContext db, IHttpContextAccessor httpContextAccessor)
        {
            _dataBase = db;
            _curentHttpContent = httpContextAccessor.HttpContext;
        }

        public IActionResult Index() => View();


        [HttpPost]
        public IActionResult SearchResult(SearchResultModel model)
        {
            List<User> userSearchResult = new List<User>();
            List<Pokemon> pokemonSearchResult = new List<Pokemon>();
            List<Skill> skillsSearchResult = new List<Skill>();

            // als er niet word ingevult zoek je op ""
            model.Zoekterm = model?.Zoekterm ?? "";
        
            // als je niet bent ingelogt zie je geen gebruikers
            if (GetUser(_curentHttpContent) != null)
            {
                _dataBase.Users.ToList().ForEach(u => {

                    if (u.Name.ToLower().Contains(model.Zoekterm.ToLower()) && !userSearchResult.Contains(u))
                        userSearchResult.Add(u);

                    if (u.HighScore.ToString().ToLower() == model.Zoekterm.ToLower() && !userSearchResult.Contains(u))
                        userSearchResult.Add(u);
                });

                model.Users = userSearchResult;
            }

            _dataBase.Pokemons.ToList().ForEach(p => {

                if (p.Name.ToLower().Contains(model.Zoekterm.ToLower()) && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.HealthPoints.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.Mana.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.Height.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.BMI.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.Level.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                if (p.Type.ToString().ToLower() == model.Zoekterm.ToLower() && !pokemonSearchResult.Contains(p))
                    pokemonSearchResult.Add(p);

                model.Pokemons = pokemonSearchResult;
            });

            _dataBase.Skills.ToList().ForEach(s => {

                if (s.Name.ToLower().Contains(model.Zoekterm) && !skillsSearchResult.Contains(s))
                    skillsSearchResult.Add(s);

                if (s.ManaCost.ToString().ToLower() == model.Zoekterm && !skillsSearchResult.Contains(s))
                    skillsSearchResult.Add(s);

                if (s.Dps.ToString().ToLower() == model.Zoekterm && !skillsSearchResult.Contains(s))
                    skillsSearchResult.Add(s);

                if (s.SkillType.ToString().ToLower() == model.Zoekterm && !skillsSearchResult.Contains(s))
                    skillsSearchResult.Add(s);

                model.Skills = skillsSearchResult;
            });

            pokemonSearchResult.ForEach(p => p.ThisPokemonsSkills.Clear());

            return View(new SearchResultModel
            {
                Users = userSearchResult,
                Pokemons = pokemonSearchResult,
                Skills = skillsSearchResult,
                Zoekterm = model.Zoekterm
            });

        }

    }   
}