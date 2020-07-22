using System;
using PhantomDragonStudio.Combat.Event_Args;
using PhantomDragonStudio.Combat.Projectile_Behavior;
using PhantomDragonStudio.PoolingSystem;
using UnityEngine;

namespace PhantomDragonStudio.Projectiles
{
    public interface IProjectile
    {
        event EventHandler<ProjectileCollisionEventArgs> Collided;
        void Initialize(ProjectileData _projectileData, ProjectileBehavior _behavior, ProjectilePool poolToUse);
        ProjectileData Data { get; }
        Transform Transform { get; set; }
        int GetInstanceID();
        void Activate();
        void Deactivate();
    }
}
