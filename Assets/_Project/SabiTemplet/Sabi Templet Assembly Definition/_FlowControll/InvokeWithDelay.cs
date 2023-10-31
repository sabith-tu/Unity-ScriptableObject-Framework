using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/FlowControl/InvokeWithDelay")]
    public class InvokeWithDelay : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)][SerializeField] private bool isActive = true;
        [Space(10)][SerializeField] private bool invokeOnStart = false;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        private float delay;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvoke = new();


        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            if (isActive) Invoke(nameof(InvokeEvent), delay);
        }

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        void InvokeEvent() => whatToInvoke.Invoke();

        public void Execute() => InvokeIt();
    }
}