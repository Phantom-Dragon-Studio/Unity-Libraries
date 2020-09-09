using PhantomDragonStudio.UnitSystem.Attributes;

namespace PhantomDragonStudio.AbilitySystem
{
    public interface IStatusEffect
    {
        PhysicalStatusEffectType PhysicalStatusEffect { get; }
        ElementalType ElementalType { get; }
        AttributeType AttributeModifier { get; }
    }
}