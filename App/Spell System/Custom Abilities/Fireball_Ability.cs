using PhantomDragonStudio.PoolingSystem;
using UnityEngine;

namespace App.Spell_System.Custom_Abilities
{
    [CreateAssetMenu(fileName = "New Fireball Ability", menuName = "Phantom Dragon Studio/Ability System/Abilities/Fireball Ability", order = 1)]
    public class Fireball_Ability : BaseAbility
    {
        [SerializeField] private StatusEffect[] statusEffects = default;
        [SerializeField] private ProjectilePool projectilePool = default;
        public StatusEffect[] StatusEffects => statusEffects;
        private IProjectile projectile;

        public override void Cast()
        {  
            // Debug.Log(AbilityInformation.GeneraInformation.Name + " is casting!");
            var casterTransform = Caster.transform;
            base.Cast();
            projectile = projectilePool.RemoveFromPool();
            projectile.Transform.position = casterTransform.position;
            projectile.Transform.rotation = casterTransform.rotation;
            projectile.Activate();
        }
    }
}
