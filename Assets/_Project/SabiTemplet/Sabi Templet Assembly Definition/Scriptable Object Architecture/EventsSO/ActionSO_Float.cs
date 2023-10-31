using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action_Float")]
    public class ActionSO_Float : ScriptableObject
    {
        public Action<float> action;

        public void InvokeAction(float value) => action?.Invoke(value);
    }
}