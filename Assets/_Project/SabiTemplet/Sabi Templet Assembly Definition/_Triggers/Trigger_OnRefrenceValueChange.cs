using System;
using System.Collections.Generic;
using SABI.SOA;
using SABI.SOA.SimpleStatemachine;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnReferenceValueChange")]
    public class Trigger_OnReferenceValueChange : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)][SerializeField][TabGroup("Variable")] private SoValueTypes mode;
        [Space(10)][SerializeField][TabGroup("Variable")] private bool invokeOnStart;
        // Any
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [TabGroup("Events")]
        private SabiEventAdvanced whatToInvokeOnAnyVariable = new();
        // Int
        [Space(10)]
        [SerializeField]
        [ShowIf("@mode == SoValueTypes.IntValueSO")]
        [TabGroup("Variable")]
        private IntReference intValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.IntValueSO")]
        [TabGroup("Events")]
        private UnityEvent<int> whatToInvokeOnInt = new();
        [Space(10), SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.IntValueSO")]
        [TabGroup("Events")]
        private List<IntAndSabiEvent> whatToDoOnInt = new();
        // Float
        [Space(10)][SerializeField][ShowIf("@mode == SoValueTypes.FloatValueSO")][TabGroup("Variable")] private FloatReference flaotValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.FloatValueSO")]
        [TabGroup("Events")]
        private UnityEvent<float> whatToInvokeOnFloat = new();
        [Space(10), SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.FloatValueSO")]
        [TabGroup("Events")]
        private List<FloatAndSabiEvent> whatToDoOnFloat = new();
        // Bool
        [Space(10)][SerializeField][ShowIf("@mode == SoValueTypes.BoolValueSO")][TabGroup("Variable")] private BoolReference boolValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.BoolValueSO")]
        [TabGroup("Events")]
        private UnityEvent<bool> whatToInvokeOnBool = new();
        [Space(10), SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.BoolValueSO")]
        [TabGroup("Events")]
        private SabiEventAdvanced OnValueIsTrue = new();

        [Space(10), SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.BoolValueSO")]
        [TabGroup("Events")]
        private SabiEventAdvanced OnValueIsFalse = new();
        // String
        [Space(10)][SerializeField][ShowIf("@mode == SoValueTypes.StringValueSO")][TabGroup("Variable")] private StringReference stringValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.StringValueSO")]
        [TabGroup("Events")]
        private UnityEvent<string> whatToInvokeOnString = new();
        [Space(10), SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.StringValueSO")]
        [TabGroup("Events")]
        private List<StringAndSabiEvent> whatToDoOnString = new();
        // Vector2
        [Space(10)][SerializeField][ShowIf("@mode == SoValueTypes.Vector2ValueSO")][TabGroup("Variable")] private Vector2ValueSO vector2ValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.Vector2ValueSO")]
        [TabGroup("Events")]
        private UnityEvent<Vector2> whatToInvokeOnVector2 = new();
        // Vector3
        [Space(10)][SerializeField][ShowIf("@mode == SoValueTypes.Vector3ValueSO")][TabGroup("Variable")] private Vector3ValueSO vector3ValueSoVariable;
        [Space(10)]
        [SerializeField]
        [HideReferenceObjectPicker]
        [ShowIf("@mode == SoValueTypes.Vector3ValueSO")]
        [TabGroup("Events")]
        private UnityEvent<Vector3> whatToInvokeOnVector3 = new();



        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        private void OnEnable()
        {

            switch (mode)
            {

                case SoValueTypes.IntValueSO:
                    intValueSoVariable.ActionOnBaseVariableValueChange += InvokeIt;
                    intValueSoVariable.ActionOnExactValueChangeOnValueReference += CustomInvokeIt;
                    Debug.Log("trigger is  subscribed");
                    break;

                case SoValueTypes.FloatValueSO:
                    flaotValueSoVariable.ActionOnBaseVariableValueChange += InvokeIt;
                    //flaotValueSoVariable.OnValueChangeWithValue += CustomInvokeIt;
                    break;

                case SoValueTypes.BoolValueSO:
                    boolValueSoVariable.ActionOnBaseVariableValueChange += InvokeIt;
                    //boolValueSoVariable.OnValueChangeWithValue += CustomInvokeIt;
                    break;

                case SoValueTypes.StringValueSO:
                    stringValueSoVariable.ActionOnBaseVariableValueChange += InvokeIt;
                    //stringValueSoVariable.OnValueChangeWithValue += CustomInvokeIt;
                    break;

                case SoValueTypes.Vector2ValueSO:
                    vector2ValueSoVariable.OnValueChange += InvokeIt;
                    break;

                case SoValueTypes.Vector3ValueSO:
                    vector3ValueSoVariable.OnValueChange += InvokeIt;
                    break;
            }

        }

        private void OnDisable()
        {
            switch (mode)
            {


                case SoValueTypes.IntValueSO:
                    intValueSoVariable.ActionOnBaseVariableValueChange -= InvokeIt;
                    intValueSoVariable.ActionOnExactValueChangeOnValueReference -= CustomInvokeIt;
                    break;

                case SoValueTypes.FloatValueSO:
                    flaotValueSoVariable.ActionOnBaseVariableValueChange -= InvokeIt;
                    //flaotValueSoVariable.OnValueChangeWithValue -= CustomInvokeIt;
                    break;

                case SoValueTypes.BoolValueSO:
                    boolValueSoVariable.ActionOnBaseVariableValueChange -= InvokeIt;
                    //boolValueSoVariable.OnValueChangeWithValue -= CustomInvokeIt;
                    break;

                case SoValueTypes.StringValueSO:
                    stringValueSoVariable.ActionOnBaseVariableValueChange -= InvokeIt;
                    //stringValueSoVariable.OnValueChangeWithValue -= CustomInvokeIt;
                    break;

                case SoValueTypes.Vector2ValueSO:
                    vector2ValueSoVariable.OnValueChange -= InvokeIt;
                    break;

                case SoValueTypes.Vector3ValueSO:
                    vector3ValueSoVariable.OnValueChange -= InvokeIt;
                    break;
            }
        }

        [Button("Invoke Without value")]
        [PropertySpace(10)]
        void InvokeIt()
        {
            whatToInvokeOnAnyVariable.Invoke();
        }

        void CustomInvokeIt(int newValue)
        {
            foreach (var intAndSabiEvent in whatToDoOnInt)
            {
                if (intAndSabiEvent.value == newValue)
                {
                    intAndSabiEvent.Event.Invoke();
                    return;
                }
            }
        }
        // void CustomInvokeIt(float newValue)
        // {
        //     foreach (var floatAndSabiEvent in whatToDoOnFloat)
        //     {
        //         if (floatAndSabiEvent.value == newValue)
        //         {
        //             floatAndSabiEvent.Event.Invoke();
        //             return;
        //         }
        //     }
        // }
        // void CustomInvokeIt(bool newValue)
        // {
        //     if (newValue) OnValueIsTrue.Invoke();
        //     else OnValueIsFalse.Invoke();
        // }
        // void CustomInvokeIt(string newValue)
        // {
        //     foreach (var stringAndSabiEvent in whatToDoOnString)
        //     {
        //         if (stringAndSabiEvent.value == newValue)
        //         {
        //             stringAndSabiEvent.Event.Invoke();
        //             return;
        //         }
        //     }
        // }


        void InvokeIt(int value) => whatToInvokeOnAnyVariable.Invoke();

        public void Execute() => InvokeIt();
    }

    public enum SoValueTypes
    {
        IntValueSO,
        FloatValueSO,
        BoolValueSO,
        StringValueSO,
        Vector2ValueSO,
        Vector3ValueSO,
    }
    class IntAndSabiEvent
    {
        public int value;
        [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
    }
    class FloatAndSabiEvent
    {
        public float value;
        [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
    }
    class StringAndSabiEvent
    {
        public string value;
        [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
    }
    class UniqueIdentifierAndSabiEvent
    {
        public UniqueIdentifier value;
        [HideReferenceObjectPicker] public SabiEventAdvanced Event = new();
    }
}