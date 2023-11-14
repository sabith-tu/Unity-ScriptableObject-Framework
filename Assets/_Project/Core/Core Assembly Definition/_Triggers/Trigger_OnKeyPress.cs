using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    enum OnKeyPress_Modes
    {
        Press,
        Hold,
        PressAndRelise
    }

    [AddComponentMenu("_SABI/Trigger/Trigger_OnKeyPress")]
    public class Trigger_OnKeyPress : SerializedMonoBehaviour, IExecutable
    {

        [Space(10)][SerializeField] private KeyCode key;
        [Space(10)][SerializeField] private OnKeyPress_Modes mode = OnKeyPress_Modes.Press;
        [Space(10)][SerializeField][HideReferenceObjectPicker][ShowIf("@(mode == OnKeyPress_Modes.Press || mode == OnKeyPress_Modes.PressAndRelise)")] private SabiEventAdvanced whatToInvokeOnKeyPress = new();
        [Space(10)][SerializeField][HideReferenceObjectPicker][ShowIf("@mode == OnKeyPress_Modes.PressAndRelise")] private SabiEventAdvanced whatToInvokeOnKeyRelise = new();
        [Space(10)][SerializeField][HideReferenceObjectPicker][ShowIf("@mode == OnKeyPress_Modes.Hold")] private SabiEventAdvanced whatToInvokeOnKeyHold = new();

        private void Update()
        {
            if (Input.GetKeyDown(key) && (mode == OnKeyPress_Modes.Press || mode == OnKeyPress_Modes.PressAndRelise)) InvokeIt();
            if (Input.GetKeyUp(key) && mode == OnKeyPress_Modes.PressAndRelise) InvokeIt();
            if (Input.GetKey(key) && mode == OnKeyPress_Modes.Hold) InvokeIt();
        }

        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            switch (mode)
            {
                case OnKeyPress_Modes.Press:
                    whatToInvokeOnKeyPress.Invoke();
                    break;
                case OnKeyPress_Modes.Hold:
                    whatToInvokeOnKeyHold.Invoke();
                    break;
                case OnKeyPress_Modes.PressAndRelise:
                    whatToInvokeOnKeyRelise.Invoke();
                    break;
            }

        }

        public void Execute() => InvokeIt();
    }
}