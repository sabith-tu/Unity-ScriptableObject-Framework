using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/Vector3ValueSO")]
    public class Vector3ValueSO : SoaBaseVariable
    {
        [Space(10)] [SerializeField] private Vector3 value;
        [Space(10)] [SerializeField] private Vector3 valueToReset;

        public Vector3 GetValue() => value;

        public void SetValue(Vector3 newValue)
        {
            value = newValue;
            if (NotifyOnChange) OnValueChange?.Invoke();
        }

        public override string GetValueAsString() => value.ToString();

        public void SetResetValue(Vector3 value) => valueToReset = value;
        public override void Reset() => SetValue(valueToReset);
    }
}