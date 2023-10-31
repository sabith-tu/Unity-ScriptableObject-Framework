
using SABI.StaticEvent;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/FloatValueSO")]
    public class FloatValueSO : SoaBaseVariable
    {
        [Space(10)] [SerializeField] private float value;
        
        [Space(10)] [SerializeField] private bool ResetValueOnStart = true;

        [Space(10)] [ShowIf("ResetValueOnStart")] [SerializeField]
        private float valueToReset = 0;

        [Space(10)] [SerializeField] private bool ClampValue = false;

        [Space(10)] [ShowIf("ClampValue")] [SerializeField]
        private float minimumValue = 0;

        [Space(10)] [ShowIf("ClampValue")] [SerializeField]
        private float maximumValue = 100;


        private void OnEnable()
        {
            if (ResetValueOnStart) GlobalStaticEventManager.StartAction += Reset;
        }

        public float GetValue() => value;
        public void SetResetValue(float value) => valueToReset = value;
        public void SetValue(float newValue)
        {
            value = newValue;
            if (ClampValue) value = Mathf.Clamp(value, minimumValue, maximumValue);
            if (NotifyOnChange) OnValueChange?.Invoke();
        }

        public override void  Reset() => SetValue(valueToReset);

        public override string GetValueAsString() => value.ToString();

        #region AddAndSubtractValue

        public void AddFloatValueSO(FloatValueSO newValue) => AddValue(newValue.GetValue());

        public void DecreaseFloatValueSO(FloatValueSO newValue) => DecreaseValue(newValue.GetValue());

        // No clamp

        public void AddValue(float newValue) => SetValue(value + newValue);

        public void DecreaseValue(float newValue) => SetValue(value - newValue);

        // clamp 0 to 1

        public void AddValueWithClamp0to1(float newValue)
        {
            float valueToSet = value + newValue;
            valueToSet = Mathf.Clamp01(valueToSet);
            SetValue(valueToSet);
        }

        public void DecreaseValueWithClamp0to1(float newValue)
        {
            float valueToSet = value - newValue;
            valueToSet = Mathf.Clamp01(valueToSet);
            SetValue(valueToSet);
        }

        // clamp -1 to 1

        public void AddValueWithClampNegative1toPosative1(float newValue)
        {
            float valueToSet = value + newValue;
            valueToSet = Mathf.Clamp(valueToSet, -1, 1);
            SetValue(valueToSet);
        }

        public void DecreaseValueWithClampNegative1toPosative1(float newValue)
        {
            float valueToSet = value - newValue;
            valueToSet = Mathf.Clamp(valueToSet, -1, 1);
            SetValue(valueToSet);
        }

        // clamp 0 to 100

        public void AddValueWithClamp0to100(float newValue)
        {
            float valueToSet = value + newValue;
            valueToSet = Mathf.Clamp(valueToSet, 0, 100);
            SetValue(valueToSet);
        }


        public void DecreaseValueWithClamp0to100(float newValue)
        {
            float valueToSet = value - newValue;
            valueToSet = Mathf.Clamp(valueToSet, 0, 100);
            SetValue(valueToSet);
        }

        #endregion
    }
}