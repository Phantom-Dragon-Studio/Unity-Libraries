using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using PhantomDragonStudio;
using PhantomDragonStudio.Combat;

namespace PhantomDragonStudio.PoolingSystem
{
    /// <summary>
    /// This pool is tracked by the IDamageable GAME OBJECT's instanceID. 
    /// </summary>

    [Serializable]
    public class DamageablePool : ScriptableObject, IPool<IDamageable>
    {
        [SerializeField] protected int startCount = default;
        [SerializeField] [ShowOnly] private int currentSize = default;
        
        private KeyValuePair<int, IDamageable> pointer;
        private Dictionary<int, IDamageable> pool = new Dictionary<int, IDamageable>();

        public IDamageable FindInPool(int key)
        {
            return pool.ContainsKey(key) ? pool[key] : null;
        }

        public void AddToPool(IDamageable damageable)
        {
            if (!pool.ContainsKey(damageable.GameObject.GetInstanceID()))
            {
                pool.Add(damageable.GameObject.GetInstanceID(), damageable);
                currentSize = pool.Count;
            }
            else
                Debug.LogError("Attempting to add an already existing " + damageable + " to damageable pool.");
        }

        public IDamageable RemoveFromPool(IDamageable damageable = null)
        {
            if (pool.Count > 0)
            {
                if (damageable != null)
                {
                    pool.Remove(damageable.GameObject.GetInstanceID());
                    currentSize = pool.Count;
                    return damageable;
                }
                pointer = pool.First();
                pool.Remove(pointer.Key);
                currentSize = pool.Count;
                return pointer.Value;
            }

            Debug.LogError(this.name + " is empty!");
            return null;
        }
    }
}