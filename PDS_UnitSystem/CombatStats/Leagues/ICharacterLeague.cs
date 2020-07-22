﻿﻿using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues
{
    public enum CharacterLeagueType
    {
        _None = 0,
        Rogue,
        Warrior,
        Wizard,
    }


    public interface ICharacterLeague
    {
        CharacterLeagueType LeagueType { get; }
        string ToString();
        ICombatStat[] GenerateCombatStats(ICharacteristicController characteristicController, ICombatStat[] emptyArrayToPopulate);
    }
}