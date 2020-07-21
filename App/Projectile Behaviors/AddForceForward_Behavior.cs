using PhantomDragonStudio.Combat.Projectile_Behavior;
using UnityEngine;

namespace App.Projectile_Behaviors
{
    [CreateAssetMenu(fileName ="New Add Force Forward Behavior", menuName ="Phantom Dragon Studio/Combat System/Projectile Behaviors/Add Force Forward")]

    public class AddForceForward_Behavior : ProjectileBehavior
    {
        [SerializeField] private bool affectedByGravity = false;
        private ProjectileData data;

        public override void Perform(IProjectile performingProjectile)
        {
            performingProjectile.Rigidbody.AddForce(performingProjectile.Transform.forward * (100 * (performingProjectile.Data.Speed * Time.fixedDeltaTime)));
        }
        
        public override void End(IProjectile performingProjectile)
        {
            performingProjectile.Deactivate();
            performingProjectile.Rigidbody.velocity = Vector3.zero;
            performingProjectile.Rigidbody.angularVelocity = Vector3.zero; 
        }
    }
}
