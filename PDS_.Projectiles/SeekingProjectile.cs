﻿﻿// using System;
// using UnityEngine;
// using PhantomDragonStudio.PoolingSystem;
//
// namespace PhantomDragonStudio.Combat.Projectiles
// {
//     public class SeekingProjectile : MonoBehaviour, IProjectile
//     {
//         public event EventHandler<ProjectileCollisionEventArgs> Collided = default;
//         
//         [SerializeField] private new Transform transform = default;
//         [SerializeField] private ProjectileData projectileData = default;
//         [SerializeField] private ProjectileBehavior behavior = default;
//         [SerializeField] private new Rigidbody rigidbody = default;
//         public ProjectilePool Pool => owningPool;
//         public ProjectileData Data => projectileData;
//         public Transform Transform => transform;
//         public ProjectileBehavior Behavior => behavior;
//         public Rigidbody Rigidbody => rigidbody;
//         private float currentLifeTime;
//         private float accuracy = 10;
//         private ProjectilePool owningPool;
//         private Boolean hasCollided = true;
//         public Boolean HasCollided => hasCollided;
//         public void Initialize(ProjectileData _projectileData, ProjectileBehavior _behavior, ProjectilePool poolToUse)
//         {
//             transform = gameObject.transform;
//             projectileData = _projectileData;
//             hasCollided = false;
//             owningPool = poolToUse;
//             // Behavior.Construct(this); Unused atm.
//         }
//
//         public void Activate()
//         {
//             hasCollided = false;
//             currentLifeTime = 0f;
//             gameObject.SetActive(true);
//             if (!hasCollided && Data.Lifetime > currentLifeTime)
//                 behavior.Perform(this);
//         }
//         
//         public void Deactivate()
//         {
//             hasCollided = true;
//             this.gameObject.SetActive(false);
//             Pool.AddToPool(this);
//             // Debug.Log(transform.GetInstanceID() + " has deactivated.");
//         }
//         
//         private void OnCollisionEnter(Collision other)
//         {
//             // Debug.Log(transform.GetInstanceID() + " has collided with " + other.gameObject.name);
//             Behavior.End(this);
//         }
//         
//         Vector3 BallisticVelocity(Vector3 source, Vector3 target, Vector3 targetVelocity)
//         {
//             // use a few iterations of this recursive function to zero in on 
//             // where the target will be, when the projectile gets there
//             Vector3 horiz = new Vector3(target.x - source.x, 0, target.z - source.z);
//             float t = horiz.magnitude / projectileData.Speed;
//             for (int a = 0; a < accuracy; a++)
//             {
//                 horiz = new Vector3(target.x + targetVelocity.x * t - source.x, 0, target.z + targetVelocity.z * t - source.z);
//                 t = horiz.magnitude / projectileData.Speed;
//             }
//             // after t seconds, the cannonball will reach the horizontal location of the target -
//             // so all we have to do is make sure its 'y' coordinate zeros out right there
//             float gravityY = (Physics.gravity * (.5f * t * t)).y;
//             // now we've calculated how much the projectile will fall during that time
//             // so let's add a 'y' component to the velocity that will take care of the rest
//             float yComponent = (target.y - source.y - gravityY) / t + targetVelocity.y;
//             horiz = horiz.normalized * projectileData.Speed;
//             return new Vector3(horiz.x, yComponent, horiz.z);
//         }
//         
//         private void Update()
//         {
//             currentLifeTime += Time.deltaTime;
//         }
//     }
// }