using System.Collections.Generic;

namespace Wba.EE.DeMiddelaerBart.Domain
{
    // hier worden alle objecten aangemaakt als het gaat over PokemonTemps of skills 
    public class PokeDexDBFiller
    {
        public List<SkillCatolog> AllSkills { get; set; } = new List<SkillCatolog>() {
            // Normal SkillsTemp -------------------------------------------------------------------------------------------------------
            new SkillCatolog().Constrict(),   new SkillCatolog().Barrage(),     new SkillCatolog().Bind(),            new SkillCatolog().DoubleSlap(),
            new SkillCatolog().FuryAttack(),  new SkillCatolog().Wrap(),        new SkillCatolog().CometPunch(),      new SkillCatolog().FurySwipes(),
            new SkillCatolog().Rage(),        new SkillCatolog().RapidSpin(),   new SkillCatolog().SpikeCannon(),     new SkillCatolog().TailSlap(),
            new SkillCatolog().Feint(),       new SkillCatolog().DoubleHit(),   new SkillCatolog().EchoedVoice(),     new SkillCatolog().FakeOut(),
            new SkillCatolog().FalseSwipe(),  new SkillCatolog().HoldBack(),    new SkillCatolog().PayDay(),          new SkillCatolog().Pound(),

            // Fire SkillsTemp ---------------------------------------------------------------------------------------------------------
            new SkillCatolog().FireSpin(),    new SkillCatolog().Incinerate(),  new SkillCatolog().FlameBurst(),      new SkillCatolog().FirePunch(),
            new SkillCatolog().Ember(),       new SkillCatolog().FlameWheel(),  new SkillCatolog().MysticalFire(),    new SkillCatolog().FieryDance(),
            new SkillCatolog().FlameCharge(), new SkillCatolog().FireFang(),

            // Water SkillsTemp --------------------------------------------------------------------------------------------------------
            new SkillCatolog().WaterShuriken(),   new SkillCatolog().Bubble(),     new SkillCatolog().WaterPulse(),   new SkillCatolog().BubbleBeam(),
            new SkillCatolog().Clamp(),           new SkillCatolog().WaterGun(),   new SkillCatolog().Octazooka(),    new SkillCatolog().Brine(),
            new SkillCatolog().Whirlpool(),       new SkillCatolog().AquaJet(),

            // Electric SkillsTemp -----------------------------------------------------------------------------------------------------
            new SkillCatolog().Nuzzle(),          new SkillCatolog().ZippyZap(),    new SkillCatolog().ParabolicCharge(),   new SkillCatolog().ThunderFang(),
            new SkillCatolog().ThunderShock(),    new SkillCatolog().Electroweb(),  new SkillCatolog().Spark(),             new SkillCatolog().VoltSwitch(),
            new SkillCatolog().ChargeBeam(),      new SkillCatolog().ShockWave(),   new SkillCatolog().ThunderPunch(),      new SkillCatolog().Discharge(),
            new SkillCatolog().Overdrive(),

            // Grass SkillsTemp --------------------------------------------------------------------------------------------------------
            new SkillCatolog().Absorb(),        new SkillCatolog().Leafage(),    new SkillCatolog().RazorLeaf(),   new SkillCatolog().LeafTornado(),
            new SkillCatolog().BulletSeed(),    new SkillCatolog().MegaDrain(),  new SkillCatolog().MagicalLeaf(), new SkillCatolog().TropKick(),
            new SkillCatolog().SnapTrap(),      new SkillCatolog().VineWhip(),   new SkillCatolog().NeedleArm(),   new SkillCatolog().GigaDrain(),
            new SkillCatolog().BranchPoke(),

            // Psychic SkillsTemp -------------------------------------------------------------------------------------------------------
            new SkillCatolog().StoredPower(),  new SkillCatolog().PsychoCut(),    new SkillCatolog().ZenHeadbutt(),    
            new SkillCatolog().Confusion(),    new SkillCatolog().MistBall(),     new SkillCatolog().HyperspaceHole(),    
            new SkillCatolog().Extrasensory(), new SkillCatolog().HeartStamp(),   new SkillCatolog().LusterPurge(), 
            new SkillCatolog().Psyshock(),     new SkillCatolog().Psybeam()
        };


        public List<PokemonCatolog> AlleThePokemon { get; set; } = new List<PokemonCatolog>() {
            new PokemonCatolog().Bellsprout(), new PokemonCatolog().Abra(),           new PokemonCatolog().Bulbasaur(),
            new PokemonCatolog().Caterpie(),   new PokemonCatolog().Charmander(),     new PokemonCatolog().Dratini(),    new PokemonCatolog().Eevee(),
            new PokemonCatolog().Jigglypuff(), new PokemonCatolog().Meowth(),         new PokemonCatolog().Pidgey(),     new PokemonCatolog().Pikachu(),
            new PokemonCatolog().Psyduck(),    new PokemonCatolog().Rattata(),        new PokemonCatolog().Snorlax(),    new PokemonCatolog().Squirtle(),
            new PokemonCatolog().Venonat(),    new PokemonCatolog().Weedle(),         new PokemonCatolog().Mew(),        new PokemonCatolog().Zubat(),
            new PokemonCatolog().Ditto(),      new PokemonCatolog().Exeggutor(),      new PokemonCatolog().Sudowoodo(),  new PokemonCatolog().Staryu(),
            new PokemonCatolog().Magnemite(),  new PokemonCatolog().Gastly(),         new PokemonCatolog().Gloom(),      new PokemonCatolog().Hoothoot(),
            new PokemonCatolog().Marill(),     new PokemonCatolog().Teddiursa(),      new PokemonCatolog().Voltorb(),    new PokemonCatolog().Oddish(),
            new PokemonCatolog().Duskull(),    new PokemonCatolog().Poliwhirl(),      new PokemonCatolog().Sunkern(),    new PokemonCatolog().Sentret(),
            new PokemonCatolog().Ledyba(),     new PokemonCatolog().Wailmer()
        };
    }
}
