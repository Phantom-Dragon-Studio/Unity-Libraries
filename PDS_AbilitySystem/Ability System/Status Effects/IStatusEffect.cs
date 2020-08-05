using PhantomDragonStudio.UnitSystem.Attributes;

namespace PhantomDragonStudio.Ability_System
{
    public interface IStatusEffect
    {
        PhysicalStatusEffectType PhysicalStatusEffect { get; }
        ElementalType ElementalType { get; }
        AttributeType AttributeModifier { get; }
    }
}