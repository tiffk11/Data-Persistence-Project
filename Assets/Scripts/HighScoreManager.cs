using TMPro;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private MainManager mainManager;

    public string name;
    public int score;
    public int highScore;
    public string highScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            highScoreName = name;
            SaveHighScore();
        }
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }
    
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.name = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        Debug.Log("High Score: " + highScore);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.name;
            highScore = data.highScore;
        }
    }
}
