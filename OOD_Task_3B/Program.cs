using System;
using System.Collections.Generic;

namespace VirtualReality
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var code = Console.ReadLine();

                // Your implementation
                try
                {
                    VRFactory factory = Factory.GetVRFactory(code);
                    VRPlayer player = BuildVRPlayer(factory.MakeHMD(), factory.MakeLeftHandController(),
                        factory.MakeRightHandController(), factory.MakeLeftFootTracker(), factory.MakeRightFootTracker());
                    TestVRPlayer(player);
                }
                catch (KeyNotFoundException)
                {
                    if (code == "exit")
                        return;
                    Console.WriteLine("Configuration not found");
                }
            }
        }

        static VRPlayer BuildVRPlayer(HeadMountedDisplay HMD, 
            HandController LeftHandController, HandController RightHandController, 
            Tracker LeftFootTracker, Tracker RightFootTracker)
        {
            return new VRPlayer(HMD, 
                LeftHandController, RightHandController, 
                LeftFootTracker, RightFootTracker);
        }

        static void TestVRPlayer(VRPlayer VRPlayer)
        {
            VRPlayer.HMD.Render();

            VRPlayer.LeftHandController.Grab();
            VRPlayer.RightHandController.Grab();

            try
            {
                VRPlayer.LeftHandController.IsHeld();
                VRPlayer.RightHandController.IsHeld();
            }
            catch(NotImplementedException)
            {
                Console.WriteLine("IsHeld() not implemented");
            }
            VRPlayer.LeftHandController.Vibrate();
            VRPlayer.RightHandController.Vibrate();

            try
            {
                VRPlayer.LeftFootTracker.StartTracking();
                VRPlayer.RightFootTracker.StartTracking();
            }
            catch(NotImplementedException)
            {
                Console.WriteLine("StartTracking() not implemented");
            }
        }
    }
}