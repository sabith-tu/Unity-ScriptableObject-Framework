using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.AnimationStatemachine
{
    [AddComponentMenu("_SABI/SimpleStateMachine/SabiAnimationStateMachineSOs")]
    public class SabiAnimationontroller : MonoBehaviour
    {
        [Space(10)] [DisplayAsString] [SerializeField]
        private AnimationStateSO currentAnimationState = null;

        [Space(10)] [SerializeField] private Animator animator;
        
        [Space(10)] [SerializeField] protected bool allowSameStateToSetAgain = false;

        [Space(10)] [SerializeField] protected bool overRideStartingState = false;

        [ShowIf("overRideStartingState")] [Space(5)] [SerializeField]
        protected AnimationStateSO startingState;

        private void Awake()
        {
            if (animator == null) animator = GetComponent<Animator>();
        }

        private void Start()
        {
            if (overRideStartingState) SetAndRunState(startingState);
        }

        private void PlayAnimationStateCrossFade(string animationStateName) => animator.CrossFade(animationStateName, 0.2f);

        private void PlayAnimationStateCrossFade(string animationStateName, float transition) =>
            animator.CrossFade(animationStateName, transition);

        private void PlayAnimationStateJustPlay(string animationStateName) => animator.Play(animationStateName);

        public void SetAnimationLayer(AnimationLayerSO animationLayerLayer) =>
            animator.SetLayerWeight(animationLayerLayer.Layer, animationLayerLayer.shouldEnable ? 1 : 0);

        public void SetAndRunState(AnimationStateSO newState)
        {
            if (currentAnimationState == newState && !allowSameStateToSetAgain && !newState.OverrideToCanPlayAgain) return;
            SetState(newState);
            RunCurrentState();
        }

        private void SetState(AnimationStateSO newState)
        {
            if (animator.HasState(0, Animator.StringToHash(newState.GetAnimationStateName())))
            {
                currentAnimationState = newState;
            }
            else if (animator.HasState(1, Animator.StringToHash(newState.GetAnimationStateName())))
            {
                currentAnimationState = newState;
            }
            else if (animator.HasState(2, Animator.StringToHash(newState.GetAnimationStateName())))
            {
                currentAnimationState = newState;
            }
            else
            {
                Debug.LogError(
                    $"{newState.GetAnimationStateName()} is not a valid state at animator on {animator.gameObject.name} game object -SABI");
            }
        }

        public void RunCurrentState()
        {
            if (currentAnimationState.isCrossFade)
            {
                PlayAnimationStateCrossFade(currentAnimationState.GetAnimationStateName(), currentAnimationState.crossFadeTransition);
            }
            else PlayAnimationStateJustPlay(currentAnimationState.GetAnimationStateName());
        }
    }
}