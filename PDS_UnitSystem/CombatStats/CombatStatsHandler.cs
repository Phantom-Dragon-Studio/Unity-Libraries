using System.Collections.Generic;
using PhantomDragonStudio.Core.Utilities;

namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    public class CombatStatsHandler : ICombatStatsHandler
    {
        private Dictionary<CombatStatType, ICombatStat> CombatStats { get; } =
            new Dictionary<CombatStatType, ICombatStat>();

        public CombatStatsHandler(ICombatStat[] combatStats)
        {
            for (int i = 0; i < combatStats.Length; i++)
            {
                CombatStats[combatStats[i].CombatStatType] = combatStats[i];
            }
        }

        public ICombatStat CriticalStrikeChance => CombatStats[CombatStatType.CriticalStrikeChance];
        public ICombatStat DodgeChance => CombatStats[CombatStatType.DodgeChance];
        public ICombatStat AttackSpeed => CombatStats[CombatStatType.AttackSpeed];
        public ICombatStat MovementSpeed => CombatStats[CombatStatType.MovementSpeed];
        public ICombatStat PhysicalDamage => CombatStats[CombatStatType.PhysicalDamage];
        public ICombatStat MagicalDamage => CombatStats[CombatStatType.MagicalDamage];
        public ICombatStat PhysicalDefense => CombatStats[CombatStatType.PhysicalDefense];
        public ICombatStat MagicDefense => CombatStats[CombatStatType.MagicDefense];
        public ICombatStat MaxHealth => CombatStats[CombatStatType.MaxHealth];
        public ICombatStat HealthRegen => CombatStats[CombatStatType.Health_RegenerationRate];
        public ICombatStat M_E_F_Base => CombatStats[CombatStatType.M_E_F_Base];
        public ICombatStat M_E_F_Regen => CombatStats[CombatStatType.M_E_F_RegenerationRate];
        public ICombatStat StaminaBase => CombatStats[CombatStatType.Stamina_Base];
        public ICombatStat StaminaRegen => CombatStats[CombatStatType.Stamina_RegenerationRate];

        public ICombatStat GetCombatStatByType(CombatStatType typeToCheck)
        {
            if (CombatStats.ContainsKey(typeToCheck))
                return CombatStats[typeToCheck];
            Logger.Say("CombatStatsHandler tried to access a NULL ICombatStat");
            return null;
        }
    }
}