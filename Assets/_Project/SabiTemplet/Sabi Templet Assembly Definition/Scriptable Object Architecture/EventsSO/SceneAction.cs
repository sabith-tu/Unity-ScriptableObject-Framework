using System;
using UnityEngine;

namespace SABI.SOA
{
    [AddComponentMenu("_SABI/Data/SceneAction")]
    public class SceneAction : MonoBehaviour
    {
        public ActionReference action;

        public Action GetAction()
        {
            return action.GetAction();
        }

        public void SetAction(Action newAction)
        {
            action.SetAction(newAction);
        }

        public void InvokeAction()
        {
            action.InvokeAction();
        }
    }
}