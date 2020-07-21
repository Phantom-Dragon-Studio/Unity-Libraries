using PhantomDragonStudio.PoolingSystem;
using PhantomDragonStudio.Projectiles;
using UnityEngine;

namespace App
{
    public static class ProjectileFactory
    {
        public static IProjectile Create(Projectile projectile, ProjectilePool pool)
        {
            IProjectile newProjectile = GameObject.Instantiate(projectile);
            newProjectile.Initialize(projectile.Data, projectile.Behavior, pool);
            return newProjectile;
        }
    }
}