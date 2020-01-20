#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoadAttribute]
public static class DefaultSceneLoader
{

    static DefaultSceneLoader()
    {
        EditorApplication.playModeStateChanged += LoadDefaultScene;
    }

    static void LoadDefaultScene(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
        }

        if (state == PlayModeStateChange.EnteredPlayMode)
        {
            int currentSceneBuildIndex = EditorSceneManager.GetActiveScene().buildIndex;
            if (currentSceneBuildIndex != 0)
            {
                EditorSceneManager.LoadScene(0);
                EditorSceneManager.LoadScene(currentSceneBuildIndex);
            }
        }
    }
}
#endif
