using TMPro;
using UnityEngine;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;

    public string Name;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {

    }
}
