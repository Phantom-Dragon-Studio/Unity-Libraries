using PhantomDragonStudio.UnitSystem.Characteristics;
using PhantomDragonStudio.UnitSystem.Data;

namespace PhantomDragonStudio.UnitSystem.Characters
{
    public interface ICharacter
    {
        int GetInstanceID();
        ICharacter Construct(ICharacteristicController characteristicController);
        ICharacterSheet CharacterSheet { get; }
        ICharacteristicController CharacteristicController { get; }
    }
}
