using System.Collections.Generic;
using Wba.EE.DeMiddelaerBart.Domain.Models;
using System.ComponentModel.DataAnnotations;


namespace Wba.EE.DeMiddelaerBart.Web.Models
{
    public class SearchResultModel
    {
        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<User> Users { get; set; } = new List<User>();

        [Display(Name = "Zoek: ")]
        public string Zoekterm { get; set; }
    }
}
