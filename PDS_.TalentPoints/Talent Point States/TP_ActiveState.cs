namespace PhantomDragonStudio.TalentPoints.Talent_Point_States
{
    public class TP_ActiveState : IState
    {
        private readonly ITalentPoint owner;

        public TP_ActiveState(ITalentPoint owner)
        {
            this.owner = owner;
        }

        public void Enter()
        {
            //Debug.Log(owner.GeneralTalentInfo.Name + " is active! Level: " + owner.CurrentLevel);
            Execute();
            //TODO Greyscale image?
        }

        public void Execute()
        {
            owner.PerformFunctionality();
        }

        public void Exit()
        {
            //Debug.Log("Exiting!");
            owner.StopFunctionality();
        }
    }
}