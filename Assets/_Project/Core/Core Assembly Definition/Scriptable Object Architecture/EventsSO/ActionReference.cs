using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.SOA
{
    [System.Serializable]
    public class ActionReference
    {
        public bool UseSceneAction;

        [ShowIf("UseSceneAction"), SerializeField]
        private SceneAction sceneAction;

        [HideIf("UseSceneAction"), SerializeField]
        private ActionSO actionSO;

        public Action GetAction()
        {
            if (UseSceneAction)
            {
                return sceneAction.GetAction();
            }
            else
            {
                return actionSO.action;
            }
        }

        public void SetAction(Action newValue)
        {
            if (UseSceneAction)
            {
                sceneAction.SetAction(newValue);
            }
            else
            {
                actionSO.action = newValue;
            }
        }

        public void InvokeAction()
        {
            if (UseSceneAction)
            {
                sceneAction.InvokeAction();
            }
            else
            {
                actionSO.InvokeAction();
            }
        }
    }
}