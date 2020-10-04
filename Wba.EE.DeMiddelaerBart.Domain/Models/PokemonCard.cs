
namespace Wba.EE.DeMiddelaerBart.Domain.Models
{
    public class PokemonCard
    {
        public long Id { get; set; }

        public long? UserId { get; set; }
        public User User { get; set; }

        public int? PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int? SkillOne { get; set; }
        public int? SkillTwo { get; set; }

    }
}
