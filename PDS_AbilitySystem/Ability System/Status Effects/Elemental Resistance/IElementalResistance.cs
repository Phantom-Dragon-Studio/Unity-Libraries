﻿﻿using PhantomDragonStudio.Core.Utilities;

namespace PhantomDragonStudio.Ability_System
{
    public interface IElementalResistance
    {
        TypeValuePair<ElementalType, float> ResistanceInfo { get; set; }

        string ToString();
    }
}
