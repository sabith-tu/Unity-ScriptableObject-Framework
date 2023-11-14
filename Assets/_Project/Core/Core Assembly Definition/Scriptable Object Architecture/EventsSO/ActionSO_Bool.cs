using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action_Bool")]
    public class ActionSO_Bool : ScriptableObject
    {
        public Action<bool> action;

        public void InvokeAction(bool value) => action?.Invoke(value);
    }
}