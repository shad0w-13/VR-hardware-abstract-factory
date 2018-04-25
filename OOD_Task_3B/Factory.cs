using System;
using System.Collections.Generic;

namespace VirtualReality
{
    class Factory
    {
        public static VRFactory GetVRFactory(String code)
        {
            var factory = factories[code];

            return factory();
        }

        private static Dictionary<String, Func<VRFactory>> factories = new Dictionary<string, Func<VRFactory>>
        {
            {"oculus", () => new OculusRiftFactory() },
            {"vive", () => new HTCViveFactory() },
            {"mix1", () => new Mix1Factory() },
            {"mix2", () => new Mix2Factory() },
        };
    }

    abstract class VRFactory
    {
        public abstract HeadMountedDisplay MakeHMD();
        public abstract HandController MakeLeftHandController();
        public abstract HandController MakeRightHandController();
        public abstract Tracker MakeLeftFootTracker();
        public abstract Tracker MakeRightFootTracker();
    }

    class OculusRiftFactory : VRFactory
    {
        public override HeadMountedDisplay MakeHMD() => new OculusRiftHMD();
        public override Tracker MakeLeftFootTracker() => new OculusRiftTracker();
        public override HandController MakeLeftHandController() => new OculusRiftHandController(HandednessType.Left);
        public override Tracker MakeRightFootTracker() => new OculusRiftTracker();
        public override HandController MakeRightHandController() => new OculusRiftHandController(HandednessType.Right);
    }
    class HTCViveFactory : VRFactory
    {
        public override HeadMountedDisplay MakeHMD() => new HTCViveHMD();
        public override Tracker MakeLeftFootTracker() => new HTCViveTracker();
        public override HandController MakeLeftHandController() => new HTCViveHandController(HandednessType.Left);
        public override Tracker MakeRightFootTracker() => new HTCViveTracker();
        public override HandController MakeRightHandController() => new HTCViveHandController(HandednessType.Right);
    }
    class Mix1Factory : VRFactory
    {
        public override HeadMountedDisplay MakeHMD() => new OculusRiftHMD();
        public override Tracker MakeLeftFootTracker() => new OculusRiftTracker();
        public override Tracker MakeRightFootTracker() => new OculusRiftTracker();
        public override HandController MakeLeftHandController() => new HTCViveHandController(HandednessType.Left);
        public override HandController MakeRightHandController() => new HTCViveHandController(HandednessType.Right);
    }
    class Mix2Factory : VRFactory
    {
        public override HeadMountedDisplay MakeHMD() => new HTCViveHMD();
        public override Tracker MakeLeftFootTracker() => new HTCViveTracker();
        public override Tracker MakeRightFootTracker() => new HTCViveTracker();
        public override HandController MakeLeftHandController() => new HTCViveHandController(HandednessType.Left);
        public override HandController MakeRightHandController() => new OculusRiftHandController(HandednessType.Right);
    }
}