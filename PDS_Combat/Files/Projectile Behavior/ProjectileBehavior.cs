﻿﻿ namespace PhantomDragonStudio.Combat.Projectile_Behavior
{
    //The entire point of this class is for polymorphism between behavior types in the inspector.
    public abstract class ProjectileBehavior : ScriptableObject, IProjectileBehavior
    {
        public virtual void Construct(IProjectile projectile) { }

        public virtual void Perform(IProjectile projectile) { }

        public virtual void End(IProjectile projectile) { }
    }
}
