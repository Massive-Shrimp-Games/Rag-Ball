using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public Controllers Controllers { get; private set; }

    private void CreateSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        CreateSingleton();
        Controllers = transform.Find("Controllers").GetComponent<Controllers>();
    }

    private void Start()
    {
#if !UNITY_EDITOR
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
#endif
    }
}
