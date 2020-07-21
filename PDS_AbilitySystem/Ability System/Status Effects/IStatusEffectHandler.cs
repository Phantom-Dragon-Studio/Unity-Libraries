﻿﻿using System.Collections.Generic;

namespace PhantomDragonStudio.Ability_System
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