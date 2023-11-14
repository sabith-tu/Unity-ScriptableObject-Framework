using UnityEngine;
using System.IO;
using SABI.StaticEvent;

namespace SABI.SaveSystemSO
{
    [CreateAssetMenu(fileName = "SaveSystemSO", menuName = "SO/Manager/SaveSystemManager")]
    public class SaveSystemSO : ScriptableObject
    {
        private string directery = "/SaveData";
        private string fileName = "MyData.txt";

        [Space(10)] [SerializeField] private bool loadAutomaticallyOnStart = false;
        
        [Space(10)] public SaveData GameData;


        private void OnEnable()
        {
            if (loadAutomaticallyOnStart) GlobalStaticEventManager.StartAction += Load;
        }

        [ContextMenu("Save")]
        public void Save()
        {
            string dir = Application.persistentDataPath + directery;
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            string json = JsonUtility.ToJson(GameData);
            File.WriteAllText(dir + fileName, json);
            Debug.Log("------------------Saving------------------");
        }

        [ContextMenu("Load")]
        public void Load()
        {
            string fullPath = Application.persistentDataPath + directery + fileName;

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(fullPath);
                GameData = JsonUtility.FromJson<SaveData>(json);
                Debug.Log("------------------Loading------------------");
            }
        }

        void DeleteAllSaveData()
        {
            GameData = new SaveData();
            Save();
        }
    }
}