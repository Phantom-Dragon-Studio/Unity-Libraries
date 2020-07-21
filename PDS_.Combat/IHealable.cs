using System;
using PhantomDragonStudio.Combat.Event_Args;

namespace PhantomDragonStudio.Combat
{
    public interface IHealable
    {
        void RestoreHealth(float amount);

        event EventHandler<HealedEventArgs> Healed;
    }
}
