using PhantomDragonStudio.UnitSystem.Attributes;
using PhantomDragonStudio.UnitSystem.Characters;
using PhantomDragonStudio.UnitSystem.CombatStats;

namespace PhantomDragonStudio.UnitSystem.Characteristics
{
    public class CharacteristicController : ICharacteristicController
    {
        public ICharacter Character { get; private set; }
        public ICharacterAttributesHandler Attributes { get; private set; }
        public ICombatStatsHandler CombatStats { get; private set; }


        public CharacteristicController(ICharacter character)
        {
            Character = character;
            Attributes = CharacterAttributesHandlerFactory.Create(Character.CharacterSheet.Attributes);
            CombatStats = CombatStatHandlerFactory.Create(this, Character.CharacterSheet.League);
            //TalentPoints = 
        }
    }
}
