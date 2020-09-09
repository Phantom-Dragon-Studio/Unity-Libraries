using System.Collections;
using PhantomDragonStudio.Core.Utilities;
using UnityEngine;

namespace PhantomDragonStudio.AbilitySystem
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
            OutputHandler.Say("Timer started: " + cooldown);
            yield return cooldown;
            OutputHandler.Say("Wait completed!");
            ResetCooldown();
        }
    }
}