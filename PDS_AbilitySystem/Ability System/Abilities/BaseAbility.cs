using System.Collections;
using UnityEngine;
using Logger = PhantomDragonStudio.Core.Utilities.Logger;

namespace PhantomDragonStudio.Ability_System
{
    [System.Serializable]
    public abstract class BaseAbility : IAbility
    {
        [SerializeField] protected AbilityInfo abilityInformation = default;
        public AbilityInfo AbilityInformation => abilityInformation;
        public AbilityController Caster { get; private set; } 
        private IEnumerator cooldownCoroutine;
        private WaitForSeconds cooldown;
        private bool isOnCooldown = false;
        
        public virtual void Initialize(AbilityController abilityController)
        {
            cooldownCoroutine = CooldownTick();
            Caster = abilityController;
            cooldown = new WaitForSeconds(abilityInformation.CooldownTime);
            //Call this in child class then do custom behavior.
        }

        public virtual void Cast()
        {
            if(isOnCooldown) return;
            EngageCooldown();
        }

        public void IncreaseLevel(int levelsToIncrease)
        {
            AbilityInformation.CurrentLevel += levelsToIncrease;
            if (AbilityInformation.CurrentLevel > AbilityInformation.MaxLevel)
                AbilityInformation.CurrentLevel = AbilityInformation.MaxLevel;
        }

        public void DecreaseLevel(int levelsToDecrease)
        {   
            AbilityInformation.CurrentLevel -= levelsToDecrease;
            if (AbilityInformation.CurrentLevel <= 0)
                AbilityInformation.CurrentLevel = 0;
        }
        
        public void EngageCooldown()
        {
            isOnCooldown = true;
        }

        public void ResetCooldown()
        {
            isOnCooldown = false;
        }

        private IEnumerator CooldownTick()
        {
            Logger.Say("Timer started: " + cooldown);
            yield return cooldown;
            Logger.Say("Wait completed!");
            ResetCooldown();
        }
    }
}