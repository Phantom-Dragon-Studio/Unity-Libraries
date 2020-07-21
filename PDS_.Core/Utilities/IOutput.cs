namespace PhantomDragonStudio.Core.Utilities
{
    public interface IOutput
    {
        void Say(string message);
        void SayWarning(string message);
    }
}