using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.EE.DeMiddelaerBart.Domain.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 15, nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    DayOfBirth = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(maxLength: 20, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Bio = table.Column<string>(maxLength: 999, nullable: true),
                    IndexOfTeamSelectit = table.Column<int>(nullable: true),
                    IndexOfAvatarSelectit = table.Column<int>(nullable: true),
                    HighScore = table.Column<int>(nullable: true),
                    TypeOfUser = table.Column<int>(nullable: false),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    PokemonPictureUrl = table.Column<string>(maxLength: 250, nullable: false),
                    HealthPoints = table.Column<int>(maxLength: 5, nullable: false),
                    Mana = table.Column<int>(maxLength: 5, nullable: false),
                    Height = table.Column<float>(maxLength: 5, nullable: false),
                    Weight = table.Column<float>(maxLength: 5, nullable: false),
                    BMI = table.Column<float>(maxLength: 5, nullable: false),
                    Level = table.Column<int>(maxLength: 5, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemons_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(nullable: true),
                    PokemonId = table.Column<int>(nullable: true),
                    SkillOne = table.Column<int>(nullable: true),
                    SkillTwo = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cards_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    ManaCost = table.Column<int>(maxLength: 5, nullable: false),
                    Dps = table.Column<int>(maxLength: 5, nullable: false),
                    Acc = table.Column<int>(maxLength: 5, nullable: false),
                    Pp = table.Column<int>(maxLength: 5, nullable: false),
                    Turns = table.Column<int>(maxLength: 2, nullable: false),
                    Effect = table.Column<string>(maxLength: 255, nullable: false),
                    SkillType = table.Column<int>(nullable: false),
                    PokemonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skills_Pokemons_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Pokemons",
                columns: new[] { "Id", "BMI", "HealthPoints", "Height", "Level", "Mana", "Name", "PokemonPictureUrl", "Type", "UserId", "Weight" },
                values: new object[,]
                {
                    { 1, 8.2f, 400, 0.7f, 28, 160, "Bellsprout", "/images/Pokemon/Bellsprout.svg", 4, null, 4f },
                    { 22, 26.4f, 500, 1.2f, 19, 160, "Sudowoodo", "/images/Pokemon/Sudowoodo.svg", 4, null, 38f },
                    { 23, 53.9f, 450, 0.8f, 29, 160, "Staryu", "/images/Pokemon/Staryu.svg", 2, null, 34.5f },
                    { 24, 66.7f, 450, 0.3f, 14, 160, "Magnemite", "/images/Pokemon/Magnemite.svg", 3, null, 6f },
                    { 25, 0.1f, 450, 1.3f, 22, 160, "Gastly", "/images/Pokemon/Gastly.svg", 5, null, 0.2f },
                    { 26, 13.4f, 450, 0.8f, 17, 160, "Gloom", "/images/Pokemon/Gloom.svg", 4, null, 8.6f },
                    { 27, 43.3f, 450, 0.7f, 24, 160, "Hoothoot", "/images/Pokemon/Hoothoot.svg", 0, null, 21.2f },
                    { 29, 24.4f, 550, 0.6f, 21, 160, "Teddiursa", "/images/Pokemon/Teddiursa.svg", 0, null, 8.8f },
                    { 30, 41.6f, 350, 0.5f, 22, 160, "Voltorb", "/images/Pokemon/Voltorb.svg", 3, null, 10.4f },
                    { 31, 21.6f, 350, 0.5f, 16, 160, "Oddish", "/images/Pokemon/Oddish.svg", 4, null, 5.4f },
                    { 32, 23.4f, 320, 0.8f, 24, 160, "Duskull", "/images/Pokemon/Duskull.svg", 5, null, 15f },
                    { 33, 20f, 600, 1f, 25, 160, "Poliwhirl", "/images/Pokemon/Poliwhirl.svg", 2, null, 20f },
                    { 34, 20f, 460, 0.3f, 29, 160, "Sunkern", "/images/Pokemon/Sunkern.svg", 4, null, 1.8f },
                    { 35, 9.4f, 320, 0.8f, 10, 160, "Sentret", "/images/Pokemon/Sentret.svg", 0, null, 6f },
                    { 36, 10.8f, 420, 1f, 17, 160, "Ledyba", "/images/Pokemon/Ledyba.svg", 4, null, 10.8f },
                    { 37, 32.5f, 600, 2f, 24, 160, "Wailmer", "/images/Pokemon/Wailmer.svg", 2, null, 130f },
                    { 21, 30f, 500, 2f, 14, 160, "Exeggutor", "/images/Pokemon/Exeggutor.svg", 4, null, 120f },
                    { 20, 44.4f, 400, 0.3f, 28, 160, "Ditto", "/images/Pokemon/Ditto.svg", 0, null, 4f },
                    { 28, 53.1f, 450, 0.4f, 13, 160, "Marill", "/images/Pokemon/Marill.svg", 2, null, 8.5f },
                    { 18, 25f, 400, 0.4f, 18, 160, "Mew", "/images/Pokemon/Mew.svg", 5, null, 4f },
                    { 19, 11.7f, 400, 0.8f, 24, 160, "Zubat", "/images/Pokemon/Zubat.svg", 4, null, 7.5f },
                    { 3, 14.1f, 400, 0.7f, 29, 160, "Bulbasaur", "/images/Pokemon/Bulbasaur.svg", 4, null, 6.9f },
                    { 4, 32.2f, 400, 0.3f, 14, 160, "Caterpie", "/images/Pokemon/Caterpie.svg", 4, null, 6.4f },
                    { 5, 23.6f, 500, 0.6f, 14, 160, "Charmander", "/images/Pokemon/Charmander.svg", 1, null, 18.7f },
                    { 6, 1f, 400, 1.8f, 16, 160, "Dratini", "/images/Pokemon/Dratini.svg", 2, null, 3.3f },
                    { 7, 72.2f, 500, 0.3f, 24, 160, "Eevee", "/images/Pokemon/Eevee.svg", 0, null, 6.5f },
                    { 8, 22f, 600, 0.5f, 11, 160, "Jigglypuff", "/images/Pokemon/Jigglypuff.svg", 0, null, 5.5f },
                    { 9, 26.3f, 500, 0.4f, 18, 160, "Meowth", "/images/Pokemon/Meowth.svg", 0, null, 4.2f },
                    { 2, 19.4f, 300, 0.6f, 10, 160, "Abra", "/images/Pokemon/Abra.svg", 5, null, 7f },
                    { 11, 37.5f, 400, 0.4f, 18, 160, "Pikachu", "/images/Pokemon/Pikachu.svg", 3, null, 6f },
                    { 12, 30.6f, 500, 0.8f, 14, 160, "Psyduck", "/images/Pokemon/Psyduck.svg", 2, null, 19.6f },
                    { 13, 38.9f, 300, 0.3f, 23, 160, "Rattata", "/images/Pokemon/Rattata.svg", 0, null, 3.5f },
                    { 14, 104.3f, 900, 2.1f, 11, 160, "Snorlax", "/images/Pokemon/Snorlax.svg", 0, null, 1014.1f },
                    { 15, 36f, 400, 0.5f, 23, 160, "Squirtle", "/images/Pokemon/Squirtle.svg", 2, null, 19.8f },
                    { 16, 30f, 400, 1f, 28, 160, "Venonat", "/images/Pokemon/Venonat.svg", 4, null, 30f },
                    { 17, 35.6f, 400, 0.3f, 10, 160, "Weedle", "/images/Pokemon/Weedle.svg", 4, null, 3.2f },
                    { 10, 20f, 400, 0.3f, 10, 160, "Pidgey", "/images/Pokemon/Pidgey.svg", 0, null, 1.5f }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Acc", "Dps", "Effect", "ManaCost", "Name", "PokemonId", "Pp", "SkillType", "Turns" },
                values: new object[,]
                {
                    { 58, 85, 35, "Hits up to 5 times in one turn.", 70, "Bullet Seed", null, 10, 4, 5 },
                    { 57, 100, 75, "May lower opponent's Accuracy.", 150, "Leaf Tornado", null, 2, 4, 1 },
                    { 56, 100, 65, "High critical hit ratio.", 130, "Razor Leaf", null, 2, 4, 1 },
                    { 55, 100, 40, "Strikes opponent with leaves.", 80, "Leafage", null, 30, 4, 1 },
                    { 54, 100, 15, "User recovers half the HP inflicted on opponent.", 30, "Absorb", null, 20, 4, 1 },
                    { 53, 100, 75, "Overdrive has no added effects.(Nop)", 150, "Overdrive", null, 2, 3, 1 },
                    { 52, 100, 75, "May paralyze opponent.", 150, "Discharge", null, 2, 3, 1 },
                    { 51, 100, 75, "May paralyze opponent.", 150, "Thunder Punch", null, 2, 3, 1 },
                    { 46, 100, 40, "Lowers opponent's Speed.", 80, "Electroweb", null, 30, 3, 1 },
                    { 49, 85, 35, "May raise user's Special Attack.", 70, "Charge Beam", null, 15, 3, 1 },
                    { 48, 100, 75, "User must switch out after attacking.(Nop)", 150, "Volt Switch", null, 2, 3, 1 },
                    { 47, 100, 65, "May paralyze opponent.", 130, "Spark", null, 2, 3, 1 },
                    { 45, 85, 35, "May paralyze opponent.", 70, "Thunder Shock", null, 10, 3, 1 },
                    { 44, 100, 65, "May cause flinching and/or paralyze opponent.", 130, "Thunder Fang", null, 2, 3, 1 },
                    { 43, 100, 60, "User recovers half the HP inflicted on opponent.", 120, "Parabolic Charge", null, 2, 3, 1 },
                    { 42, 85, 40, "High critical-hit ratio.(Nop)", 80, "Zippy Zap", null, 20, 3, 1 },
                    { 50, 100, 40, "Ignores Accuracy and Evasiveness.", 80, "Shock Wave", null, 10, 3, 1 },
                    { 59, 100, 40, "User recovers half the HP inflicted on opponent.", 80, "Mega Drain", null, 10, 4, 1 },
                    { 77, 85, 40, "May confuse opponent.", 80, "Psybeam", null, 20, 5, 1 },
                    { 61, 100, 75, "Lowers opponent's Attack.", 150, "Trop Kick", null, 2, 4, 1 },
                    { 41, 100, 15, "Paralyzes opponent.", 30, "Nuzzle", null, 20, 3, 1 },
                    { 76, 100, 65, "Inflicts damage based on the target's Defense, not Special Defense.(Nop)", 130, "Psyshock", null, 2, 5, 1 },
                    { 75, 100, 60, "May lower opponent's Special Defense.(Nop)", 120, "Luster Purge", null, 2, 5, 1 },
                    { 74, 85, 35, "May cause flinching.(Nop)", 70, "Heart Stamp", null, 15, 5, 1 },
                    { 73, 100, 75, "May cause flinching.(Nop)", 150, "Extrasensory", null, 2, 5, 1 },
                    { 72, 100, 75, "Can strike through Protect/Detect.(Nop)", 150, "HyperspaceHole", null, 2, 5, 1 },
                    { 71, 100, 40, "May lower opponent's Special Attack.(Nop)", 80, "Mist Ball", null, 10, 5, 1 },
                    { 60, 100, 65, "Ignores Accuracy and Evasiveness", 130, "Magical Leaf", null, 2, 4, 1 },
                    { 70, 85, 35, "May confuse opponent.", 70, "Confusion", null, 10, 5, 1 },
                    { 68, 100, 40, "High critical hit ratio.", 80, "Psycho Cut", null, 30, 5, 1 },
                    { 67, 100, 15, "Power increases when user's stats have been raised.(Nop)", 30, "Stored Power", null, 20, 5, 1 },
                    { 66, 85, 40, "Poke's.", 80, "Branch Poke", null, 20, 4, 1 },
                    { 65, 100, 75, "User recovers half the HP inflicted on opponent.", 150, "Giga Drain", null, 2, 4, 1 },
                    { 64, 100, 75, "May cause flinching.(Wut ?)", 150, "Needle Arm", null, 2, 4, 1 },
                    { 63, 100, 60, " Wips vine's.", 120, "Vine Whip", null, 2, 4, 1 },
                    { 62, 85, 35, "Snares the target in a snap trap for four to 5 turns.", 70, "Snap Trap", null, 15, 4, 5 },
                    { 69, 100, 65, "May cause flinching.(Nop)", 130, "ZenHeadbutt", null, 2, 5, 1 },
                    { 40, 100, 40, "User attacks first.", 80, "Aqua Jet", null, 10, 2, 1 },
                    { 28, 100, 80, "May raise user's Special Attack.(Nop)", 160, "FieryDance", null, 2, 1, 1 },
                    { 38, 100, 75, "Power doubles if opponent's HP is less than 50%", 150, "Brine", null, 2, 2, 1 },
                    { 16, 90, 40, "User attacks first, foe flinches. Only usable on first turn.(NotWorking)", 80, "Fake Out", null, 10, 0, 1 },
                    { 15, 100, 40, "Power increases each turn. (WorksHalf)", 80, "Echoed Voice", null, 10, 0, 1 },
                    { 14, 85, 35, "Hits twice in one turn.", 70, "Double Hit", null, 10, 0, 1 },
                    { 13, 100, 30, "Only hits if opponent uses Protect or Detect in the same turn.(NotWorking)", 60, "Feint", null, 10, 0, 1 },
                    { 39, 85, 35, "Traps opponent, damaging them for up to 5 turns.", 70, "Whirlpool", null, 15, 2, 5 },
                    { 11, 100, 20, "Hits up to 5 times in one turn.", 40, "Spike Cannon", null, 10, 0, 5 },
                    { 10, 80, 20, "Removes effects of trap moves.(NotWorking)", 40, "Rapid Spin", null, 10, 0, 1 },
                    { 17, 100, 40, "Always leaves opponent with at least 1 HP.(NotWorking)", 80, "False Swipe", null, 10, 0, 1 },
                    { 9, 85, 20, "Raises user's Attack when hit.", 40, "Rage", null, 10, 0, 1 },
                    { 7, 85, 18, "Hits up to 5 times in one turn.", 35, "Comet Punch", null, 10, 0, 5 },
                    { 6, 90, 15, "Traps opponent, damaging them up to 5 turns.", 30, "Wrap", null, 10, 0, 5 },
                    { 5, 85, 15, "Hits up to 5 times in one turn.", 30, "Fury Attack", null, 10, 0, 5 },
                    { 4, 85, 15, "Hits up to 5 times in one turn.", 30, "DoubleSlap", null, 10, 0, 5 },
                    { 3, 85, 15, "Traps opponent, damaging them for up to 5 turns.", 30, "Bind", null, 10, 0, 5 },
                    { 2, 85, 15, "Hits up to 5 times in one turn.", 30, "Barrage", null, 10, 0, 5 },
                    { 1, 100, 10, "May lower opponent's Speed by one stage.", 20, "Constrict", null, 10, 0, 1 },
                    { 8, 90, 18, "Hits up to 5 times in one turn.", 35, "Fury Swipes", null, 10, 0, 5 },
                    { 18, 100, 40, "Always leaves opponent with at least 1 HP.(NotWorking)", 80, "Hold Back", null, 10, 0, 1 },
                    { 12, 100, 25, "Hits up to 5 times in one turn.", 50, "Tail Slap", null, 10, 0, 5 },
                    { 20, 100, 40, "Giving a Pounding MMMMMMMMMMmmmmmm", 80, "Pound", null, 10, 0, 1 },
                    { 37, 100, 65, "May lower opponent's Accuracy.", 130, "Octazooka", null, 2, 2, 1 },
                    { 19, 100, 40, "A small amount of money is gained after the battle resolves.", 80, "Pay Day", null, 10, 0, 1 },
                    { 35, 85, 35, "Traps opponent, damaging them for up to 5 turns.", 70, "Clamp", null, 10, 2, 5 },
                    { 34, 100, 65, "May lower opponent's Speed.", 130, "Bubble Beam", null, 2, 2, 1 },
                    { 33, 100, 60, "May confuse opponent.", 120, "Water Pulse", null, 2, 2, 1 },
                    { 32, 85, 40, "Traps opponent, damaging them for up to 5 turns.", 80, "Bubble", null, 20, 2, 5 },
                    { 31, 100, 15, "Hits up to 5 times in one turn.", 30, "Water Shuriken", null, 20, 2, 5 },
                    { 30, 100, 65, "May cause flinching and/or burn opponent.", 130, "Fire Fang", null, 10, 1, 1 },
                    { 36, 100, 40, "Water Gun deals damage with no additional effect.", 80, "Water Gun", null, 30, 2, 1 },
                    { 27, 100, 75, "Lowers opponent's Special Attack.(Nop)", 150, "Mystical Fire", null, 2, 1, 1 },
                    { 26, 100, 60, "May burn opponent.", 120, "FlameWheel", null, 10, 1, 1 },
                    { 25, 100, 40, "May burn opponent.", 80, "Ember", null, 10, 1, 1 },
                    { 24, 100, 75, "May burn opponent", 150, "FirePunch", null, 2, 1, 1 },
                    { 23, 100, 75, "May also injure nearby Pokémon.(Nop)", 140, "Flame Burst", null, 10, 1, 1 },
                    { 22, 100, 60, "Destroys the target's held berry.(No barry in this game ;) )", 120, "Incinerate", null, 10, 1, 1 },
                    { 21, 85, 15, "Traps opponent, damaging them for up to 10 turns.", 70, "Fire Spin", null, 10, 1, 10 },
                    { 29, 100, 50, "Raises user's Speed.", 100, "Flame Charge", null, 10, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Country", "DayOfBirth", "Email", "GenderId", "HighScore", "IndexOfAvatarSelectit", "IndexOfTeamSelectit", "Name", "Password", "PasswordSalt", "PhoneNumber", "TypeOfUser" },
                values: new object[,]
                {
                    { 14L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 4, 638, 1, 2, "Seed User 14", "/WruwvwYC1z0Zq8K4Sr4Wo4M9xldHhNMrGU9LkzD/Lk=", "PC+Bw9gJB9ZYjkT46Iaw", "0499855214", 1 },
                    { 13L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 2, 891, 10, 1, "Seed User 13", "lZQXjhWVqW7423vzKBcoX7NDnvFoF4XKmR+8yk7bP2Y=", "j51ogS9D759ncLfK/mdw", "0499855213", 1 },
                    { 12L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 4, 519, 11, 3, "Seed User 12", "gcjfw2TqkKtOBH7q8EYG447Jamp0LJKR10hmitMq8ns=", "31VUzO7ltpl+N0KnTfgr", "0499855212", 1 },
                    { 11L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 4, 914, 1, 1, "Seed User 11", "EHVIfrKKwm+pzPKBrkBGdv1cy3pHegdCbBhy5Qe0Huw=", "9WghGPyLvdvukHoyTbPO", "0499855211", 1 },
                    { 10L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 4, 75, 5, 1, "Seed User 10", "mOg1SbSporCao1mWUPxhEAPcKSY+psg3SsnmaR5lR8E=", "Af0DNt/p2Dyou4vecQHz", "0499855210", 1 },
                    { 9L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 3, 428, 2, 1, "Seed User 9", "sia/42loKPTlZpGIzjx+Nz59plYz/KJPfx+hZ3UhT4E=", "iq5qk4/Pw9YOnvb+mCjU", "049985529", 1 },
                    { 8L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 2, 801, 10, 3, "Seed User 8", "tfIKf4u1eFjf5YcNgj5PiT4hbeKAVutQ/dZwhu3NV0Q=", "oaQHEqVkzMDryDZ8RngT", "049985528", 1 },
                    { 4L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 3, 314, 7, 3, "Seed User 4", "4IdVsCzPkxUwy/vBsJWZwbyqGPb0Uc9oIMb6sesWqM0=", "+gZUZA6DNxmvBJR1Aqjb", "049985524", 1 },
                    { 6L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 2, 593, 12, 1, "Seed User 6", "ACdtS3YHZwtB5IfTZSShHC+bwUsZMtB87ytbTs8d/gc=", "pC9SaN3poQ6UCcrITqeG", "049985526", 1 },
                    { 5L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 2, 512, 4, 2, "Seed User 5", "m0ID5xyMWNinh+fbJXqi0XjNjl+9s+mEKO0/qHeAkTc=", "WZFh0b14kbpbE2b4SUoK", "049985525", 1 },
                    { 3L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 3, 488, 4, 1, "Seed User 3", "s//wmR2wTXtxnuw/MP9m58YwAn3hrXAs2nvxCY80sHI=", "AqE9namcod5f8sNadtY8", "049985523", 1 },
                    { 2L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 1, 236, 8, 2, "Seed User 2", "2ns8HDhUybSqSvnLU+rQ/V+zG7SL1pS4BbgQf9NlyG4=", "NyWcBF0ditaJx6H9nkGT", "049985522", 1 },
                    { 1L, @"So perhaps, you've generated some fancy text, and you're content
                                    that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                    but perhaps you're wondering how it's even possible to
                                    change the font of your text? Is it some sort of hack? 
                                    Are you copying and pasting an actual font?

                                    Well, the answer is actually no - rather than generating fancy fonts, this converter creates fancy 
                                    symbols. The explanation starts with unicode; an industry standard which creates the specification for 
                                    thousands of different symbols and characters. All the characters that you see on your electronic devices,
                                    and printed in books, are likely specified by the unicode standard.", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 5, 1024, 1, 1, "a", "Xi+EHrnw3grShXW3TJqMo9t6j0poTd/cHuAVM3IraEQ=", "xn2HEry2reJEryEULLa9", "0499855224", 0 },
                    { 7L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 2, 962, 4, 3, "Seed User 7", "b0YXZ1A/9ezv/h3iGVOqKR1ZETNirVyUYcBzJLdrSCc=", "Q3G6YkF8m+auo6HenHJ8", "049985527", 1 },
                    { 15L, @"So perhaps, you've generated some fancy text, and you're content
                                                that you can now copy and paste your fancy text in the comments section of funny cat videos,
                                                but perhaps you're wondering how it's even possible to
                                                change the font of your text? Is it some sort of hack? 
                                                Are you copying and pasting an actual font?
                                    ", "Belgium", new DateTime(1920, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "OtenToten@Tontoonstelling.com", 3, 634, 3, 3, "Seed User 15", "vqOlnt52eXuHBbeBrMcr0UKWKh/fzMxL6PKKAq3scnI=", "mNPDFM2HShweC5WObyrL", "0499855215", 1 }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "PokemonId", "SkillOne", "SkillTwo", "UserId" },
                values: new object[,]
                {
                    { 1L, 17, 1, 2, 1L },
                    { 22L, 29, 1, 2, 10L },
                    { 23L, 20, 1, 2, 10L },
                    { 24L, 33, 1, 2, 11L },
                    { 25L, 8, 1, 2, 11L },
                    { 26L, 2, 1, 2, 11L },
                    { 27L, 28, 1, 2, 11L },
                    { 28L, 28, 1, 2, 12L },
                    { 29L, 22, 1, 2, 12L },
                    { 30L, 35, 1, 2, 13L },
                    { 31L, 34, 1, 2, 13L },
                    { 32L, 13, 1, 2, 13L },
                    { 33L, 7, 1, 2, 14L },
                    { 34L, 9, 1, 2, 14L },
                    { 35L, 10, 1, 2, 15L },
                    { 36L, 21, 1, 2, 15L },
                    { 21L, 12, 1, 2, 9L },
                    { 20L, 17, 1, 2, 8L },
                    { 19L, 20, 1, 2, 8L },
                    { 18L, 10, 1, 2, 8L },
                    { 2L, 23, 1, 2, 1L },
                    { 3L, 21, 1, 2, 1L },
                    { 4L, 31, 1, 2, 2L },
                    { 5L, 13, 1, 2, 2L },
                    { 6L, 16, 1, 2, 2L },
                    { 7L, 23, 1, 2, 3L },
                    { 8L, 13, 1, 2, 4L },
                    { 37L, 22, 1, 2, 15L },
                    { 9L, 16, 1, 2, 4L },
                    { 11L, 25, 1, 2, 6L },
                    { 12L, 32, 1, 2, 6L },
                    { 13L, 10, 1, 2, 7L },
                    { 14L, 6, 1, 2, 7L },
                    { 15L, 30, 1, 2, 7L },
                    { 16L, 3, 1, 2, 8L },
                    { 17L, 2, 1, 2, 8L },
                    { 10L, 32, 1, 2, 5L },
                    { 38L, 9, 1, 2, 15L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PokemonId",
                table: "Cards",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_UserId",
                table: "Cards",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pokemons_UserId",
                table: "Pokemons",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_PokemonId",
                table: "Skills",
                column: "PokemonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Pokemons");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
