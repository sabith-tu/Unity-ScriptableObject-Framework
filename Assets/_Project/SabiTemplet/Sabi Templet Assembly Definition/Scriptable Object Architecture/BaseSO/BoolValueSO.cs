using System;
using UnityEngine;


namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/boolValueSO")]
    public class BoolValueSO : SoaBaseVariable
    {
        [Space(10)] [SerializeField] private bool value;
        [Space(10)] [SerializeField] private bool valueToReset = false;
        
        public bool GetValue() => value;

        public void SetValue(bool newValue)
        {
            value = newValue;
            if (NotifyOnChange) OnValueChange?.Invoke();
        }

        public override string GetValueAsString() => value.ToString();
        
        public override void Reset() => SetValue(valueToReset);
        public void SetResetValue(bool value) => valueToReset = value;
    }
}