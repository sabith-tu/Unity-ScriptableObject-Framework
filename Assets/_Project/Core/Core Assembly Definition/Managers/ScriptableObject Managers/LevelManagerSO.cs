using UnityEngine;
using UnityEngine.SceneManagement;

namespace SABI.Managers.ScriptableObject_Managers
{
    [CreateAssetMenu(menuName = "SO/Manager/LevelManager")]
    public class LevelManagerSO : ScriptableObject
    {
        public void OpenNextLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}