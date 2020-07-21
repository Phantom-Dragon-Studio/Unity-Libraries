using System;

namespace PhantomDragonStudio.Combat
{
    [Serializable]
    public class DestructibleHealth : Health
    {
        private Destructible destructible;

        public void Initialize(float amount, Destructible destructibleToWatch)
        {
            base.Initialize(amount);
            destructible = destructibleToWatch;
        }
        
        protected override void HealthCheck()
        {
            base.HealthCheck();
            if(CurrentHealth == 0)
                destructible.Dispose();
        }
    }
}