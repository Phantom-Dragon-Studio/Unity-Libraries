using System.Collections.Generic;

namespace PhantomDragonStudio.UnitSystem.Attributes
{
    
    /// <summary>
    /// This class manages all attributes on a given unit class. This is done to avoid unwanted changes to the attributes as well as seperated concerns.
    /// </summary>

    public class CharacterAttributesHandler : ICharacterAttributesHandler
    {
        private Dictionary<AttributeType, ICharacterAttribute> Attributes { get; } = new Dictionary<AttributeType, ICharacterAttribute>();
        public ICharacterAttribute NULL => Attributes[AttributeType._None];
        public ICharacterAttribute Agility => Attributes[AttributeType.Agility];
        public ICharacterAttribute Strength => Attributes[AttributeType.Strength];
        public ICharacterAttribute Wisdom => Attributes[AttributeType.Wisdom];
        public ICharacterAttribute Endurance => Attributes[AttributeType.Endurance];

        public void UpdateAttribute(AttributeType type, float amount)
        {
            Attributes[type].UpdateValue(amount);
        }

        public void AddAttribute(AttributeType type, float amount)
        {
            if (!Attributes.ContainsKey(type))
            {
                var temp = CharacterAttributeFactory.Create(type, amount);
                Attributes.Add(temp.AttributeInfo.type, temp);
            }
        }
    }
}