namespace PhantomDragonStudio.AbilitySystem
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
