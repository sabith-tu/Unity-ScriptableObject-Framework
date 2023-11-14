using System;

namespace SABI.StaticEvent
{
    public static class GlobalStaticEventManager
    {
        public static Action StartAction;

        public static void InvokeStartAction() => StartAction?.Invoke();
    }
}