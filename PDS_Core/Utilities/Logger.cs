namespace PhantomDragonStudio.Core.Utilities
{
    public static class Logger
    {
        private static readonly IOutput _output;
        public static void Say(string message) => _output.Say(message);
        public static void SayWarning(string message) => _output.SayWarning(message);
    }
}