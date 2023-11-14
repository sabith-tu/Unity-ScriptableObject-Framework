using System;
using SABI.StaticEvent;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace SABI.SOA
{
    [CreateAssetMenu(menuName = "SO/Base/IntValueSO")]
    public class IntValueSO : SoaBaseVariable
    {
        [Space(10)][SerializeField] private int value;

        [Space(10)][SerializeField] private bool ResetValueOnStart = true;

        [Space(10)]
        [ShowIf("ResetValueOnStart")]
        [SerializeField]
        private int valueToReset = 0;

        [Space(10)][SerializeField] private bool ClampValue = false;

        [Space(10)]
        [ShowIf("ClampValue")]
        [SerializeField]
        private int minimumValue = 0;

        [Space(10)]
        [ShowIf("ClampValue")]
        [SerializeField]
        private int maximumValue = 100;

        [SerializeField] public bool NotifyOnExactValeChange = true;
        [ShowIf("NotifyOnExactValeChange")] public Action<int> ActionOnSoVariableExactValueChange;

        public void SetResetValue(int value) => valueToReset = value;


        private void OnEnable()
        {
            if (ResetValueOnStart) GlobalStaticEventManager.StartAction += Reset;
        }

        public int GetValue() => value;

        public void SetValue(int newValue)
        {
            value = newValue;
            if (ClampValue) value = Mathf.Clamp(value, minimumValue, maximumValue);
            if (NotifyOnChange) OnValueChange?.Invoke();
            if (NotifyOnExactValeChange)
            {
                Debug.Log("Helth update from so variable , is null: " + (ActionOnSoVariableExactValueChange == null).ToString());
                ActionOnSoVariableExactValueChange?.Invoke(newValue);
            }
        }

        public override void Reset() => SetValue(valueToReset);

        public void AddIntValueSO(IntValueSO newValue) => AddValue(newValue.GetValue());

        public void DecreasIntValueSO(IntValueSO newValue) => DecreaseValue(newValue.GetValue());

        public override string GetValueAsString() => value.ToString();


        #region AddAndSubtractValue

        // No clamp

        public void AddValue(int newValue) => SetValue(value + newValue);

        public void DecreaseValue(int newValue) => SetValue(value - newValue);


        // clamp -1 to 1

        public void AddValueWithClampNegative1toPosative1(int newValue)
        {
            int valueToSet = value + newValue;
            valueToSet = Mathf.Clamp(valueToSet, -1, 1);
            SetValue(valueToSet);
        }

        public void DecreaseValueWithClampNegative1toPosative1(int newValue)
        {
            int valueToSet = value - newValue;
            valueToSet = Mathf.Clamp(valueToSet, -1, 1);
            SetValue(valueToSet);
        }

        // clamp 0 to 100

        public void AddValueWithClamp0to100(int newValue)
        {
            int valueToSet = value + newValue;
            valueToSet = Mathf.Clamp(valueToSet, 0, 100);
            SetValue(valueToSet);
        }


        public void DecreaseValueWithClamp0to100(int newValue)
        {
            int valueToSet = value - newValue;
            valueToSet = Mathf.Clamp(valueToSet, 0, 100);
            SetValue(valueToSet);
        }

        #endregion
    }
}