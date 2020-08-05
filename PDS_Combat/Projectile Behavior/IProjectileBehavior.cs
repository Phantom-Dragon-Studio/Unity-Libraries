using PhantomDragonStudio.Projectiles;

namespace  PhantomDragonStudio.Combat.Projectile_Behavior
{
    public interface IProjectileBehavior 
    {
        void Construct(IProjectile projectile);

        void Perform(IProjectile projectile);

        void End(IProjectile projectile);
    }
}
