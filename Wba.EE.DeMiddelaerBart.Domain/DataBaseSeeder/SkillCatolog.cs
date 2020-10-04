using static Wba.EE.DeMiddelaerBart.Domain.SiteProperties;


namespace Wba.EE.DeMiddelaerBart.Domain
{
    public class SkillCatolog
    {
        // Zelvde principevan pokemon class
        public string Name { get; private set; }
        public PokemonTypes SkillType { get; private set; }
        public int ManaCost { get; private set; }
        public int Dps { get; private set; }
        public int Acc { get; private set; }
        public int Pp { get; private set; }
        public int Turns { get; private set; }
        public string Effect { get; private set; }

        // ------------------------------------------------------------------------------------

        SkillCatolog ProtoType(string name, PokemonTypes type, int manaCost,
        int dps, int acc, int pp, int turns, string effect) => new SkillCatolog
        {
            Name = name,
            SkillType = type,
            ManaCost = manaCost,
            Dps = dps,
            Acc = acc,
            Pp = pp,
            Turns = turns,
            Effect = effect,
        };
        SkillCatolog ProtoType(string name, PokemonTypes type, int manaCost,
        int dps, int acc, int pp, int turns, string effect, SkillsEffect skillsEffect) => new SkillCatolog
        {
            Name = name,
            SkillType = type,
            ManaCost = manaCost,
            Dps = dps,
            Acc = acc,
            Pp = pp,
            Turns = turns,
            Effect = effect,
        };
        SkillCatolog ProtoType(string name, PokemonTypes type, int manaCost,
        int dps, int acc, int pp, int turns, string effect, SkillsEffect[] skillsEffect) => new SkillCatolog
        {
            Name = name,
            SkillType = type,
            ManaCost = manaCost,
            Dps = dps,
            Acc = acc,
            Pp = pp,
            Turns = turns,
            Effect = effect,
        };

