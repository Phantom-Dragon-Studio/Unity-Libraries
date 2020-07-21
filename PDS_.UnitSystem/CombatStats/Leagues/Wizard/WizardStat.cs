using System;
using PhantomDragonStudio.UnitSystem.Attributes;

namespace PhantomDragonStudio.UnitSystem.CombatStats.Leagues.Wizard
{
    public class WizardStat : BaseStat, ICombatStat
    {
        public override event EventHandler<CombatStatCalculatedEventArgs> Calculated;
        public override CharacterLeagueType LeagueType => CharacterLeagueType.Wizard;
        public WizardStat(CombatStatType type, ICharacterAttribute primaryAttribute, ICharacterAttribute secondaryAttribute) 
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