using System;
using System.Collections.Generic;
using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;


namespace Wba.EE.DeMiddelaerBart.Domain
{
    public class PokemonCatolog
    {
        #region Props
        // gegevens van de PokemonTemp als je een new PokemonTemp aan maakt BV "new PokemonTemp().Abra();"
        // Properys ---------------------------------------------------------------------------
        public string Name { get; set; }
        public PokemonTypes Type { get; set; }
        public string PokemonPictureUrl { get; set; }
        public int HealthPoints { get; set; }
        public int Mana { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float BMI { get; set; }
        public List<SkillCatolog> PokemonSkills { get; set; } = new List<SkillCatolog>();
        public int Level { get; set; }

        #endregion

        // prototype om PokemonTempsopte geven
        PokemonCatolog ProtoType(string name, int hp, float height, float weight, float bmi, PokemonTypes pType) => new PokemonCatolog
        {
            Name = name, // <-- naam van PokemonTemp
            Type = pType, // <-- het type van de PokemonTemp
            PokemonPictureUrl = $"/images/Pokemon/{name}.svg", // <--- url naar de image file

            HealthPoints = hp, //< -- aantal hp
            Mana = 160, // <-- mana standaart 160

            Height = height, // <-- groot van de mokemon
            Weight = weight,// <-- Gewicht van de mokemon
            BMI = bmi, // <-- BMI van de mokemon
            Level = new Random().Next(10,30)
        };

        // het toevoegen van PokemonTemps gebuirt hier voor de rest moet je niets doen alles 
        // word aangepast alsje iets toevoegt verwijdert of aanpast hier
        #region PokemonTemp
        public PokemonCatolog Abra() => ProtoType("Abra", 300, 0.6f, 7.0f, 19.4f, PokemonTypes.Psychic);
        public PokemonCatolog Bellsprout() => ProtoType("Bellsprout", 400, 0.7f, 4.0f, 8.2f, PokemonTypes.Grass);
        public PokemonCatolog Bulbasaur() => ProtoType("Bulbasaur", 400, 0.7f, 6.9f, 14.1f, PokemonTypes.Grass);
        public PokemonCatolog Caterpie() => ProtoType("Caterpie", 400, 0.3f, 6.4f, 32.2f, PokemonTypes.Grass);
        public PokemonCatolog Charmander() => ProtoType("Charmander", 500, 0.6f, 18.7f, 23.6f, PokemonTypes.Fire);
        public PokemonCatolog Dratini() => ProtoType("Dratini", 400, 1.8f, 3.3f, 1.0f, PokemonTypes.Water);
        public PokemonCatolog Eevee() => ProtoType("Eevee", 500, 0.3f, 6.5f, 72.2f, PokemonTypes.Normal);
        public PokemonCatolog Jigglypuff() => ProtoType("Jigglypuff", 600, 0.5f, 5.5f, 22.0f, PokemonTypes.Normal);
        public PokemonCatolog Meowth() => ProtoType("Meowth", 500, 0.4f, 4.2f, 26.3f, PokemonTypes.Normal);
        public PokemonCatolog Pidgey() => ProtoType("Pidgey", 400, 0.3f, 1.5f, 20.0f, PokemonTypes.Normal);
        public PokemonCatolog Pikachu() => ProtoType("Pikachu", 400, 0.4f, 6.0f, 37.5f, PokemonTypes.Electric);
        public PokemonCatolog Psyduck() => ProtoType("Psyduck", 500, 0.8f, 19.6f, 30.6f, PokemonTypes.Water);
        public PokemonCatolog Rattata() => ProtoType("Rattata", 300, 0.3f, 3.5f, 38.9f, PokemonTypes.Normal);
        public PokemonCatolog Snorlax() => ProtoType("Snorlax", 900, 2.1f, 1014.1f, 104.3f, PokemonTypes.Normal);
        public PokemonCatolog Squirtle() => ProtoType("Squirtle", 400, 0.5f, 19.8f, 36.0f, PokemonTypes.Water);
        public PokemonCatolog Venonat() => ProtoType("Venonat", 400, 1.0f, 30.0f, 30.0f, PokemonTypes.Grass);
        public PokemonCatolog Weedle() => ProtoType("Weedle", 400, 0.3f, 3.2f, 35.6f, PokemonTypes.Grass);
        public PokemonCatolog Mew() => ProtoType("Mew", 400, 0.4f, 4.0f, 25.0f, PokemonTypes.Psychic);
        public PokemonCatolog Zubat() => ProtoType("Zubat", 400, 0.8f, 7.5f, 11.7f, PokemonTypes.Grass);
        public PokemonCatolog Ditto() => ProtoType("Ditto", 400, 0.3f, 4.0f, 44.4f, PokemonTypes.Normal);
        public PokemonCatolog Exeggutor() => ProtoType("Exeggutor", 500, 2.0f, 120.0f, 30.0f, PokemonTypes.Grass);
        public PokemonCatolog Sudowoodo() => ProtoType("Sudowoodo", 500, 1.2f, 38.0f, 26.4f, PokemonTypes.Grass);
        public PokemonCatolog Staryu() => ProtoType("Staryu", 450, 0.8f, 34.5f, 53.9f, PokemonTypes.Water);
        public PokemonCatolog Magnemite() => ProtoType("Magnemite", 450, 0.3f, 6.0f, 66.7f, PokemonTypes.Electric);
        public PokemonCatolog Gastly() => ProtoType("Gastly", 450, 1.3f, 0.2f, 0.1f, PokemonTypes.Psychic);
        public PokemonCatolog Gloom() => ProtoType("Gloom", 450, 0.8f, 8.6f, 13.4f, PokemonTypes.Grass);
        public PokemonCatolog Hoothoot() => ProtoType("Hoothoot", 450, 0.7f, 21.2f, 43.3f, PokemonTypes.Normal);
        public PokemonCatolog Marill() => ProtoType("Marill", 450, 0.4f, 8.5f, 53.1f, PokemonTypes.Water);
        public PokemonCatolog Teddiursa() => ProtoType("Teddiursa", 550, 0.6f, 8.8f, 24.4f, PokemonTypes.Normal);
        public PokemonCatolog Voltorb() => ProtoType("Voltorb", 350, 0.5f, 10.4f, 41.6f, PokemonTypes.Electric);
        public PokemonCatolog Oddish() => ProtoType("Oddish", 350, 0.5f, 5.4f, 21.6f, PokemonTypes.Grass);
        public PokemonCatolog Duskull() => ProtoType("Duskull", 320, 0.8f, 15.0f, 23.4f, PokemonTypes.Psychic);
        public PokemonCatolog Poliwhirl() => ProtoType("Poliwhirl", 600, 1.0f, 20.0f, 20.0f, PokemonTypes.Water);
        public PokemonCatolog Sunkern() => ProtoType("Sunkern", 460, 0.3f, 1.8f, 20.0f, PokemonTypes.Grass);
        public PokemonCatolog Sentret() => ProtoType("Sentret", 320, 0.8f, 6.0f, 9.4f, PokemonTypes.Normal);
        public PokemonCatolog Ledyba() => ProtoType("Ledyba", 420, 1.0f, 10.8f, 10.8f, PokemonTypes.Grass);
        public PokemonCatolog Wailmer() => ProtoType("Wailmer", 600, 2.0f, 130.0f, 32.5f, PokemonTypes.Water);

        #endregion

    }
}
