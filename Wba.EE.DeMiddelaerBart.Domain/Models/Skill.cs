using System.ComponentModel.DataAnnotations;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;


namespace Wba.EE.DeMiddelaerBart.Domain.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required][MaxLength(25)]
        public string Name { get; set; }

        [Required][MaxLength(5)]
        public int ManaCost { get; set; }

        [Required][MaxLength(5)]
        public int Dps { get; set; }

        [Required][MaxLength(5)]
        public int Acc { get; set; }

        [Required][MaxLength(5)]
        public int Pp { get; set; }

        [Required][MaxLength(2)]
        public int Turns { get; set; }

        [Required][MaxLength(255)]
        public string Effect { get; set; }
       
        [Required]
        public PokemonTypes SkillType { get; set; }

        public int? PokemonId { get; set; }

    }
}
