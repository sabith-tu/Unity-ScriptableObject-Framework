using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnDestroy")]
    public class Trigger_OnDestroy : SerializedMonoBehaviour
    {
        [Space(10)][SerializeField] private bool isActive = true;

        [Space(10)]
        [ShowIf("isActive")]
        [SerializeField]
        [HideReferenceObjectPicker] private SabiEventAdvanced whatToInvokeOnDestroy = new();


        private void OnDestroy()
        {
            if (isActive) whatToInvokeOnDestroy.Invoke();
        }
    }
}