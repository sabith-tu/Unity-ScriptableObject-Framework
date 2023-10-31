using System;
using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;

[AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO_String")]
public class Trigger_OnInvokeActionSO_String : SerializedMonoBehaviour
{
    [Space(10), SerializeField] private bool invokeOnStart;
    [Space(10), SerializeField] private ActionSO_String actionSO_String;

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private List<StringAndSabiEvent> whatToDo = new();

    private void OnEnable() => actionSO_String.action += OnInvoke;
    private void OnDisable() => actionSO_String.action -= OnInvoke;

    void OnInvoke(string value)
    {
        foreach (var StringAndSabiEvent in whatToDo)
        {
            if (StringAndSabiEvent.value == value)
            {
                StringAndSabiEvent.Event.Invoke();
                return;
            }
        }
    }
}

class StringAndSabiEvent
{
    public string value;
    [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
}