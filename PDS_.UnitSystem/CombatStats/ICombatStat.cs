using System;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;

namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    public enum CombatStatType
    {
        _None = 0,
        CriticalStrikeChance,
        DodgeChance,
        PhysicalDamage,
        MagicalDamage,
        MovementSpeed,
        AttackSpeed,
        PhysicalDefense,
        MagicDefense,
        Health_RegenerationRate,
        MaxHealth,
        M_E_F_RegenerationRate,
        M_E_F_Base,
        Stamina_RegenerationRate,
        Stamina_Base,
    }

    public interface ICombatStat
    {
        event EventHandler<CombatStatCalculatedEventArgs> Calculated;
        CombatStatType CombatStatType { get; }
        CharacterLeagueType LeagueType { get; }
        float Value { get; }
        string ToString();
    }
}