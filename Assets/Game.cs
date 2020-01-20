using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : Singleton<Game>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
#if !UNITY_EDITOR
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
#endif
    }
}
