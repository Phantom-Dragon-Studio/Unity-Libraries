using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.CombatStats;
using UnityEngine;

namespace PhantomDragonStudio.Ability_System
{
    [System.Serializable]
    public class StatusEffect : IStatusEffect
    {
        public StatusEffect()
        {
        }

        [SerializeField] private PhysicalStatusEffectType effectType;
        public PhysicalStatusEffectType PhysicalStatusEffect { get; private set; }
        public ElementalType ElementalType { get; private set; }
        public AttributeType AttributeModifier { get; private set; }
        public ICombatStat EffectedStat { get; private set; }

        public override string ToString()
        {
            return $"Type: " + ElementalType.ToString() + "Duration: " + /*TickDuration.ToString() +*/ "Bonus: " +
                   EffectedStat.ToString();
        }
    }
}