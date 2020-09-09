using System;

namespace PhantomDragonStudio.Combat
{
    public interface IHealable
    {
        void RestoreHealth(float amount);

        event EventHandler<HealedEventArgs> Healed;
    }
}
