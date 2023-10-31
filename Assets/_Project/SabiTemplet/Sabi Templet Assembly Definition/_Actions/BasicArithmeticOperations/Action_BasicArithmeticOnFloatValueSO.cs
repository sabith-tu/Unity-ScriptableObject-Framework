using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.SOA.BasicArithmeticOperations
{
    [AddComponentMenu("_SABI/Action/_BasicArithmetic/BasicArithmeticOnFloatValueSO")]
    public class Action_BasicArithmeticOnFloatValueSO : SerializedMonoBehaviour, IExecutable
    {
        [Space(5)][SerializeField] private FloatReference firstVariable;

        [Space(5)]
        [SerializeField]
        private BasicArithmeticForNumbers arithmeticForNumbersOperation = BasicArithmeticForNumbers.Multiplication;

        [Space(5)][SerializeField] private FloatReference secondVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        private FloatReference resultVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        [HideReferenceObjectPicker] private SabiEventAdvanced OnComplete = new();


        [Button]
        public void DoBasicArithmetic()
        {
            switch (arithmeticForNumbersOperation)
            {
                case BasicArithmeticForNumbers.Addition:
                    resultVariable.SetValue(firstVariable.GetValue() + secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Subtraction:
                    resultVariable.SetValue(firstVariable.GetValue() - secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Multiplication:
                    resultVariable.SetValue(firstVariable.GetValue() * secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Division:
                    resultVariable.SetValue(firstVariable.GetValue() / secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Modulus:
                    resultVariable.SetValue(firstVariable.GetValue() % secondVariable.GetValue());
                    break;
            }

            OnComplete.Invoke();
        }

        public void Execute()
        {
            DoBasicArithmetic();
        }
    }
}