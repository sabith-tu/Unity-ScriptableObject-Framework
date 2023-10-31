using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnGameStart")]
    public class Trigger_OnGameStart : SerializedMonoBehaviour
    {
        [Space(10)][SerializeField] private bool isActive = true;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        private bool shouldInvokeOnAwake = false;

        [Space(10)]
        [ShowIf("shouldInvokeOnAwake")]
        [EnableIf("isActive")]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvokeOnAwake = new();


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        private bool shouldInvokeOnStart = false;

        [Space(10)]
        [ShowIf("shouldInvokeOnStart")]
        [EnableIf("isActive")]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvokeOnStart = new();


        private void Awake()
        {
            if (isActive && shouldInvokeOnAwake)
            {
                whatToInvokeOnAwake.Invoke();

            }
        }

        private void Start()
        {
            if (isActive && shouldInvokeOnStart)
            {
                whatToInvokeOnStart.Invoke();
            }
        }
    }
}