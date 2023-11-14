using System;
using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using SABI.SOA.SimpleStatemachine;
using Sirenix.OdinInspector;
using UnityEngine;

[AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO_UniqueIdentifier")]
public class Trigger_OnInvokeActionSO_UniqueIdentifier : SerializedMonoBehaviour
{
    [Space(10), SerializeField] private bool invokeOnStart;
    [Space(10), SerializeField] private ActionSO_UniqueIdentifier actionSO_UniqueIdentifier;

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private List<UniqueIdentifierAndSabiEvent> whatToDo = new();

    private void OnEnable() => actionSO_UniqueIdentifier.action += OnInvoke;
    private void OnDisable() => actionSO_UniqueIdentifier.action -= OnInvoke;

    void OnInvoke(UniqueIdentifier value)
    {
        foreach (var uniqueIdentifierAndSabiEvent in whatToDo)
        {
            if (uniqueIdentifierAndSabiEvent.value == value)
            {
                uniqueIdentifierAndSabiEvent.Event.Invoke();
                return;
            }
        }
    }
}

class UniqueIdentifierAndSabiEvent
{
    public UniqueIdentifier value;
    [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
}