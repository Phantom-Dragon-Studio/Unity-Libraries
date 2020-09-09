using System;
using PhantomDragonStudio.Combat;
using PhantomDragonStudio.UnitSystem.Characters;

namespace PhantomDragonStudio.UnitSystem
{
    public class UnitHealth : Health, IDisposable
    {
        private Character character;
        public UnitHealth(Character characterToMonitor)
        {
            character = characterToMonitor;
            
            character.CharacteristicController.CombatStats.MaxHealth.Calculated += (sender, args) =>
            {
                if (!IsInitialized)
                    Initialize(args.Stat.Value);

                IncreaseMaxHealth(args.Stat.Value);
            };
            
            character.Healed += (sender, args) => UpdateCurrentHealth(args.Amount);
            character.Damaged += (sender, args) => UpdateCurrentHealth(-args.Amount);
        }

        public void Dispose()
        {   //TODO Not sure if we're unsubscribing correctly here. 
            character.Healed -= (sender, args) => { }; 
            character.Damaged -= (sender, args) => { }; 
        }

        protected override void HealthCheck()
        {
            base.HealthCheck();
            if(CurrentHealth <= 0)
            {
                OutputHandler.Say( this.character.GameObject.name + " has died.");
                character.Die();
            }
        }
    }
}