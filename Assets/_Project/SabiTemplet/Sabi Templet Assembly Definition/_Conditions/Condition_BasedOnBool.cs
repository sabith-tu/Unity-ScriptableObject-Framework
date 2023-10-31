using System;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Condition/Condition_BasedOnBool")]
    public class Condition_BasedOnBool : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)][SerializeField] private BoolReference condition;

        [Space(10)][SerializeField] private bool invokeAutomatically = true;

        [Space(10)][SerializeField] private bool invokeOnStart = false;
        [Space(10)][SerializeField] private UnityEvent whatToInvokeOnTrue;
        [Space(10)][SerializeField] private IExecutable whatToExecuteOnTrue;
        [Space(10)][SerializeField] private UnityEvent whatToInvokeOnFalse;
        [Space(10)][SerializeField] private IExecutable whatToExecuteOnFalse;

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        private void OnEnable()
        {
            if (invokeAutomatically) condition.ActionOnBaseVariableValueChange += InvokeIt;
        }

        private void OnDisable()
        {
            if (invokeAutomatically) condition.ActionOnBaseVariableValueChange -= InvokeIt;
        }

        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            if (condition.GetValue())
            {
                whatToInvokeOnTrue.Invoke();
                if (whatToExecuteOnTrue != null) whatToExecuteOnTrue.Execute();
            }
            else
            {
                whatToInvokeOnFalse.Invoke();
                if (whatToExecuteOnFalse != null) whatToExecuteOnFalse.Execute();
            }
        }

        public void Execute() => InvokeIt();
    }
}