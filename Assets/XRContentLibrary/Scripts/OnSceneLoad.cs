using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class OnSceneLoad : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnLoad = new UnityEvent();

    void Awake()
    {
        SceneManager.sceneLoaded += PlayEvent;
    }
    
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= PlayEvent;
    }

    private void PlayEvent(Scene scene, LoadSceneMode mode)
    {
        OnLoad.Invoke();
    }
}
