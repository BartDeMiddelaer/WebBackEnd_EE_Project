using System.ComponentModel.DataAnnotations;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;

namespace Wba.EE.DeMiddelaerBart.Web.Models
{
    public class InPutEditAPokemonModel
    {
        [Required]
        [MaxLength(50)]
        public string NewName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string PokemonPictureUrl { get; set; }

        [Required]
        public int HealthPoints { get; set; }

        [Required]
        public int Mana { get; set; }

        [Required]
        public float Height { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public float BMI { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        public PokemonTypes Type { get; set; }

    }
}
