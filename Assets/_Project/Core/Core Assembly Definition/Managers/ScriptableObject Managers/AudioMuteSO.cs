using UnityEngine;

namespace SABI.Managers.ScriptableObject_Managers
{
    [CreateAssetMenu( menuName = "SO/Manager/AudioMuteSO")]
    public class AudioMuteSO : ScriptableObject
    {
        private bool _isMuted = false;
    
    
        public void MuteAudio()
        {
            if (_isMuted) return;
        
            AudioListener.volume = 0;
            _isMuted = true;


        }
    
        public void UnMuteAudio()
        {
            if (_isMuted == false) return;
            
            AudioListener.volume = 1;
            _isMuted = false;
        }
        
    }
}