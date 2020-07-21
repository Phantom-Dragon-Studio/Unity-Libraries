﻿﻿namespace PhantomDragonStudio.Ability_System
{
    [System.Serializable]
    public abstract class StatusEffectFunctionality
    {
        public abstract void Apply();

        public abstract void Tick();

        public abstract void Dispose();
    }
}
