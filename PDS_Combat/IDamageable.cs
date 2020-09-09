using System;

namespace PhantomDragonStudio.Combat
{
    public interface IDamageable
    {
        void TakeDamage(float amount);
        event EventHandler<DamagedEventArgs> Damaged;
    }
}