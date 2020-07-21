﻿﻿using System.Collections.Generic;
using PhantomDragonStudio.CombatMechanics;
using PhantomDragonStudio.CombatMechanics.Projectiles;
using UnityEngine;

namespace PhantomDragonStudio.PoolingSystem
{
    public static class ProjectileCollisionListener
    {
        private static readonly Dictionary<int, IProjectile> watchedProjectiles = new Dictionary<int, IProjectile>();
        private static IDamageable damageable;
        
        public static void AddToWatchedProjectiles(IProjectile projectile)
        {
            watchedProjectiles.Add(projectile.GetInstanceID(), projectile);
            projectile.Collided += (sender, args) => FindReceiver(args.GOInstanceID, args.Value);
        }

        public static void RemoveFromWatchedProjectiles(IProjectile projectile)
        {
            if (!watchedProjectiles.ContainsKey(projectile.GetInstanceID())) return;
            watchedProjectiles.Remove(projectile.GetInstanceID());
            projectile.Collided -= (sender, args) => { Debug.Log("Projectile removed from Collision Listener!");};
        }

        private static void FindReceiver(int argsGoInstanceId, float argsValue)
        {
            damageable = DamageablePoolHandler.SearchPool(argsGoInstanceId);
            damageable?.TakeDamage(argsValue);
        }
    }
}