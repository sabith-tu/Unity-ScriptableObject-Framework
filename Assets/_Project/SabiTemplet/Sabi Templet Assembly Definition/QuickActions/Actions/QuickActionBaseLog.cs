using SABI.SOA;
using UnityEngine;

namespace SABI.QuickActions
{
    [CreateAssetMenu(fileName = "QuickActionLog", menuName = "SO/QuickActions/Log")]
    public class QuickActionBaseLog : QuickActionBaseSO
    {
        [SerializeField] private StringReference message;

        public override void InvokeQuickAction() => Debug.Log(message.GetValue());
    }
}