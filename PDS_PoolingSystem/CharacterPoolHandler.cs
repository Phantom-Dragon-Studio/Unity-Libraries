using PhantomDragonStudio.PoolingSystem.Character_Pools;

namespace PhantomDragonStudio.PoolingSystem
{
    public class CharacterPoolHandler : MonoBehaviour
    {
        [SerializeField] private CharacterPool[] pools = default;
        private void Awake()
        {
            for (int i = 0; i < pools.Length; i++)
            {
                for (int j = 0; j < pools[i].StartCount; j++)
                {
                    DamageablePoolHandler.AddToPool(CharacterFactory.Create(pools[i].CharacterToPool.Prefab, pools[i]) as IDamageable);
                }
            }
        }

        public ICharacter SearchAllPools(int InstanceID)
        {
            ICharacter foundIndex = null;
            for (int i = 0; i < pools.Length; i++)
            {
                foundIndex = pools[i].FindInPool(InstanceID);
                if (foundIndex == null)
                    continue;
                else
                    i = pools.Length;
            }

            return foundIndex;
        }
    }
}