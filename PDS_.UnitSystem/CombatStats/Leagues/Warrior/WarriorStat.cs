using System;
using PhantomDragonStudio.UnitSystem.Attributes;

namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Warrior
{
    public class WarriorStat : BaseStat, ICombatStat
    {
        public override event EventHandler<CombatStatCalculatedEventArgs> Calculated;
        public override CharacterLeagueType LeagueType => CharacterLeagueType.Warrior;

        public WarriorStat(CombatStatType type, ICharacterAttribute primaryAttribute, ICharacterAttribute secondaryAttribute) 
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