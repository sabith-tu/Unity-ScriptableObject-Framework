using System;
using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;

[AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO_Float")]
public class Trigger_OnInvokeActionSO_Float : SerializedMonoBehaviour
{
    [Space(10), SerializeField] private bool invokeOnStart;
    [Space(10), SerializeField] private ActionSO_Float actionSO_Float;

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private List<FloatAndSabiEvent> whatToDo = new();

    private void OnEnable() => actionSO_Float.action += OnInvoke;
    private void OnDisable() => actionSO_Float.action -= OnInvoke;

    void OnInvoke(float value)
    {
        foreach (var floatAndSabiEvent in whatToDo)
        {
            if (floatAndSabiEvent.value == value)
            {
                floatAndSabiEvent.Event.Invoke();
                return;
            }
        }
    }
}

class FloatAndSabiEvent
{
    public float value;
    [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
}