using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        string nameInputText = nameInputField.text;
        NameManager.Instance.Name = nameInputText;
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
}
