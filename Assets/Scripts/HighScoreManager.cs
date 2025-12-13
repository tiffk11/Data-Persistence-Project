using TMPro;
using System.IO;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager Instance;
    private MainManager mainManager;

    public string Name;
    public int score;
    public int highScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadName();
    }


    [System.Serializable]
    class SaveData
    {
        public string Name;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void SaveHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }

        Debug.Log("High Score: " + highScore);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Name = data.Name;
        }
    }
}
