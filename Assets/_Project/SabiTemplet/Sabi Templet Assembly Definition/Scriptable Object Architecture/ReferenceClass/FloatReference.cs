using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace SABI.SOA
{
    [System.Serializable]
    public class FloatReference : BaseReferenceValue
    {
        [ShowIf("@mode == AllReferenceTypesEnum.Scene_Value")]
        public FloatSceneVariable SceneVariable;

        [ShowIf("@mode == AllReferenceTypesEnum.Constant_Value")]
        public float ConstantValue;

        [PropertySpace(SpaceAfter = 10)]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public FloatValueSO SO_Variable;


        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public string NewVaraibleName;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public bool ShouldNotifyChanges;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public float DefaultValue;
        [SerializeField] private bool NotifyOnExactValeChange = true;
        [ShowIf("NotifyOnExactValeChange")] public Action<float> OnValueChangeWithValue;

        [Button]
        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public void CreateAndAssignNewSO()
        {
#if UNITY_EDITOR
            FloatValueSO valueSO = ScriptableObject.CreateInstance<FloatValueSO>();

            valueSO.name = NewVaraibleName;
            valueSO.SetNotifyOnChange(ShouldNotifyChanges);
            valueSO.SetValue(DefaultValue);

            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_FLOAT_" + valueSO.name + ".asset");

            AssetDatabase.SaveAssets();

            SO_Variable = valueSO;
#endif
        }

        public float GetValue()
        {
            switch (mode)
            {
                case AllReferenceTypesEnum.Constant_Value:
                    return ConstantValue;
                    break;
                case AllReferenceTypesEnum.SO_Value:
                    return SO_Variable.GetValue();
                    break;
                case AllReferenceTypesEnum.Scene_Value:
                    return SceneVariable.GetValue();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetValue(float newValue)
        {
            if (base.NotifyOnChange) base.ActionOnBaseVariableValueChange?.Invoke();
            if (NotifyOnExactValeChange) OnValueChangeWithValue?.Invoke(newValue);
            switch (mode)
            {
                case AllReferenceTypesEnum.Constant_Value:
                    ConstantValue = newValue;
                    break;
                case AllReferenceTypesEnum.SO_Value:
                    SO_Variable.SetValue(newValue);
                    break;
                case AllReferenceTypesEnum.Scene_Value:
                    SceneVariable.SetValue(newValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}