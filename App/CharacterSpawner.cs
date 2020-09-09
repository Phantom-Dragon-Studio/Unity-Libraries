using PhantomDragonStudio.Combat;
using PhantomDragonStudio.PoolingSystem.Character_Pools;
using PhantomDragonStudio.UnitSystem.Characters;
using UnityEngine;

namespace App
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private CharacterPool[] pools = default;
        public int poolIndexToSpawnFrom;
        public Vector3 offset;
        public float spawnInterval;
        public bool shouldSpawn, individualSpawning, cycleSelectedPool;
        private ICharacter spawnedCharacter;
        private IDamageable damageable;

        private float time;
        private Transform myTransform;

        private void Awake()
        {
            myTransform = transform;
        }
        
        private void Update()
        {
            time += Time.deltaTime;
            if (time > spawnInterval && shouldSpawn)
            {
                if (cycleSelectedPool)
                {
                    poolIndexToSpawnFrom++;
                    if (poolIndexToSpawnFrom >= pools.Length)
                        poolIndexToSpawnFrom = 0;
                }
                
                if (individualSpawning)
                    SpawnSingle(poolIndexToSpawnFrom);
                else
                    SpawnSinglePool(poolIndexToSpawnFrom);
                time = 0;
            }
        }
        
         

        private void SpawnSingle(int poolIndex)
        {
            spawnedCharacter = pools[poolIndex].RemoveFromPool();
            damageable = spawnedCharacter as IDamageable;
            damageable.GameObject.transform.position = myTransform.position + offset;
            damageable.GameObject.transform.rotation = myTransform.rotation;
        }

        private void SpawnSinglePool(int poolIndex)
        {
            for (int i = 0; i < pools[poolIndex].StartCount; i++)
            {
                damageable = CharacterFactory.Create(pools[poolIndex].CharacterToPool.Prefab, pools[poolIndex]) as IDamageable;
                damageable.GameObject.transform.position = myTransform.position + offset;
                damageable.GameObject.transform.rotation = myTransform.rotation;
            }
        }

        public void SpawnAllPools()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                for (int j = 0; j < pools[i].StartCount; j++)
                {
                    damageable = CharacterFactory.Create(pools[i].CharacterToPool.Prefab, pools[i]) as IDamageable;
                    damageable.GameObject.transform.position = myTransform.position + ((i * j) * offset);
                    damageable.GameObject.transform.rotation = myTransform.rotation;
                }
            }
        }
    }
}