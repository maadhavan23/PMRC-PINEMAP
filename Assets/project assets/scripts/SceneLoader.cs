using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [System.Serializable]
    public class SceneEntry
    {
        public string sceneName;
    }

    [Header("Available Scenes")]
    public SceneEntry[] scenes;

    // This function can be hooked to any button to load a specific scene index
    public void LoadSceneByIndex(int sceneIndex)
    {
        if (sceneIndex < 0 || sceneIndex >= scenes.Length)
        {
            Debug.LogError("Scene index out of range!");
            return;
        }

        string sceneToLoad = scenes[sceneIndex].sceneName;
        SceneManager.LoadScene(sceneToLoad);
    }
}