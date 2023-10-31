using System;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/StringValueSO")]
    public class StringValueSO : SoaBaseVariable
    {
        [Space(10)] [SerializeField] private string value;
        [Space(10)] [SerializeField] private string valueToReset;

        public string GetValue() => value;

        public void SetValue(string newValue)
        {
            value = newValue;
            if (NotifyOnChange) OnValueChange?.Invoke();
        }

        public override string GetValueAsString() => value.ToString();

        public void SetResetValue(string value) => valueToReset = value;
        public override void Reset() => SetValue(valueToReset);
    }
}