        #region Normal
        // ------------------------------------------------------------------- Mana-Dps-Acc-pp-turns
        public SkillCatolog Constrict() => ProtoType("Constrict", PokemonTypes.Normal,       20, 10, 100, 10, 1,
            "May lower opponent's Speed by one stage.",SkillsEffect.Slow);
        public SkillCatolog Barrage() => ProtoType("Barrage", PokemonTypes.Normal,           30, 15, 85, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog Bind() => ProtoType("Bind", PokemonTypes.Normal,                 30, 15, 85, 10, 5, 
            "Traps opponent, damaging them for up to 5 turns.",new[] { SkillsEffect.MultiTurns, SkillsEffect.Stun });
        public SkillCatolog DoubleSlap() => ProtoType("DoubleSlap", PokemonTypes.Normal,     30, 15, 85, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog FuryAttack() => ProtoType("Fury Attack", PokemonTypes.Normal,    30, 15, 85, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog Wrap() => ProtoType("Wrap", PokemonTypes.Normal,                 30, 15, 90, 10, 5, 
            "Traps opponent, damaging them up to 5 turns.", new[] {SkillsEffect.MultiTurns,SkillsEffect.Stun});
        public SkillCatolog CometPunch() => ProtoType("Comet Punch", PokemonTypes.Normal,    35, 18, 85, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog FurySwipes() => ProtoType("Fury Swipes", PokemonTypes.Normal,    35, 18, 90, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog Rage() => ProtoType("Rage", PokemonTypes.Normal,                 40, 20, 85, 10, 1, 
            "Raises user's Attack when hit.", SkillsEffect.AttackUp);
        public SkillCatolog RapidSpin() => ProtoType("Rapid Spin", PokemonTypes.Normal,      40, 20, 80, 10, 1, 
            "Removes effects of trap moves.(NotWorking)");
        public SkillCatolog SpikeCannon() => ProtoType("Spike Cannon", PokemonTypes.Normal,  40, 20, 100, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog TailSlap() => ProtoType("Tail Slap", PokemonTypes.Normal,        50, 25, 100, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog Feint() => ProtoType("Feint", PokemonTypes.Normal,               60, 30, 100, 10, 1, 
            "Only hits if opponent uses Protect or Detect in the same turn.(NotWorking)");
        public SkillCatolog DoubleHit() => ProtoType("Double Hit", PokemonTypes.Normal,      70, 35, 85, 10, 1, 
            "Hits twice in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog EchoedVoice() => ProtoType("Echoed Voice", PokemonTypes.Normal,  80, 40, 100, 10, 1,
            "Power increases each turn. (WorksHalf)", SkillsEffect.AttackUp);
        public SkillCatolog FakeOut() => ProtoType("Fake Out", PokemonTypes.Normal,          80, 40, 90, 10, 1, 
            "User attacks first, foe flinches. Only usable on first turn.(NotWorking)");
        public SkillCatolog FalseSwipe() => ProtoType("False Swipe", PokemonTypes.Normal,    80, 40, 100, 10, 1, 
            "Always leaves opponent with at least 1 HP.(NotWorking)");
        public SkillCatolog HoldBack() => ProtoType("Hold Back", PokemonTypes.Normal,        80, 40, 100, 10, 1, 
            "Always leaves opponent with at least 1 HP.(NotWorking)");
        public SkillCatolog PayDay() => ProtoType("Pay Day", PokemonTypes.Normal,            80, 40, 100, 10, 1, 
            "A small amount of money is gained after the battle resolves.");
        public SkillCatolog Pound() => ProtoType("Pound", PokemonTypes.Normal,               80, 40, 100, 10, 1, 
            "Giving a Pounding MMMMMMMMMMmmmmmm");
        // -----------------------------------------------------------------------------------------
        #endregion

        #region Fire
        // ------------------------------------------------------------------- Mana-Dps-Acc-pp-turns
        public SkillCatolog FireSpin() => ProtoType("Fire Spin", PokemonTypes.Fire,           70, 15, 85, 10, 10,
            "Traps opponent, damaging them for up to 10 turns.", SkillsEffect.MultiTurns);
        public SkillCatolog Ember() => ProtoType("Ember", PokemonTypes.Fire,              80, 40, 100, 10, 1,
            "May burn opponent.", SkillsEffect.Burns);
        public SkillCatolog FlameCharge() => ProtoType("Flame Charge", PokemonTypes.Fire,        100, 50, 100, 10, 1,
            "Raises user's Speed.", SkillsEffect.SpeedUp);
        public SkillCatolog Incinerate() => ProtoType("Incinerate", PokemonTypes.Fire,         120, 60, 100, 10, 1,
            "Destroys the target's held berry.(No barry in this game ;) )");
        public SkillCatolog FlameWheel() => ProtoType("FlameWheel", PokemonTypes.Fire,         120, 60, 100, 10, 1,
            "May burn opponent.", SkillsEffect.Burns);
        public SkillCatolog FireFang() => ProtoType("Fire Fang", PokemonTypes.Fire,           130, 65, 100, 10, 1,
            "May cause flinching and/or burn opponent.", new[] {SkillsEffect.Stun, SkillsEffect.Burns });
        public SkillCatolog FlameBurst() => ProtoType("Flame Burst", PokemonTypes.Fire,         140, 75, 100, 10, 1,
            "May also injure nearby Pokémon.(Nop)");
        public SkillCatolog MysticalFire() => ProtoType("Mystical Fire", PokemonTypes.Fire,       150, 75, 100, 2, 1,
            "Lowers opponent's Special Attack.(Nop)");
        public SkillCatolog FirePunch() => ProtoType("FirePunch", PokemonTypes.Fire,          150, 75, 100, 2, 1,
            "May burn opponent", SkillsEffect.Burns);
        public SkillCatolog FieryDance() => ProtoType("FieryDance", PokemonTypes.Fire,         160, 80, 100, 2, 1,
            "May raise user's Special Attack.(Nop)");

        // -----------------------------------------------------------------------------------------
        #endregion

        #region Water
        // -------------------------------------------------------------------          Mana-Dps-Acc-pp-turns
        public SkillCatolog WaterShuriken() => ProtoType("Water Shuriken", PokemonTypes.Water,        30, 15, 100, 20, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog Clamp() => ProtoType("Clamp", PokemonTypes.Water,                         70, 35, 85, 10, 5,
            "Traps opponent, damaging them for up to 5 turns.", new[] {SkillsEffect.Stun, SkillsEffect.MultiTurns });
        public SkillCatolog Whirlpool() => ProtoType("Whirlpool", PokemonTypes.Water,                 70, 35, 85, 15, 5,
            "Traps opponent, damaging them for up to 5 turns.", new[] {SkillsEffect.Stun, SkillsEffect.MultiTurns});
        public SkillCatolog Bubble() => ProtoType("Bubble", PokemonTypes.Water,                       80, 40, 85, 20, 5,
            "Traps opponent, damaging them for up to 5 turns.", new[] { SkillsEffect.Stun, SkillsEffect.MultiTurns });
        public SkillCatolog WaterGun() => ProtoType("Water Gun", PokemonTypes.Water,                  80, 40, 100, 30, 1,
            "Water Gun deals damage with no additional effect.");
        public SkillCatolog AquaJet() => ProtoType("Aqua Jet", PokemonTypes.Water,                    80, 40, 100, 10, 1,
            "User attacks first.");
        public SkillCatolog WaterPulse() => ProtoType("Water Pulse", PokemonTypes.Water,              120, 60, 100, 2, 1,
            "May confuse opponent.");
        public SkillCatolog Octazooka() => ProtoType("Octazooka", PokemonTypes.Water,                 130, 65, 100, 2, 1,
            "May lower opponent's Accuracy.", SkillsEffect.LowerBossDPS);
        public SkillCatolog BubbleBeam() => ProtoType("Bubble Beam", PokemonTypes.Water,              130, 65, 100, 2, 1,
            "May lower opponent's Speed.", SkillsEffect.LowerBossSpeed);
        public SkillCatolog Brine() => ProtoType("Brine", PokemonTypes.Water,                         150, 75, 100, 2, 1,
            "Power doubles if opponent's HP is less than 50%", SkillsEffect.MoreDpsIfBossBelowHaffHp);
        // -----------------------------------------------------------------------------------------
        #endregion

        #region Electric
        // -------------------------------------------------------------------          Mana-Dps-Acc-pp-turns
        public SkillCatolog Nuzzle() => ProtoType("Nuzzle", PokemonTypes.Electric,                    30, 15, 100, 20, 1,
            "Paralyzes opponent.", SkillsEffect.Stun);
        public SkillCatolog ThunderShock() => ProtoType("Thunder Shock", PokemonTypes.Electric,       70, 35, 85, 10, 1,
            "May paralyze opponent.", SkillsEffect.Stun);
        public SkillCatolog ChargeBeam() => ProtoType("Charge Beam", PokemonTypes.Electric,           70, 35, 85, 15, 1,
            "May raise user's Special Attack.", SkillsEffect.AttackUp);
        public SkillCatolog ZippyZap() => ProtoType("Zippy Zap", PokemonTypes.Electric,               80, 40, 85, 20, 1,
            "High critical-hit ratio.(Nop)");
        public SkillCatolog Electroweb() => ProtoType("Electroweb", PokemonTypes.Electric,            80, 40, 100, 30, 1,
            "Lowers opponent's Speed.", SkillsEffect.LowerBossSpeed);
        public SkillCatolog ShockWave() => ProtoType("Shock Wave", PokemonTypes.Electric,             80, 40, 100, 10, 1,
            "Ignores Accuracy and Evasiveness.");
        public SkillCatolog ParabolicCharge() => ProtoType("Parabolic Charge", PokemonTypes.Electric, 120, 60, 100, 2, 1,
            "User recovers half the HP inflicted on opponent.", SkillsEffect.HpDrain);
        public SkillCatolog Spark() => ProtoType("Spark", PokemonTypes.Electric,                      130, 65, 100, 2, 1,
            "May paralyze opponent.", SkillsEffect.Stun);
        public SkillCatolog ThunderFang() => ProtoType("Thunder Fang", PokemonTypes.Electric,         130, 65, 100, 2, 1,
            "May cause flinching and/or paralyze opponent.", SkillsEffect.Stun);
        public SkillCatolog VoltSwitch() => ProtoType("Volt Switch", PokemonTypes.Electric,           150, 75, 100, 2, 1,
            "User must switch out after attacking.(Nop)");
        public SkillCatolog ThunderPunch() => ProtoType("Thunder Punch", PokemonTypes.Electric,       150, 75, 100, 2, 1,
          "May paralyze opponent.", SkillsEffect.Stun);
        public SkillCatolog Discharge() => ProtoType("Discharge", PokemonTypes.Electric,              150, 75, 100, 2, 1,
          "May paralyze opponent.", SkillsEffect.Stun);
        public SkillCatolog Overdrive() => ProtoType("Overdrive", PokemonTypes.Electric,              150, 75, 100, 2, 1,
          "Overdrive has no added effects.(Nop)");
        // -----------------------------------------------------------------------------------------
        #endregion

        #region Grass
        // -------------------------------------------------------------------          Mana-Dps-Acc-pp-turns
        public SkillCatolog Absorb() => ProtoType("Absorb", PokemonTypes.Grass,                    30, 15, 100, 20, 1,
            "User recovers half the HP inflicted on opponent.", SkillsEffect.HpDrain);
        public SkillCatolog BulletSeed() => ProtoType("Bullet Seed", PokemonTypes.Grass,          70, 35, 85, 10, 5,
            "Hits up to 5 times in one turn.", SkillsEffect.MultiTurns);
        public SkillCatolog SnapTrap() => ProtoType("Snap Trap", PokemonTypes.Grass,              70, 35, 85, 15, 5,
            "Snares the target in a snap trap for four to 5 turns.", new[] {SkillsEffect.Stun, SkillsEffect.MultiTurns });
        public SkillCatolog BranchPoke() => ProtoType("Branch Poke", PokemonTypes.Grass,          80, 40, 85, 20, 1,
            "Poke's.");
        public SkillCatolog Leafage() => ProtoType("Leafage", PokemonTypes.Grass,                 80, 40, 100, 30, 1,
            "Strikes opponent with leaves.");
        public SkillCatolog MegaDrain() => ProtoType("Mega Drain", PokemonTypes.Grass,            80, 40, 100, 10, 1,
            "User recovers half the HP inflicted on opponent.", SkillsEffect.HpDrain);
        public SkillCatolog VineWhip() => ProtoType("Vine Whip", PokemonTypes.Grass,              120, 60, 100, 2, 1,
            " Wips vine's.");
        public SkillCatolog RazorLeaf() => ProtoType("Razor Leaf", PokemonTypes.Grass,            130, 65, 100, 2, 1,
            "High critical hit ratio.", SkillsEffect.AttackUp);
        public SkillCatolog MagicalLeaf() => ProtoType("Magical Leaf", PokemonTypes.Grass,        130, 65, 100, 2, 1,
            "Ignores Accuracy and Evasiveness", SkillsEffect.AttackUp);
        public SkillCatolog NeedleArm() => ProtoType("Needle Arm", PokemonTypes.Grass,            150, 75, 100, 2, 1,
          "May cause flinching.(Wut ?)");
        public SkillCatolog LeafTornado() => ProtoType("Leaf Tornado", PokemonTypes.Grass,        150, 75, 100, 2, 1,
          "May lower opponent's Accuracy.", SkillsEffect.LowerBossDPS);
        public SkillCatolog TropKick() => ProtoType("Trop Kick", PokemonTypes.Grass,              150, 75, 100, 2, 1,
          "Lowers opponent's Attack.",SkillsEffect.LowerBossDPS);
        public SkillCatolog GigaDrain() => ProtoType("Giga Drain", PokemonTypes.Grass,            150, 75, 100, 2, 1,
          "User recovers half the HP inflicted on opponent.", SkillsEffect.HpDrain);
        // -----------------------------------------------------------------------------------------
        #endregion

        #region Psychic
        // -------------------------------------------------------------------          Mana-Dps-Acc-pp-turns
        public SkillCatolog StoredPower() => ProtoType("Stored Power", PokemonTypes.Psychic,          30, 15, 100, 20, 1,
            "Power increases when user's stats have been raised.(Nop)");
        public SkillCatolog Confusion() => ProtoType("Confusion", PokemonTypes.Psychic,               70, 35, 85, 10, 1,
            "May confuse opponent.",SkillsEffect.ConfuseBoss);
        public SkillCatolog HeartStamp() => ProtoType("Heart Stamp", PokemonTypes.Psychic,            70, 35, 85, 15, 1,
            "May cause flinching.(Nop)");
        public SkillCatolog Psybeam() => ProtoType("Psybeam", PokemonTypes.Psychic,                  80, 40, 85, 20, 1,
            "May confuse opponent.", SkillsEffect.ConfuseBoss);
        public SkillCatolog PsychoCut() => ProtoType("Psycho Cut", PokemonTypes.Psychic,             80, 40, 100, 30, 1,
            "High critical hit ratio.", SkillsEffect.AttackUp);
        public SkillCatolog MistBall() => ProtoType("Mist Ball", PokemonTypes.Psychic,               80, 40, 100, 10, 1,
            "May lower opponent's Special Attack.(Nop)");
        public SkillCatolog LusterPurge() => ProtoType("Luster Purge", PokemonTypes.Psychic,        120, 60, 100, 2, 1,
            "May lower opponent's Special Defense.(Nop)");
        public SkillCatolog ZenHeadbutt() => ProtoType("ZenHeadbutt", PokemonTypes.Psychic,         130, 65, 100, 2, 1,
            "May cause flinching.(Nop)");
        public SkillCatolog Psyshock() => ProtoType("Psyshock", PokemonTypes.Psychic,               130, 65, 100, 2, 1,
            "Inflicts damage based on the target's Defense, not Special Defense.(Nop)");
        public SkillCatolog HyperspaceHole() => ProtoType("HyperspaceHole", PokemonTypes.Psychic,   150, 75, 100, 2, 1,
          "Can strike through Protect/Detect.(Nop)");
        public SkillCatolog Extrasensory() => ProtoType("Extrasensory", PokemonTypes.Psychic,       150, 75, 100, 2, 1,
          "May cause flinching.(Nop)");
        // -----------------------------------------------------------------------------------------
        #endregion
    }
}
