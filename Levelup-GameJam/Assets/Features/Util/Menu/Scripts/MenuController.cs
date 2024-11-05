using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Features.Util.Menu.Scripts
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private string _sceneName;
        [SerializeField] public Animator Animator;  
    
        public string AnimationTriggerName = "LogoAnimation";  
        public float MinInterval = 5f; 
        public float MaxInterval = 10f; 

        private void Start()
        {
            StartCoroutine(PlayAnimationWithRandomInterval());
        }

        private System.Collections.IEnumerator PlayAnimationWithRandomInterval()
        {
            while (true)
            {
                float interval = Random.Range(MinInterval, MaxInterval);
                Debug.Log(interval);
                yield return new WaitForSeconds(interval);
                Animator.SetTrigger(AnimationTriggerName);
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
}
