using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] public Animator animator;  
    
    public string animationTriggerName = "LogoAnimation";  
    public float minInterval = 5f; 
    public float maxInterval = 10f; 

    private void Start()
    {
        StartCoroutine(PlayAnimationWithRandomInterval());
    }

    private System.Collections.IEnumerator PlayAnimationWithRandomInterval()
    {
        while (true)
        {
            float interval = Random.Range(minInterval, maxInterval);
            Debug.Log(interval);
            yield return new WaitForSeconds(interval);
            animator.SetTrigger(animationTriggerName);
        }
    }

    public void StartGame() =>
        SceneManager.LoadScene(_sceneName);

    public void OpenCredits()
    {

    }

    public void OpenHelp()
    {

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
