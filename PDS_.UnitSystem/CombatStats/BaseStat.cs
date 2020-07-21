using System;
using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;

namespace PhantomDragonStudio.UnitSystem.CombatStats
{
    public abstract class BaseStat : ICombatStat
    {
        public abstract event EventHandler<CombatStatCalculatedEventArgs> Calculated;
        private const float DefaultValue = 0f;
        public float Value { get; protected set; }
        public CombatStatType CombatStatType { get; protected set; }
        public abstract CharacterLeagueType LeagueType { get; }

        private ICharacterAttribute PrimaryAttribute { get; set; }
        private ICharacterAttribute SecondaryAttribute { get; set; }
        private float PrimaryAttributeCalculatedValue { get => primaryPlaceHolder; set => primaryPlaceHolder = value; }
        private float SecondaryAttributeCalculatedValue { get => secondaryPlaceHolder; set => secondaryPlaceHolder = value; }

        private float primaryPlaceHolder = DefaultValue;
        private float secondaryPlaceHolder = DefaultValue;

        public BaseStat(CombatStatType type, ICharacterAttribute primaryAttribute, ICharacterAttribute secondaryAttribute)
        {
            Value = DefaultValue;
            CombatStatType = type;
            PrimaryAttribute = primaryAttribute;
            SecondaryAttribute = secondaryAttribute;

            if (PrimaryAttribute != null)
                PrimaryAttribute.Changed += (sender, args) => Calculate();
            if (secondaryAttribute != null)
                SecondaryAttribute.Changed += (sender, args) => Calculate();
        }

        public override string ToString()
        {
            return CombatStatType + ": " + Value;
        }

        protected virtual void Calculate()
        {
            PrimaryAttributeCalculatedValue = DefaultValue;
            SecondaryAttributeCalculatedValue = DefaultValue;


            if (PrimaryAttribute != null)
            {
                PrimaryAttributeCalculatedValue = PrimaryAttribute.AttributeInfo.value;
                PrimaryAttributeCalculatedValue *= CharacteristicsCalculator.GetPrimaryAttributeModifier(this);
            }
            if (SecondaryAttribute != null)
            {
                SecondaryAttributeCalculatedValue = SecondaryAttribute.AttributeInfo.value;
                SecondaryAttributeCalculatedValue *= CharacteristicsCalculator.GetSecondaryAttributeModifier(this);
            }

            Value = PrimaryAttributeCalculatedValue + SecondaryAttributeCalculatedValue;
        }
    }

    public class CombatStatCalculatedEventArgs : EventArgs
    {
        public ICombatStat Stat { get; }

        public CombatStatCalculatedEventArgs(ICombatStat stat)
        {
            Stat = stat;
        }
    }
}