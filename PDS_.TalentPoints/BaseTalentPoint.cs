using PhantomDragonStudio.TalentPoints.Talent_Point_States;
using PhantomDragonStudio.UnitSystem;

namespace PhantomDragonStudio.TalentPoints
{
    [System.Serializable]
    public abstract class BaseTalentPoint : ITalentPoint
    {
        public IState CurrentState { get => currentState; private set => currentState = value; }
        public GeneralObjectInformation GeneralTalentInfo => generalObjectInformation;
        public int CurrentLevel { get => currentLevel; private set => currentLevel = value; }
        public int MaxLevel { get => maxLevel; private set => maxLevel = value; }
        public TalentPointRequirements TalentPointReqs => talentPointRequirements;
        public ITalentPointContainer Container { get; private set; }
        
        [Header("Talent Point Information")]
        [SerializeField] private TalentPointRequirements talentPointRequirements = default;
        [SerializeField] private GeneralObjectInformation generalObjectInformation = default;
        [SerializeField] private IState currentState = default;
        [SerializeField] private int currentLevel;
        [SerializeField] private int maxLevel;
        protected StateMachine StateMachine = new StateMachine();

        public TP_LockedState LockedState { get; private set; }
        public TP_UnlockedState UnlockedState  { get; private set; }
        public TP_ActiveState ActiveState { get; private set; }

        public abstract void PerformFunctionality();
        public abstract void StopFunctionality();

        protected ICharacter character;
        public void Initialize(ITalentPointContainer container, ICharacter _character)
        {
            Container = container;
            character = _character;
            LockedState = new TP_LockedState(this, talentPointRequirements);
            UnlockedState  = new TP_UnlockedState(this);
            ActiveState = new TP_ActiveState(this);
            StateMachine.ChangeState(LockedState);
        }

        public void ChangeState(IState state)
        {
            StateMachine.ChangeState(state);
            CurrentState = state;
        }

        public bool IsMaxed()
        {
            return currentLevel == maxLevel;
        }

        public void IncreaseLevel(int amount)
        {
            currentLevel += amount;
            ChangeState(ActiveState);
            if (CurrentLevel > MaxLevel)
                CurrentLevel = MaxLevel;
        }

        public void ResetCurrentLevel()
        {
            Container.AdjustPoints(-CurrentLevel);
            CurrentLevel = 0;
            ChangeState(LockedState);
        }
    }
}
