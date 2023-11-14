using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO")]
    public class Trigger_OnInvokeActionSO : SerializedMonoBehaviour
    {
        [Space(10)][SerializeField] private bool isActive = true;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        List<ActionReference> actions;

        [Space(10)]
        [EnableIf("isActive")]
        [SerializeField]
        [HideReferenceObjectPicker] private SabiEventAdvanced whatToInvoke = new();



        private void OnEnable()
        {
            foreach (var VARIABLE in actions)
            {
                VARIABLE.SetAction(VARIABLE.GetAction() + InvokeIt);
            }
        }

        private void OnDisable()
        {
            foreach (var VARIABLE in actions)
            {
                VARIABLE.SetAction(VARIABLE.GetAction() - InvokeIt);
            }
        }

        [Button]
        [PropertySpace(10)]
        private void InvokeIt()
        {
            if (isActive) whatToInvoke.Invoke();
        }


    }
}