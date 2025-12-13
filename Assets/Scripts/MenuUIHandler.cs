using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI highScoreText;

    private void Start()
    {
        UpdateHighScoreText();
        nameInputField.text = HighScoreManager.Instance.highScoreName;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        string nameInputText = nameInputField.text;
        HighScoreManager.Instance.name = nameInputText;
        Debug.Log("Name: " + nameInputText);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void UpdateHighScoreText()
    {
        if (HighScoreManager.Instance.highScoreName != null)
        {
            highScoreText.text = "High Score: " + HighScoreManager.Instance.highScoreName + " - " + HighScoreManager.Instance.highScore;
        }
    }
}
