﻿﻿using PhantomDragonStudio.UnitSystem.Characteristics;

  namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues
{
    /// <summary>
    /// What is CharacterLeague and what is it responsible for?
    /// Tells the CharacterLeague's specific factory type that it needs to generate stats and place them inside of our array.
    /// </summary>
    public abstract class CharacterLeague : ICharacterLeague
    {
        public abstract CharacterLeagueType LeagueType { get; }

        public abstract ICombatStat[] GenerateCombatStats(ICharacteristicController characteristicController, ICombatStat[] emptyArrayToPopulate);


        public override string ToString()
        {
            return LeagueType.ToString();
        }
    }
}
