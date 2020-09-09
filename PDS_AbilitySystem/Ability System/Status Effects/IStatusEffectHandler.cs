﻿﻿using System.Collections.Generic;

  namespace PhantomDragonStudio.AbilitySystem
{
    public enum PhysicalStatusEffectType
    {
        _None = 0,
        Burning,
        Frozen,
        Slowed,
        StaticallyCharged,
        Bleeding,
        Poisoned,
        Corrupted,
        TimedLife,
        Silenced,
        Blinded,
        Rooted,
        Stunned,

    }

    public interface IStatusEffectHandler
    {
        void AddNewStatusEffect(PhysicalStatusEffectType statusEffectType);

        Queue<IStatusEffect> GetAllStatusEffectsOfType(PhysicalStatusEffectType statusEffectType);
    }
}