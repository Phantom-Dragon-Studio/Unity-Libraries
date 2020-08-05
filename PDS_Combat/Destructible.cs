using System;
using PhantomDragonStudio.Combat.Event_Args;

namespace PhantomDragonStudio.Combat
{
    public class Destructible : MonoBehaviour, IDestructible, IDamageable, IDisposable
    {
        [SerializeField] private float maxHealth = default;
        private DestructibleHealth health = new DestructibleHealth();
        private GameObject gameobject;
        public event EventHandler<DamagedEventArgs> Damaged;
        public GameObject GameObject => gameobject;

        private void Awake()
        {
            gameobject = gameObject;
            health.Initialize(maxHealth, this);
            DamageablePoolHandler.AddToPool(this);
        }

        public void Dispose()
        {
            Debug.Log("Dispose Destructible....");
            DamageablePoolHandler.RemoveFromPool(this);
            transform.DetachChildren();
            Destroy(this.gameobject); //TODO Add to available destructibles Pool
        }

        public void TakeDamage(float amount)
        {
            health.UpdateCurrentHealth(-amount);
            Damaged?.Invoke(this, new DamagedEventArgs(-amount)); 

        }
    }
}
