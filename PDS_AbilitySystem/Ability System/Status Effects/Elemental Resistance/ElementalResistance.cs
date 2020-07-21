﻿﻿using PhantomDragonStudio.Tools;

namespace PhantomDragonStudio.Ability_System
{
    [System.Serializable]
    public class ElementalResistance : IElementalResistance
    {
        public ElementalResistance(ElementalType type, float value)
        {
            ResistanceInfo = new TypeValuePair<ElementalType, float>(type, value);
        }

        public TypeValuePair<ElementalType, float> ResistanceInfo { get; set; }

        public override string ToString()
        {
            return ResistanceInfo.type + " " + ResistanceInfo.value;
        }
    }
}
