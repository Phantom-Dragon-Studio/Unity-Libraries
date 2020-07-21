﻿﻿

//Note: A Null reference exception can be thrown by the AddAttribute line if the character sheet sends an attribute with a null value

namespace PhantomDragonStudio.UnitSystem.Attributes
{
    public static class CharacterAttributesHandlerFactory
    {
        public static ICharacterAttributesHandler Create(ICharacterAttribute[] attributes)
        {
            var newAttributeHandler = new CharacterAttributesHandler();
            if (attributes != null)
            {
                for (int i = 0; i < attributes.Length; i++)
                {
                    if(attributes[i] != null)
                    {
                        newAttributeHandler.AddAttribute(attributes[i].AttributeInfo.type, attributes[i].AttributeInfo.value);
                    }
                }
            }
            else Debug.LogError("Null list recieved by CharacterAttributesHandler Factory.");

            return newAttributeHandler;
        }
    }
}
