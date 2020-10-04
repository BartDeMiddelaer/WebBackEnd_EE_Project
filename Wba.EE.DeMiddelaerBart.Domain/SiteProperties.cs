using System.ComponentModel.DataAnnotations;

namespace Wba.EE.DeMiddelaerBart.Domain
{
    public static class SiteProperties
    {

        // SitePropertys / GamePropertys ---------------------------------------------------------------------------------
        public static int AvatarCount { get; set; } = 14; // <---  aantal files in /images/Avatars/avatar{Number}.svg
        public static int TeamCount { get; set; } = 3; // <--- aantal files in /images/Teams/team{Number}.svg
        public static int CountOfCardsToBattelWhit { get; set; } = 6; // <--- aantal kaarten dat je krijgt om te battelen
        public static int HpOfBoss { get; set; } = 1000; // <-- Hp van de baas waar je tegen vecht met je kaarten
        public static string CardSelectColorOne { get; set; } = "rgb(50, 250, 50)";
        public static string CardSelectColorTwo { get; set; } = "rgb(50, 220, 50)";
        public static int PasswordSaldLeght { get; set; } = 15;


        public enum PokemonTypes
        {
            // ^^ ^^ type pokemons        
            Normal,
            Fire,
            Water,
            Electric,
            Grass,
            Psychic,
            Alle
        };
        public enum SkillsEffect
        {
            // ^^ the skills effect 'SFX' 
            None,// Standaart
            MultiTurns,
            Stun, // kans om te stunnen
            Slow,
            Burns,
            AttackUp,
            SpeedUp,
            LowerBossSpeed,
            LowerBossDPS,
            MoreDpsIfBossBelowHaffHp,
            HpDrain, // je kaart krijgt de helft terug van de dps dat hij doet met deze kill als HP
            ConfuseBoss // boss doet DPS tegen zich zelf
        }
        public enum UserType
        {
            Admin,
            User
        }
        public enum PokemonPropery
        {
            Lvl,
            BMI,
            Weight,
            Height,
            Mana,
            Hp
        }
        public enum Genders {
            Man,
            Womman, 
            Unic,
            Potato,
            [Display(Name = "Patchy Helicopter")]
            PatchyHelicopter,
            Cyborg
        }      
    }
}
