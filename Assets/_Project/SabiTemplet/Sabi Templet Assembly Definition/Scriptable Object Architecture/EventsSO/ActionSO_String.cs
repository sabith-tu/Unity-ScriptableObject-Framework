using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action_String")]
    public class ActionSO_String : ScriptableObject
    {
        public Action<string> action;

        public void InvokeAction(string value) => action?.Invoke(value);
    }
}