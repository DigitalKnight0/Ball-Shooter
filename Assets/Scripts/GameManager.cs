using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static GameManager Instance;
    public string playerName;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
        
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}
