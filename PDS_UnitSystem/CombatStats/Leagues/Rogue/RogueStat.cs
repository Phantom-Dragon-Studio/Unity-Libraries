using System;
using PhantomDragonStudio.UnitSystem.Attributes;

namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Rogue
{
    public class RogueStat : BaseStat, ICombatStat
    {
        public override event EventHandler<CombatStatCalculatedEventArgs> Calculated;
        public override CharacterLeagueType LeagueType => CharacterLeagueType.Rogue;

        public RogueStat(CombatStatType type, ICharacterAttribute primaryAttribute, ICharacterAttribute secondaryAttribute) 
            : base(type, primaryAttribute, secondaryAttribute)
        {
        }

        protected override void Calculate()
        {
            base.Calculate();
            Value = CharacteristicsCalculator.CalculateCombatStat(this);
            Calculated?.Invoke((this), new CombatStatCalculatedEventArgs(this));
        }
    }
} 