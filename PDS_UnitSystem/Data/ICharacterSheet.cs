using PhantomDragonStudio.Core.Utilities;
using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.Characters;
using PhantomDragonStudio.UnitSystem.CombatStats.Leagues;

namespace PhantomDragonStudio.UnitSystem.Data
{
    public interface ICharacterSheet
    {
        ICharacterAttribute[] Attributes { get; }
        Label Label { get; }
        ICharacterLeague League { get; }
        Character Prefab { get; }
    }
}
