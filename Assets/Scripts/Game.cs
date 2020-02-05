using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public Controllers Controllers { get; private set; }
    public Audio Music { get; private set; }
    public Audio SFX { get; private set; }
    public PauseMenu PauseMenu { get; private set; }

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
        Music = transform.Find("Music").GetComponent<Audio>();
        SFX = transform.Find("SFX").GetComponent<Audio>();
        PauseMenu = transform.Find("PauseMenu").GetComponent<PauseMenu>();
    }

    private void Start()
    {
#if !UNITY_EDITOR
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
#endif
    }
}
