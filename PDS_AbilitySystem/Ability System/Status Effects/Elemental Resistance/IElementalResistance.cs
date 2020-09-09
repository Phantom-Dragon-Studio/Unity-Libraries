﻿﻿using PhantomDragonStudio.Core.Utilities;

  namespace PhantomDragonStudio.AbilitySystem
{
    public interface IElementalResistance
    {
        TypeValuePair<ElementalType, float> ResistanceInfo { get; set; }

        string ToString();
    }
}
