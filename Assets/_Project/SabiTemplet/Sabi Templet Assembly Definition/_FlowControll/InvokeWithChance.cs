using SABI.Helper;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/FlowControl/InvokeWithChance")]
    public class InvokeWithChance : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)][SerializeField] private bool invokeOnStart = false;

        [Space(10)]
        [SerializeField]
        [Range(0.01f, 1f)]
        private float chance = 0.5f;

        [Space(10)][SerializeField][HideReferenceObjectPicker] private SabiEventAdvanced whatToInvoke = new();

        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            if (Chance.GetRandomChance(chance)) whatToInvoke.Invoke();
        }

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        public void Execute() => InvokeIt();
    }
}