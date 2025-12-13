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
        HighScoreManager.Instance.SaveHighScore();
        UpdateHighScoreText();
        nameInputField.text = HighScoreManager.Instance.Name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        string nameInputText = nameInputField.text;
        HighScoreManager.Instance.Name = nameInputText;
        Debug.Log("Name: " + nameInputText);
        HighScoreManager.Instance.Name = nameInputText;
        HighScoreManager.Instance.SaveHighScore();
    }

    public void QuitGame()
    {
        HighScoreManager.Instance.SaveHighScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + HighScoreManager.Instance.Name + " - " + HighScoreManager.Instance.highScore;
    }
}
