﻿﻿using PhantomDragonStudio.Tools;

namespace PhantomDragonStudio.Ability_System
{
    public interface IElementalResistance
    {
        TypeValuePair<ElementalType, float> ResistanceInfo { get; set; }

        string ToString();
    }
}
