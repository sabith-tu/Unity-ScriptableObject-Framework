using UnityEngine;

namespace SABI.AnimationStatemachine
{
    [CreateAssetMenu(fileName = "AnimationLayer", menuName = "SO/State/AnimationLayer")]
    public class AnimationLayerSO : ScriptableObject
    {
        public int Layer;
        public bool shouldEnable;
    }
}