namespace PhantomDragonStudio.TalentPoints
{
    public interface ITalentPointRequirements
    {
        bool Validate(ITalentPoint _owner);
    }
}