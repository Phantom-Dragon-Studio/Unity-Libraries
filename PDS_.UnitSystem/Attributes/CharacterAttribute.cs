using System;

namespace PhantomDragonStudio.UnitSystem.Attributes
{
    /// <summary>
    /// This class is strictly a data container containing a pair of values, but is more managable than using a key value pair.
    /// </summary>
    public enum AttributeType
    {
        _None,
        Agility,
        Strength,
        Wisdom,
        Endurance,
    }

    [System.Serializable]
    public class CharacterAttribute : ICharacterAttribute
    {
        public event EventHandler<AttributeChangedEventArgs> Changed;
        public TypeValuePair<AttributeType, float> AttributeInfo { get; }

        public CharacterAttribute(TypeValuePair<AttributeType, float> attributeInfo)
        {
            this.AttributeInfo = attributeInfo;
        }

        public void UpdateValue(float value)
        {
            this.AttributeInfo.value += value;
            Changed?.Invoke(this, new AttributeChangedEventArgs(this));
        }

        public class AttributeChangedEventArgs : EventArgs
        {
            public AttributeChangedEventArgs(ICharacterAttribute characterAttribute)
            {
                CharacterAttribute = characterAttribute;
            }

            public ICharacterAttribute CharacterAttribute { get; private set; }
        }

        public override string ToString()
        {
            return AttributeInfo.type.ToString() + ": " + AttributeInfo.value.ToString();
        }
    }
}