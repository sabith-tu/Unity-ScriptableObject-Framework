using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.SOA.BasicArithmeticOperations
{
    [AddComponentMenu("_SABI/Action/_BasicArithmetic/BasicArithmeticOnBoolValueSO")]
    public class Action_BasicArithmeticOnBoolValueSO : SerializedMonoBehaviour, IExecutable
    {
        [Space(5)][SerializeField] private BoolReference firstVariable;

        [Space(5)]
        [SerializeField]
        private BasicArithmeticForBoolean arithmeticForBoolean = BasicArithmeticForBoolean.And;

        [Space(5)][SerializeField] private BoolReference secondVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        private BoolReference resultVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        [HideReferenceObjectPicker] private SabiEventAdvanced OnComplete = new();


        [Button]
        public void DoBasicArithmetic()
        {
            switch (arithmeticForBoolean)
            {
                case BasicArithmeticForBoolean.And:
                    resultVariable.SetValue(firstVariable.GetValue() && secondVariable.GetValue());
                    break;
                case BasicArithmeticForBoolean.Or:
                    resultVariable.SetValue(firstVariable.GetValue() || secondVariable.GetValue());
                    break;
                case BasicArithmeticForBoolean.Not:
                    resultVariable.SetValue(!firstVariable.GetValue());
                    break;
                case BasicArithmeticForBoolean.AtLeastOneIsTrue:
                    resultVariable.SetValue(
                        (firstVariable.GetValue() && secondVariable.GetValue()) ||
                        (firstVariable.GetValue() && !secondVariable.GetValue()) ||
                        (!firstVariable.GetValue() && secondVariable.GetValue())
                    );
                    break;
                case BasicArithmeticForBoolean.AtLeastOneIsFalse:
                    resultVariable.SetValue(
                        (!firstVariable.GetValue() && !secondVariable.GetValue()) ||
                        (firstVariable.GetValue() && !secondVariable.GetValue()) ||
                        (!firstVariable.GetValue() && secondVariable.GetValue())
                    );
                    break;
                case BasicArithmeticForBoolean.BothOfThemIsTrue:
                    resultVariable.SetValue(firstVariable.GetValue() && secondVariable.GetValue());
                    break;
                case BasicArithmeticForBoolean.BothOfThemIsFalse:
                    resultVariable.SetValue(!firstVariable.GetValue() && !secondVariable.GetValue());
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            OnComplete.Invoke();
        }

        public void Execute()
        {
            DoBasicArithmetic();
        }
    }
}