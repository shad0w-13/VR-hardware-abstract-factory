using System;

namespace VirtualReality
{
    enum HandednessType
    {
        Left, Right
    }

    abstract class HandController
    {
        protected HandednessType Handedness;

        public HandController(HandednessType Handedness)
        {
            this.Handedness = Handedness;
        }

        abstract public void Grab();
        abstract public bool IsHeld();
        abstract public void Vibrate();
    }

    class OculusRiftHandController : HandController
    {
        public OculusRiftHandController(HandednessType Handedness) : base(Handedness) {}

        public override void Grab() => Console.WriteLine("{0} Oculus Touch grabbing object", Handedness.ToString());

        public override bool IsHeld()
        {
            Random random = new Random();
            bool isHeld = random.Next(0, 2) == 1;
            if (isHeld)
                Console.WriteLine("{0} Oculus Touch is held", Handedness.ToString());
            else
                Console.WriteLine("{0} Oculus Touch is not held", Handedness.ToString());

            return isHeld;
        }

        public override void Vibrate()
        {
            Random random = new Random();
            int duration = random.Next(1, 6);
            Console.WriteLine("{0} Oculus Touch vibrating for {1}[s]", Handedness.ToString(), duration);
        }
    }

    class HTCViveHandController : HandController
    {
        public HTCViveHandController(HandednessType Handedness) : base(Handedness) {}

        public override void Grab() => Console.WriteLine("{0} HTC Vive grabbing object", Handedness.ToString());

        public override bool IsHeld() => throw new NotImplementedException();

        public override void Vibrate()
        {
            Random random = new Random();
            int duration = random.Next(2, 4);
            Console.WriteLine("{0} HTC Vive vibrating for {1}[s]", Handedness.ToString(), duration);
        }
    }
}