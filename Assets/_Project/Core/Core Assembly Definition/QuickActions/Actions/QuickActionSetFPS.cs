using UnityEngine;

namespace SABI.QuickActions
{
    [CreateAssetMenu(fileName = "QuickActionSetFPS", menuName = "SO/QuickActions/SetFrameRate")]
    public class QuickActionSetFPS : QuickActionBaseSO
    {
        [SerializeField] private int frameRate = 60;

        public override void InvokeQuickAction() => Application.targetFrameRate = frameRate;
    }
}