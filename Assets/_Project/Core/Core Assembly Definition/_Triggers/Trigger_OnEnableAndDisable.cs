using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnEnableAndDisable")]
    public class Trigger_OnEnableAndDisable : SerializedMonoBehaviour
    {
        [Space(10)][SerializeField] private bool isActive = true;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        private bool shouldInvokeOnEnable = false;

        [Space(10)]
        [ShowIf("shouldInvokeOnEnable")]
        [EnableIf("shouldInvokeOnEnable")]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvokeOnEnable = new();


        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        private bool shouldInvokeOnDisable = false;

        [Space(10)]
        [ShowIf("shouldInvokeOnDisable")]
        [EnableIf("shouldInvokeOnDisable")]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced whatToInvokeOnDisable = new();


        private void OnEnable()
        {
            if (isActive && shouldInvokeOnEnable)
            {
                whatToInvokeOnEnable.Invoke();
            }
        }

        private void OnDisable()
        {
            if (isActive && shouldInvokeOnDisable)
            {
                whatToInvokeOnDisable.Invoke();
            }
        }
    }
}