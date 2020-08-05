namespace PhantomDragonStudio.Ability_System
{
    public class AbilityController
    {
        public BaseAbility[] currentAbilities = default;
        public IAbilityHandler AbilityHandler { get; private set; }

        public void Awake()
        {
            AbilityHandler = AbilityHandlerFactory.Create(currentAbilities, this);
        }
    }
}
