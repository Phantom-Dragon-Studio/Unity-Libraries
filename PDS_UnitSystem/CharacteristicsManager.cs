using System.Collections.Generic;
using PhantomDragonStudio.UnitSystem.CombatStats;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;

namespace PhantomDragonStudio.UnitSystem
{
    public static class CharacteristicsManager
    {
        private static CombatStat_Modifiers_Sheet rogueSettings;

        public static CombatStat_Modifiers_Sheet RogueStatSettings
        {
            get => rogueSettings;
            set => rogueSettings = value;
        }

        private static CombatStat_Modifiers_Sheet warriorSettings;

        public static CombatStat_Modifiers_Sheet WarriorStatSettings
        {
            get => warriorSettings;
            set => warriorSettings = value;
        }

        private static CombatStat_Modifiers_Sheet wizardSettings;

        public static CombatStat_Modifiers_Sheet WizardStatSettings
        {
            get => wizardSettings;
            set => wizardSettings = value;
        }

        public static Dictionary<CharacterLeagueType, CombatStat_Modifiers_Sheet> LeagueSettings =
            new Dictionary<CharacterLeagueType, CombatStat_Modifiers_Sheet>();

        private static void Initialize()
        {
            LeagueSettings.Add(CharacterLeagueType.Rogue, RogueStatSettings);
            LeagueSettings.Add(CharacterLeagueType.Warrior, WarriorStatSettings);
            LeagueSettings.Add(CharacterLeagueType.Wizard, WizardStatSettings);
        }

        internal static float CombatStatModifiers(CharacterLeagueType league, CombatStatType stat)
        {
            return LeagueSettings[league].Settings[stat];
        }
    }
}