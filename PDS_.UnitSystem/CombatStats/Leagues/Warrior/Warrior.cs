﻿﻿using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Warrior
{
    public class Warrior : CharacterLeague
    {
        public override CharacterLeagueType LeagueType => CharacterLeagueType.Warrior;

        public override ICombatStat[] GenerateCombatStats(ICharacteristicController characteristicController, ICombatStat[] emptyArrayToPopulate)
        {
            return WarriorCombatStatFactory.Create(characteristicController, emptyArrayToPopulate);
        }
    }
}