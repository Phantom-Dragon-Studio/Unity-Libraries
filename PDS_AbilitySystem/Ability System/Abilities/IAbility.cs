namespace PhantomDragonStudio.AbilitySystem
{
    public interface IAbility 
    {
        AbilityInfo AbilityInformation { get; }
        AbilityController Caster { get; }

        void Initialize(AbilityController abilityController);
        void IncreaseLevel(int levelsToIncrease);
        void Cast();
        void EngageCooldown();
        void ResetCooldown();
    }
}