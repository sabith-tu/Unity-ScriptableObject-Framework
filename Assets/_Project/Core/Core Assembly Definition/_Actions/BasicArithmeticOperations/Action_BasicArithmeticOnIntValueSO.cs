using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.SOA.BasicArithmeticOperations
{
    [AddComponentMenu("_SABI/Action/_BasicArithmetic/BasicArithmeticOnIntValueSO")]
    public class Action_BasicArithmeticOnIntValueSO : SerializedMonoBehaviour, IExecutable
    {
        [Space(5)][SerializeField] private IntReference firstVariable;

        [Space(5)]
        [SerializeField]
        private BasicArithmeticForNumbers arithmeticForNumbersOperation = BasicArithmeticForNumbers.Multiplication;

        [Space(5)][SerializeField] private IntReference secondVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        private IntReference resultVariable;

        [PropertySpace(SpaceAfter = 5)]
        [SerializeField]
        [HideReferenceObjectPicker]
        private SabiEventAdvanced OnComplete = new();


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