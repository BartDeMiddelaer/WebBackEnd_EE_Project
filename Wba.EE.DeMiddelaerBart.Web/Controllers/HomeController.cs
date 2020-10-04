using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using static Wba.EE.DeMiddelaerBart.Web.DataServices;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;
using Microsoft.AspNetCore.Http;
using Wba.EE.DeMiddelaerBart.Domain.DataAccess;
using Wba.EE.DeMiddelaerBart.Web.Models;

namespace Wba.EE.DeMiddelaerBart.Web.Controllers
{
    public class HomeController : Controller
    {        
        readonly SiteContext _dataBase;
        readonly HttpContext _curentHttpContent;

        public HomeController(SiteContext db, IHttpContextAccessor httpContextAccessor)
        {
            _dataBase = db;
            _curentHttpContent = httpContextAccessor.HttpContext;          
        }


        public IActionResult Index()
        {
            if(GetPreViewDeck(_curentHttpContent).Count == 0)
                SetPreViewDeck(GetRandomPokemonsFromDB(5, _dataBase), _curentHttpContent);

            return View(new PlayerViewModel
            {
                ShowThisDeck = GetPreViewDeck(_curentHttpContent)
            });
        }
         

        [Route("Home/OutputDeck/{catogorie}/{value?}/{supValue:float?}")]
        public IActionResult OutputDeck(string catogorie, string value, float supValue)
        {
            switch (catogorie)
            {
                case "Index":
                    break;
                case "Alle":
                    SetPreViewDeck(GetPokemonListFromDB(PokemonTypes.Alle, _dataBase), _curentHttpContent);
                    break;

                case "Type":
                    PokemonTypes typeOf = Enum.Parse<PokemonTypes>(value);
                    SetPreViewDeck(GetPokemonListFromDB(typeOf, _dataBase), _curentHttpContent);
                    break;

                case "Generate":
                    int.TryParse(value, out int countOfPokemon);
                    SetPreViewDeck(GetRandomPokemonsFromDB(countOfPokemon, _dataBase), _curentHttpContent);
                    break;

                case "Property":
                    PokemonPropery propType = Enum.Parse<PokemonPropery>(value);
                    SetPreViewDeck(GetPokemonListFromDB(propType, supValue, _dataBase), _curentHttpContent);
                    break;

                case "SkillTypes":
                    PokemonTypes typeOfSkill = Enum.Parse<PokemonTypes>(value);
                    return View("SkillTypes", _dataBase.Skills.ToList().FindAll(skill => skill.SkillType == typeOfSkill));

                case "SingelCard":
                    Pokemon mon = _dataBase.Pokemons.ToList().Where(p => p.Name == value).FirstOrDefault();
                    mon.ThisPokemonsSkills = _dataBase.Skills.ToList().Where(s => s.SkillType == mon.Type).ToList();
                    SetPreViewDeck(new List<Pokemon> { mon } , _curentHttpContent);  
                    
                    return View("SingelCardPlusSkills", mon);

                default:
                    SetPreViewDeck(null, _curentHttpContent);
                    break;
            }

   
            return View(new PlayerViewModel {
                ShowThisDeck = GetPreViewDeck(_curentHttpContent)
            });
        }

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { 
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
        });
        
    }
}