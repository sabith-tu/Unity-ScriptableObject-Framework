using UnityEngine;

namespace UnityAutoSave
{
    public class AutoSaveConfig : ScriptableObject
    {
        [Tooltip("Enable auto save functionality")]
        public bool Enabled = true;

        [Tooltip("The frequency in minutes auto save will activate"), Min(1)]
        public int Frequency = 1;

        [Tooltip("Log a message every time the scene is auto saved")]
        public bool Logging = true;
    }
}