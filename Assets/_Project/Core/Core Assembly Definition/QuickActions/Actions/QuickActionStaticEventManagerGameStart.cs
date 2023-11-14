
using SABI.StaticEvent;
using UnityEngine;

namespace SABI.QuickActions
{
    [CreateAssetMenu(fileName = "QuickActionStaticEventManagerGameStart",
        menuName = "SO/QuickActions/StaticEventManagerGameStart")]
    public class QuickActionStaticEventManagerGameStart : QuickActionBaseSO
    {
        public override void InvokeQuickAction() => GlobalStaticEventManager.InvokeStartAction();
    }
}