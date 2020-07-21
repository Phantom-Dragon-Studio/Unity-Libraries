namespace PhantomDragonStudio.Combat.Health
{
    public class Health
    {
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        
        protected bool IsInitialized = false;
        private float healthRatio;
        
        protected void Initialize(float amount)
        {
            MaxHealth = amount;
            CurrentHealth = MaxHealth;
            IsInitialized = true;
        }

        public void UpdateCurrentHealth(float amount)
        {
            CurrentHealth += amount;
            HealthCheck();
        }

        public void IncreaseMaxHealth(float newAmount)
        {
            GetCurrentHealthRatio();
            MaxHealth = newAmount;
            CurrentHealth = MaxHealth * healthRatio;
            HealthCheck();
        }
        
        protected virtual void HealthCheck()
        {
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
            else if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
            }
        }
        
        private void GetCurrentHealthRatio()
        {
            healthRatio = CurrentHealth / MaxHealth;
        }
    }
}
