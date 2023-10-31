using SABI.AnimationStatemachine;
using SABI.SaveSystemSO;
using SABI.SOA.SimpleStatemachine;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using SABI.SOA;

public class ScriptableObjectCustomWindow : OdinMenuEditorWindow
{
    public CreateNewIntValueSO createNewIntSO;
    public CreateNewFloatValueSO createNewFloatValueSO;
    public CreateNewBoolValueSO createNewBoolValueSO;
    public CreateNewStringValueSO createNewStringValueSO;

    public CreateNewActionValueSO createNewActionValueSO;
    public CreateNewUniqueIdentifier createNewUniqueIdentifier;

    public CreateNewAnimationStateValueSO createNewAnimationStateValueSO;


    [MenuItem("SABI/ScriptableObjectCustomWindow")]
    private static void OpenWindow()
    {
        GetWindow<ScriptableObjectCustomWindow>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        createNewIntSO = new CreateNewIntValueSO();
        tree.Add("CREATE BASE SO/INT", createNewIntSO);

        createNewFloatValueSO = new CreateNewFloatValueSO();
        tree.Add("CREATE BASE SO/FLOAT", createNewFloatValueSO);

        createNewBoolValueSO = new CreateNewBoolValueSO();
        tree.Add("CREATE BASE SO/BOOL", createNewBoolValueSO);

        createNewStringValueSO = new CreateNewStringValueSO();
        tree.Add("CREATE BASE SO/STRING", createNewStringValueSO);

        createNewActionValueSO = new CreateNewActionValueSO();
        tree.Add("CREATE EVENT SO/ACTION", createNewActionValueSO);

        createNewUniqueIdentifier = new CreateNewUniqueIdentifier();
        tree.Add("CREATE STATE SO/SIMPLE STATE", createNewUniqueIdentifier);

        createNewAnimationStateValueSO = new CreateNewAnimationStateValueSO();
        tree.Add("CREATE STATE SO/ANIMATION STATE", createNewAnimationStateValueSO);


        tree.AddAllAssetsAtPath("_View All SOA Variables ", "Assets/_Project", typeof(SoaBaseVariable), true);

        //tree.AddAllAssetsAtPath("Int SO", "Assets", typeof(IntValueSO), true);
        //tree.AddAllAssetsAtPath("Float SO", "Assets", typeof(FloatValueSO), true);
        //tree.AddAllAssetsAtPath("Bool SO", "Assets", typeof(BoolValueSO), true);
        //tree.AddAllAssetsAtPath("String SO", "Assets", typeof(StringValueSO), true);
        //tree.AddAllAssetsAtPath("_View / SOA States ", "Assets", typeof(SimpleStateSO), true);
        //tree.AddAllAssetsAtPath("Animation State SO ", "Assets", typeof(AnimationStateSO), true);
        //tree.AddAllAssetsAtPath("_View / SOA Animation / Layer ", "Assets", typeof(AnimationLayerSO), true);
        //tree.AddAllAssetsAtPath("_View / SOA SaveSystem ", "Assets", typeof(SaveSystemSO), true);


        return tree;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        if (createNewIntSO != null) DestroyImmediate(createNewIntSO.valueSO);
        if (createNewFloatValueSO != null) DestroyImmediate(createNewFloatValueSO.valueSO);
        if (createNewBoolValueSO != null) DestroyImmediate(createNewBoolValueSO.valueSO);
        if (createNewStringValueSO != null) DestroyImmediate(createNewStringValueSO.valueSO);
        if (createNewActionValueSO != null) DestroyImmediate(createNewActionValueSO.valueSO);
        if (createNewUniqueIdentifier != null) DestroyImmediate(createNewUniqueIdentifier.valueSO);
        if (createNewAnimationStateValueSO != null) DestroyImmediate(createNewAnimationStateValueSO.valueSO);
    }


    public class CreateNewIntValueSO
    {
        [Space(25)] public string IntName;
        [Space(20)] public bool NotifyOnValueChange = false;
        [Space(10)] public int Value;
        [Space(10)] public int ResetValue;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public IntValueSO valueSO;

