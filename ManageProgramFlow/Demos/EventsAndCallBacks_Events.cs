using ManageProgramFlow.Concretes;
using System;

namespace ManageProgramFlow.Demos
{
    class EventsAndCallBacks_Events
    {
        internal static void CreateAndRaise()
        {
            Pub p = new Pub();

            p.OnChange += (sender, e)=> Console.WriteLine($"Event raised: {e.Value}");
            p.Raise();
        }
    }
}
