using System;
using PhantomDragonStudio.Combat.Event_Args;
using PhantomDragonStudio.Combat.Projectile_Behavior;
using PhantomDragonStudio.PoolingSystem;
using PhantomDragonStudio.Projectiles;
using UnityEngine;

namespace App
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        [SerializeField] private new Transform transform = default;
        [SerializeField] private ProjectileData projectileData = default;
        [SerializeField] private ProjectileBehavior behavior = default;
        [SerializeField] private new Rigidbody rigidbody = default;

        public event EventHandler<ProjectileCollisionEventArgs> Collided = default;
        
        #region Private Variable
        private float currentLifeTime;
        private ProjectilePool owningPool;
        private int collisions = 0;
        #endregion
        
        #region Getters
        public ProjectileData Data => projectileData;
        Transform IProjectile.Transform { get; set; }
        public Transform Transform => transform;
        public ProjectileBehavior Behavior => behavior;
        public Rigidbody Rigidbody => rigidbody;

        #endregion
        
        public void Initialize(ProjectileData _projectileData, ProjectileBehavior _behavior, ProjectilePool poolToUse)
        {
            owningPool = poolToUse;
            transform = gameObject.transform;
            projectileData = _projectileData;
        }

        public void Activate()
        {
            collisions = 0;
            currentLifeTime = 0f;
            gameObject.SetActive(true);
            if (Data.Lifetime > currentLifeTime)
                behavior.Perform(this);
        }

        public void Deactivate()
        {
            this.gameObject.SetActive(false);
            if (collisions <= 1)
            {
                owningPool.AddToPool(this);
            }
            // Debug.Log(transform.GetInstanceID() + " has deactivated.");
        }
        
        private void Update()
        {
            currentLifeTime += Time.deltaTime;
            if(currentLifeTime > Data.Lifetime)
                Behavior.End(this);
        }
        
        private void OnCollisionEnter(Collision other)
        {
            collisions++;
            Behavior.End(this);
            if (collisions <= 1)
            {
                Collided?.Invoke(this, new ProjectileCollisionEventArgs(other.gameObject.GetInstanceID(), projectileData.Value));
            }
        }
    }
} 