using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Action/_Comparison/Action_ComparisonOnBool")]
    public class Action_ComparisonOnBool : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)] [SerializeField] private BoolReference[] boolValues;
        [Space(10)] [SerializeField] bool debugLog = false;
        [Space(10)] [SerializeField] UnityEvent onTheyAreSame;
        [Space(10)] [SerializeField] IExecutable onTheyAreSameExecutable;

        [PropertySpace(SpaceAfter = 10)] [SerializeField]
        UnityEvent onTheyAreDifferent;

        [PropertySpace(SpaceAfter = 10)] [SerializeField]
        IExecutable onTheyAreDifferentExecutable;

        [Button]
        public void RunComparison()
        {
            if (boolValues.Length <= 1)
            {
                Debug.LogError("Need more than 1 value to compare on gameObject " + gameObject.name);
                return;
            }

            if (IsAllValuesSame()) SameValue();
            else NotSameValue();
        }


        bool IsAllValuesSame()
        {
            bool firstValue = boolValues[0].GetValue();

            foreach (var VARIABLE in boolValues)
            {
                if (VARIABLE.GetValue() != firstValue)
                {
                    Debug.Log("missmatch found");
                    return false;
                }
            }

            Debug.Log("no missmatch found");
            return true;
        }

        void SameValue()
        {
            onTheyAreSame.Invoke();
            if(onTheyAreSameExecutable != null) onTheyAreSameExecutable.Execute();
            if (debugLog) Debug.Log("They are same");
        }

        void NotSameValue()
        {
            onTheyAreDifferent.Invoke();
            if(onTheyAreDifferentExecutable != null) onTheyAreDifferentExecutable.Execute();
            if (debugLog) Debug.Log("They are diffrent");
        }

        public void Execute()
        {
            RunComparison();
        }
    }
}