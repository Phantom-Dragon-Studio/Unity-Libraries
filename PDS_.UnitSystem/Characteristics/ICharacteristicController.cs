using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.Characters;
using PhantomDragonStudio.UnitSystem.CombatStats;

namespace PhantomDragonStudio.UnitSystem.Characteristics
{
    public interface ICharacteristicController
    {
        ICharacter Character { get; }
        ICharacterAttributesHandler Attributes { get;}
        ICombatStatsHandler CombatStats { get;}
    }
}