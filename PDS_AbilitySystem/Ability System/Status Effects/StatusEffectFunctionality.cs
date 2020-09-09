﻿﻿namespace PhantomDragonStudio.AbilitySystem
{
    [System.Serializable]
    public abstract class StatusEffectFunctionality
    {
        public abstract void Apply();

        public abstract void Tick();

        public abstract void Dispose();
    }
}
