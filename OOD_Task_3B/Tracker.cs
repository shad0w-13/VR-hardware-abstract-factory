using System;

namespace VirtualReality
{
    abstract class Tracker
    {
        public abstract void StartTracking();
    }

    class OculusRiftTracker : Tracker
    {
        public override void StartTracking() => throw new NotImplementedException();
    }

    class HTCViveTracker : Tracker
    {
        public override void StartTracking() => Console.WriteLine("HTC Vive Tracker start tracking");
    }
}