        public CreateNewIntValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<IntValueSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_INT_" + IntName + ".asset");

            valueSO.SetValue(Value);
            valueSO.SetResetValue(ResetValue);
            valueSO.SetNotifyOnChange(NotifyOnValueChange);

            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<IntValueSO>();
        }
    }

    public class CreateNewFloatValueSO
    {
        [Space(25)] public string FloatName;

        [Space(20)] public bool NotifyOnValueChange = false;
        [Space(10)] public float Value;
        [Space(10)] public float ResetValue;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public FloatValueSO valueSO;

        public CreateNewFloatValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<FloatValueSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_FLOAT_" + FloatName + ".asset");

            valueSO.SetValue(Value);
            valueSO.SetResetValue(ResetValue);
            valueSO.SetNotifyOnChange(NotifyOnValueChange);

            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<FloatValueSO>();
        }
    }

    public class CreateNewBoolValueSO
    {
        [Space(25)] public string BoolName;

        [Space(20)] public bool NotifyOnValueChange = false;
        [Space(10)] public bool Value;
        [Space(10)] public bool ResetValue;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public BoolValueSO valueSO;

        public CreateNewBoolValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<BoolValueSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_BOOL_" + BoolName + ".asset");

            valueSO.SetValue(Value);
            valueSO.SetResetValue(ResetValue);
            valueSO.SetNotifyOnChange(NotifyOnValueChange);

            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<BoolValueSO>();
        }
    }

    public class CreateNewStringValueSO
    {
        [Space(25)] public string StringName;

        [Space(20)] public bool NotifyOnValueChange = false;
        [Space(10)] public string Value;
        [Space(10)] public string ResetValue;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public StringValueSO valueSO;

        public CreateNewStringValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<StringValueSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_STRING_" + StringName + ".asset");

            valueSO.SetValue(Value);
            valueSO.SetResetValue(ResetValue);
            valueSO.SetNotifyOnChange(NotifyOnValueChange);

            AssetDatabase.SaveAssets();
            valueSO = ScriptableObject.CreateInstance<StringValueSO>();
        }
    }

    public class CreateNewActionValueSO
    {
        [Space(25)] public string ActionName;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public ActionSO valueSO;

        public CreateNewActionValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<ActionSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_ACTION_" + ActionName + ".asset");
            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<ActionSO>();
        }
    }

    public class CreateNewUniqueIdentifier
    {
        [Space(25)] public string SimpleStateName;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector]
        public UniqueIdentifier valueSO;

        public CreateNewUniqueIdentifier()
        {
            valueSO = ScriptableObject.CreateInstance<UniqueIdentifier>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_STATE_" + SimpleStateName + ".asset");
            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<UniqueIdentifier>();
        }
    }

    public class CreateNewAnimationStateValueSO
    {
        [Space(25)] public string AnimationStateName;

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)] [HideInInspector] [Space(10)]
        public AnimationStateSO valueSO;

        [Space(10)] public StringReference[] AnimationStateNames;
        [Space(10)] public bool isCrossFade = true;
        [Space(10)] public bool OverrideToCanPlayAgain = false;

        public CreateNewAnimationStateValueSO()
        {
            valueSO = ScriptableObject.CreateInstance<AnimationStateSO>();
        }

        [PropertySpace(SpaceBefore = 50)]
        [Button]
        public void CreateNewData()
        {
            AssetDatabase.CreateAsset(valueSO,
                "Assets/_Project/Data/" + "SO_Animation_STATE_" + AnimationStateName + ".asset");

            valueSO.isCrossFade = isCrossFade;
            valueSO.OverrideToCanPlayAgain = OverrideToCanPlayAgain;
            valueSO.AnimationStateName = AnimationStateNames;

            AssetDatabase.SaveAssets();

            valueSO = ScriptableObject.CreateInstance<AnimationStateSO>();
        }
    }
}