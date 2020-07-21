﻿﻿namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    public interface ICombatStatsHandler
    {
        ICombatStat GetCombatStatByType(CombatStatType typeToCheck);

        ICombatStat CriticalStrikeChance { get; }
        ICombatStat DodgeChance { get; }
        ICombatStat PhysicalDamage{ get; }
        ICombatStat MagicalDamage { get; }
        ICombatStat MovementSpeed  { get; }
        ICombatStat AttackSpeed { get; }
        ICombatStat PhysicalDefense { get; }
        ICombatStat MagicDefense { get; }
        ICombatStat MaxHealth { get; }
        ICombatStat HealthRegen { get; }
        ICombatStat M_E_F_Base { get; }
        ICombatStat M_E_F_Regen { get; }
        ICombatStat StaminaBase { get; }
        ICombatStat StaminaRegen { get; }
    }
}
