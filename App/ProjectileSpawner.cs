using PhantomDragonStudio.PoolingSystem;
using PhantomDragonStudio.Projectiles;
using UnityEngine;

namespace App
{
    public class ProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private ProjectilePool [] pools = default;
        private IProjectile spawnedProjectile;
        private Transform attachmentPointTransform;

        private void Awake()
        {
            attachmentPointTransform = transform;
        }

        public void LaunchPrimaryProjectile()
        {
            spawnedProjectile = pools[0].RemoveFromPool();
            spawnedProjectile.Transform.position = attachmentPointTransform.position;
            spawnedProjectile.Transform.rotation = attachmentPointTransform.rotation;
            spawnedProjectile.Activate();
        }
        
        public void LaunchSecondaryProjectile()
        {
            spawnedProjectile = pools[1].RemoveFromPool();
            spawnedProjectile.Transform.position = attachmentPointTransform.position;
            spawnedProjectile.Transform.rotation = attachmentPointTransform.parent.rotation;
            spawnedProjectile.Activate();
        }
    }
}