using PhantomDragonStudio.Core.Utilities;

namespace PhantomDragonStudio.Core
{
    public static class OutputHandler
    {
        private static readonly IOutput _output;
        public static void Say(string message) => _output.Say(message);
        public static void SayWarning(string message) => _output.SayWarning(message);
    }
}