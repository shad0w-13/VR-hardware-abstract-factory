using System;

namespace VirtualReality
{
    abstract class HeadMountedDisplay
    {
        public abstract void Render();
    }

    class OculusRiftHMD : HeadMountedDisplay
    {
        public override void Render() => Console.WriteLine("Oculus render refresh rate: 120[Hz]");
    }

    class HTCViveHMD : HeadMountedDisplay
    {
        public override void Render() => Console.WriteLine("HTC Vive render refresh rate: 90[Hz]");
    }
}