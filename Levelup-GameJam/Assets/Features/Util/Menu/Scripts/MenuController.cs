using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public void StartGame() =>
        SceneManager.LoadScene(_sceneName);

    public void OpenCredits()
    {

    }

    public void OpenHelp()
    {

    }

    public void QuitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
