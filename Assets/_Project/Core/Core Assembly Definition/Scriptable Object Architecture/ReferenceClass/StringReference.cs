using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;


namespace SABI.SOA
{
    [System.Serializable]
    public class StringReference : BaseReferenceValue
    {
        [ShowIf("@mode == AllReferenceTypesEnum.Scene_Value")]
        public StringSceneVariable SceneVariable;

        [ShowIf("@mode == AllReferenceTypesEnum.Constant_Value")]
        public string ConstantValue;

        [PropertySpace(SpaceAfter = 10)]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public StringValueSO SO_Variable;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public string NewVaraibleName;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public bool ShouldNotifyChanges;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        [FoldoutGroup("Create")]
        public string DefaultValue;
        [SerializeField] private bool NotifyOnExactValeChange = true;
        [ShowIf("NotifyOnExactValeChange")] public Action<String> OnValueChangeWithValue;

        [Button]
        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public void CreateAndAssignNewSO()
        {
#if UNITY_EDITOR
            StringValueSO valueSO = ScriptableObject.CreateInstance<StringValueSO>();

            valueSO.name = NewVaraibleName;
            valueSO.SetNotifyOnChange(ShouldNotifyChanges);
            valueSO.SetValue(DefaultValue);

            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_STRING_" + valueSO.name + ".asset");

            AssetDatabase.SaveAssets();

            SO_Variable = valueSO;
#endif
        }

        public string GetValue()
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

        public void SetValue(string newValue)
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