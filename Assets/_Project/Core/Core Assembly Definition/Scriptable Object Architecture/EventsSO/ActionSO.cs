using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action")]
    public class ActionSO : ScriptableObject
    {
        public Action action;

        public void InvokeAction() => action?.Invoke();
    }
}