using PhantomDragonStudio.Core.Utilities;
using Debug = UnityEngine.Debug;

namespace App
{
    public class UnityConsole : IOutput
    {
        public void Say(string message) => Debug.Log(message);
    }
}