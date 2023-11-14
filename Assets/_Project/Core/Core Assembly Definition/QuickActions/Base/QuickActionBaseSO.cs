using UnityEngine;

namespace SABI.QuickActions
{
    public abstract class QuickActionBaseSO : ScriptableObject , IExecutable
    {
        public abstract void InvokeQuickAction();
        public void Execute()
        {
            InvokeQuickAction();
        }
    }
}