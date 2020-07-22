﻿﻿using PhantomDragonStudio.CombatMechanics;
using UnityEngine;
using UnityEngine.Serialization;

namespace PhantomDragonStudio.PoolingSystem
{
    public class ProjectilePoolHandler : MonoBehaviour
    {
        [FormerlySerializedAs("pool")] [SerializeField] private ProjectilePool[] pools = default;
        public ProjectilePool[] Pools => pools;

        private void Awake()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                pools[i].GeneratePool();
            }
        }
    }
}