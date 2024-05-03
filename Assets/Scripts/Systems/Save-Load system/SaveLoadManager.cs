using System.IO;
using UnityEngine;

namespace Systems
{
    public class SaveLoadManager
    {
        public void SaveLevel(SavedData savedData)
        {
            SaveData(savedData, "savedData.json");
        }
        public void SaveData<T>(T data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(fileName, json);
        }
        
        public T LoadData<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                return JsonUtility.FromJson<T>(json);
            }
            else
            {
                Debug.LogError("File was not found: " + fileName);
                return default(T);
            }
        }
    }
}