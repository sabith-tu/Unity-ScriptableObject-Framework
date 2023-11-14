using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action_Int")]
    public class ActionSO_Int : ScriptableObject
    {
        public Action<int> action;

        public void InvokeAction(int value) => action?.Invoke(value);
    }
}