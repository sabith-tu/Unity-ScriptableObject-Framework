using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/Vector2ValueSO")]
    public class Vector2ValueSO : SoaBaseVariable
    {
        [Space(10)] [SerializeField] private Vector2 value;
        [Space(10)] [SerializeField] private Vector2 valueToReset;

        public Vector3 GetValue() => value;

        public void SetValue(Vector2 newValue)
        {
            value = newValue;
            if (NotifyOnChange) OnValueChange?.Invoke();
        }

        public override string GetValueAsString() => value.ToString();

        public void SetResetValue(Vector2 value) => valueToReset = value;
        public override void Reset() => SetValue(valueToReset);
    }
}