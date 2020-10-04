using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;


namespace Wba.EE.DeMiddelaerBart.Domain.Models
{
    public class Pokemon  
    {
        [Required][MaxLength(50)]
        public string Name { get; set; }

        [Required][MaxLength(250)]
        public string PokemonPictureUrl { get; set; }

        [Required][MaxLength(5)]
        public int HealthPoints { get; set; }

        [Required][MaxLength(5)]
        public int Mana { get; set; }

        [Required][MaxLength(5)]
        public float Height { get; set; }

        [Required][MaxLength(5)]
        public float Weight { get; set; }

        [Required][MaxLength(5)]
        public float BMI { get; set; }

        [Required][MaxLength(5)]
        public int Level { get; set; }

        [Required]
        public PokemonTypes Type { get; set; }

        public List<Skill> ThisPokemonsSkills { get; set; } = new List<Skill>();


        public int Id { get; set; }

    }
}
