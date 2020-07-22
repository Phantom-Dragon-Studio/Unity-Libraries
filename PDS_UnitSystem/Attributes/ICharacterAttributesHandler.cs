﻿﻿namespace PhantomDragonStudio.UnitSystem.Attributes
{
    public interface ICharacterAttributesHandler
    {
        void UpdateAttribute(AttributeType type, float amount);

        void AddAttribute(AttributeType type, float amount);

        ICharacterAttribute NULL { get; }
        ICharacterAttribute Agility { get; }
        ICharacterAttribute Strength { get; }
        ICharacterAttribute Wisdom { get; }
        ICharacterAttribute Endurance { get; }
    }
}
