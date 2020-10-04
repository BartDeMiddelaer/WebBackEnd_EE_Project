using System.ComponentModel.DataAnnotations;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;

namespace Wba.EE.DeMiddelaerBart.Web.Models
{
    public class InPutAddSkillModel
    {

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public int ManaCost { get; set; }

        [Required]
        public int Dps { get; set; }

        [Required]
        public int Acc { get; set; }

        [Required]
        public int Pp { get; set; }

        [Required]
        public int Turns { get; set; }

        [Required]
        [MaxLength(255)]
        public string Effect { get; set; }

        [Required]
        public PokemonTypes SkillType { get; set; }


    }
}
