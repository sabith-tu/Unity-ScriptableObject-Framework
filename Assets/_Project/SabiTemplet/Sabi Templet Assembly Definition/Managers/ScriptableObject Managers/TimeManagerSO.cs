
using SABI.SOA;
using SABI.StaticEvent;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SABI.Managers.ScriptableObject_Managers
{
    [CreateAssetMenu(menuName = "SO/Manager/TimeManager")]
    public class TimeManagerSO : ScriptableObject
    {
        public bool startGameAsPaused = false;
        public bool InvokeActionsOnPauseAndResume = false;

        [ShowIf("InvokeActionsOnPauseAndResume")]
        public ActionSO OnPausedAction;

        [ShowIf("InvokeActionsOnPauseAndResume")]
        public ActionSO OnResumedAction;

        private void OnEnable() => GlobalStaticEventManager.StartAction += PauseGame;

        public void SetTimeScale(float value) => Time.timeScale = value;

        public void PauseGame()
        {
            SetTimeScale(0);
            if (InvokeActionsOnPauseAndResume) OnPausedAction.InvokeAction();
        }

        public void ResumeGame()
        {
            SetTimeScale(1);
            if (InvokeActionsOnPauseAndResume) OnResumedAction.InvokeAction();
        }

        public void SlowMoSpeed(float value = 0.1f)
        {
            SetTimeScale(value);
            Time.fixedDeltaTime = value * 0.02f;
        }

        public void NormalSpeed()
        {
            SetTimeScale(1);
            Time.fixedDeltaTime = 0.02f;
        }
    }
}