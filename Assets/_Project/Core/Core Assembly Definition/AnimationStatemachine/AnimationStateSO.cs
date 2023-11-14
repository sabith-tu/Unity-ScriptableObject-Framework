using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.AnimationStatemachine
{
    [CreateAssetMenu(fileName = "AnimationState", menuName = "SO/State/AnimationState")]
    public class AnimationStateSO : ScriptableObject
    {
        public StringReference[] AnimationStateName;
        public bool isCrossFade = true;
        public bool OverrideToCanPlayAgain = false;

        public string GetAnimationStateName() => AnimationStateName[Random.Range(0, AnimationStateName.Length)].GetValue();

        [ShowIf("isCrossFade")] public float crossFadeTransition = 0.2f;
    }
}