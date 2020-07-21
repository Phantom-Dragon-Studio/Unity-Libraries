using System;
using PhantomDragonStudio.Core.Utilities;
using PhantomDragonStudio.UnitSystem.Characteristics;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;

namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    /// <summary>
    /// A Null reference exception can be thrown by the AddAttribute line if the character sheet sends an attribute with a null value
    /// </summary>
    public static class CombatStatHandlerFactory
    {
        private static ICombatStat[] _combatStats = new ICombatStat[Enum.GetNames(typeof(CombatStatType)).Length - 1];

        public static ICombatStatsHandler Create(ICharacteristicController characteristicController, ICharacterLeague leagueType)
        {
            GenerateCombatStats(characteristicController, leagueType);
            if (_combatStats != null)
                return new CombatStatsHandler(_combatStats);
            Logger.Say("Null list received by CharacterStatHandler Factory.");
            return null;
        }

        private static void GenerateCombatStats(ICharacteristicController characteristicController, ICharacterLeague leagueType)
        {
            _combatStats = leagueType.GenerateCombatStats(characteristicController, _combatStats);
        }
    }
}
