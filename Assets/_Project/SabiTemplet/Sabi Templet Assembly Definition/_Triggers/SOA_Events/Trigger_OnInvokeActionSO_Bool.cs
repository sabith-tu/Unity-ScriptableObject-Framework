using System;
using System.Collections;
using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;

[AddComponentMenu("_SABI/Trigger/_OnInvokeActionSO/Trigger_OnInvokeActionSO_Bool")]
public class Trigger_OnInvokeActionSO_Bool : SerializedMonoBehaviour
{
    [Space(10), SerializeField] private bool invokeOnStart;
    [Space(10), SerializeField] private ActionSO_Bool actionSO_Bool;

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private SabiEventAdvanced OnValueIsTrue = new();

    [Space(10), SerializeField]
    [HideReferenceObjectPicker]
    private SabiEventAdvanced OnValueIsFalse = new();

    private void OnEnable() => actionSO_Bool.action += OnInvoke;
    private void OnDisable() => actionSO_Bool.action -= OnInvoke;

    void OnInvoke(bool value)
    {
        if (value) OnValueIsTrue.Invoke();
        else OnValueIsFalse.Invoke();
    }
}