﻿﻿namespace PhantomDragonStudio.AbilitySystem
{
    public static class StatusEffectFactory
    {
        public static IStatusEffect Create(PhysicalStatusEffectType typeToCreate)
        {
            IStatusEffect newStatusEffect = new StatusEffect();

            return newStatusEffect;
        }
    }
}