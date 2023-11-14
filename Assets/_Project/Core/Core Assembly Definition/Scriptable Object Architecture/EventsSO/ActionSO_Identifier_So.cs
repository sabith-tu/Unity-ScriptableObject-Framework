using System;
using SABI.SOA.SimpleStatemachine;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Event/Action_UniqueIdentifier")]
    public class ActionSO_UniqueIdentifier : ScriptableObject
    {
        public Action<UniqueIdentifier> action;

        public void InvokeAction(UniqueIdentifier value) => action?.Invoke(value);
    }
}