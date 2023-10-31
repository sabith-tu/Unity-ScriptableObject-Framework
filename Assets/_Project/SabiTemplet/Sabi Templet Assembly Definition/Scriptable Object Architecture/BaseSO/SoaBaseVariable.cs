using System;
using UnityEngine;

public abstract class SoaBaseVariable : ScriptableObject, IResettable
{
    [Space(10)] [SerializeField] protected bool NotifyOnChange = true;

    public void SetNotifyOnChange(bool value) => NotifyOnChange = value;

    public Action OnValueChange;

    public abstract string GetValueAsString();
    public abstract void Reset();
}