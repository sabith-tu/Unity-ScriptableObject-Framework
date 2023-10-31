using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace SABI.SOA
{
    [System.Serializable]
    public class BoolReference : BaseReferenceValue
    {
        [ShowIf("@mode == AllReferenceTypesEnum.Scene_Value")] public BoolSceneVariable SceneVariable;

        [ShowIf("@mode == AllReferenceTypesEnum.Constant_Value")]
        public bool ConstantValue;

        [PropertySpace(SpaceAfter = 10)]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public BoolValueSO SO_Variable;

        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public string NewVaraibleName;

        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public bool ShouldNotifyChanges;

        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public bool DefaultValue;

        [SerializeField] private bool NotifyOnExactValeChange = true;
        [ShowIf("NotifyOnExactValeChange")] public Action<bool> OnValueChangeWithValue;

        [Button]
        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public void CreateAndAssignNewSO()
        {
#if UNITY_EDITOR
            BoolValueSO valueSO = ScriptableObject.CreateInstance<BoolValueSO>();

            valueSO.name = NewVaraibleName;
            valueSO.SetNotifyOnChange(ShouldNotifyChanges);
            valueSO.SetValue(DefaultValue);

            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_BOOL_" + valueSO.name + ".asset");

            AssetDatabase.SaveAssets();

            SO_Variable = valueSO;
#endif
        }

        public bool GetValue()
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

        public void SetValue(bool newValue)
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