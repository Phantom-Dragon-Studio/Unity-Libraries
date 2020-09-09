using PhantomDragonStudio.Projectiles;

namespace  PhantomDragonStudio.Combat
{
    public interface IProjectileBehavior 
    {
        void Construct(IProjectile projectile);

        void Perform(IProjectile projectile);

        void End(IProjectile projectile);
    }
}
