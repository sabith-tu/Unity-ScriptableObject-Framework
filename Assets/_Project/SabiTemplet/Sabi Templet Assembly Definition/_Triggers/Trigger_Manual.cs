using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_Manual")]
    public class Trigger_Manual : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)][SerializeField] private bool invokeOnStart = false;

        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvoke = new();


        [Button]
        [PropertySpace(10)]
        public void InvokeIt() => whatToInvoke.Invoke();

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        public void Execute() => InvokeIt();
    }
}