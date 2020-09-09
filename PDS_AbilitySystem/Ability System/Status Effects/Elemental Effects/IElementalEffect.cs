﻿﻿namespace PhantomDragonStudio.AbilitySystem
{
    public enum ElementalType
    {
        _None = 0,
        Fire,
        Water,
        Earth,
        Wind,
        Lightning,
        Divine,
        Dark,
        Arcane
    }

    public interface IElementalType
    {
        ElementalType ElementalType { get; }
        float Amount { get; }
    }
}