using System;
using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;

[AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO_Int")]
public class Trigger_OnInvokeActionSO_Int : SerializedMonoBehaviour
{
    [Space(10), SerializeField] private bool invokeOnStart;
    [Space(10), SerializeField] private ActionSO_Int actionSO_Int;

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private List<IntAndSabiEvent> whatToDo = new();

    private void OnEnable() => actionSO_Int.action += OnInvoke;
    private void OnDisable() => actionSO_Int.action -= OnInvoke;

    void OnInvoke(int value)
    {
        foreach (var intAndSabiEvent in whatToDo)
        {
            if (intAndSabiEvent.value == value)
            {
                intAndSabiEvent.Event.Invoke();
                return;
            }
        }
    }
}

class IntAndSabiEvent
{
    public int value;
    [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
}