using System;
using System.Collections.Generic;
using System.Linq;

namespace PhantomDragonStudio.PoolingSystem.Projectile_Pools
{
    /// <summary>
    /// This pool is tracked by IProjectile InstanceID
    /// </summary>
    [CreateAssetMenu(fileName = "New Projectile Pool", menuName = "Phantom Dragon Studio/Pooling/Projectile Pool")]
    [Serializable]
    public class ProjectilePool : ScriptableObject,  IPool<IProjectile>
    {
        [SerializeField] protected int startCount = default;
        [SerializeField] private Projectile projectilesToPool = default;
        [SerializeField] [ShowOnly] private int currentSize = default;
        private IProjectile freshInstance;
        private KeyValuePair<int, IProjectile> pointer;
        private Dictionary<int, IProjectile> pool = new Dictionary<int, IProjectile>();
        public void GeneratePool()
        {
            currentSize = 0;
            for (int j = 0; j < startCount; j++)
            {
                freshInstance = FactoryRequest();
                freshInstance.Deactivate();
            }
        }
        
        public IProjectile FindInPool(int key)
        {
            return pool.ContainsKey(key) ? pool[key] : null;
        }

        public void AddToPool(IProjectile damageable)
        {
            if (!pool.ContainsKey(damageable.GetInstanceID()))
            {
                pool.Add(damageable.GetInstanceID(), damageable);
                currentSize = pool.Count;
            }
            else
                Debug.LogWarning("Attempting to add an already existing object to " + this + " with ID: " + damageable.GetInstanceID().ToString());
        }


        public IProjectile RemoveFromPool(IProjectile projectile = null)
        {
            if (pool.Count > 0)
            {
                pointer = pool.FirstOrDefault();
                pool.Remove(pointer.Key);
                currentSize = pool.Count;
                // Debug.Log("Removed from pool: " + pointer.Value.Transform.GetInstanceID());
                return pointer.Value;
            }
            freshInstance = FactoryRequest();

            Debug.LogWarning("Created NEW: " + freshInstance + " with InstanceID: " + freshInstance.Transform.GetInstanceID().ToString() + " for pool: " + this);
            return freshInstance;
        }

        protected IProjectile FactoryRequest()
        {
            freshInstance = ProjectileFactory.Create(projectilesToPool, this);
            ProjectileCollisionListener.AddToWatchedProjectiles(freshInstance);
            return freshInstance;
        }
    }
}
