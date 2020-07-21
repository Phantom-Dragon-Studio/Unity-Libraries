using PhantomDragonStudio.Core.Utilities;

namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    public static class CharacteristicsCalculator
    {
        public static float GetPrimaryAttributeModifier(BaseStat statToCalculate)
        {
            return CharacteristicsManager.Instance.LeagueSettings[statToCalculate.LeagueType].primaryAttributeGlobalModifier;
        }

        public static float GetSecondaryAttributeModifier(BaseStat statToCalculate)
        {
            return CharacteristicsManager.Instance.LeagueSettings[statToCalculate.LeagueType].secondaryAttributeGlobalModifier;
        }

        public static float CalculateCombatStat(BaseStat statToCalculate)
        {
            Logger.Say(CharacteristicsManager.Instance.LeagueSettings[statToCalculate.LeagueType].Settings[statToCalculate.CombatStatType]);
            var newValue = statToCalculate.Value;
            return newValue *= CharacteristicsManager.Instance.LeagueSettings[statToCalculate.LeagueType].Settings[statToCalculate.CombatStatType];
        }
    }
}