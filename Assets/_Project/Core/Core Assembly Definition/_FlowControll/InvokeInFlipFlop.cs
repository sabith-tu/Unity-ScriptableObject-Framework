using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/FlowControl/InvokeInFlipFlop")]
    public class InvokeInFlipFlop : SerializedMonoBehaviour, IExecutable
    {
        [DisplayAsString][SerializeField] private bool isOnFirstState = true;
        [Space(10)][SerializeField][HideReferenceObjectPicker] private SabiEventAdvanced stateA = new();
        [Space(10)][SerializeField][HideReferenceObjectPicker] private SabiEventAdvanced stateB = new();


        public void InvokeIt()
        {
            if (isOnFirstState)
            {
                stateA.Invoke();
                isOnFirstState = false;
            }
            else
            {
                stateB.Invoke();
                isOnFirstState = true;
            }
        }

        public void Execute() => InvokeIt();
    }
}