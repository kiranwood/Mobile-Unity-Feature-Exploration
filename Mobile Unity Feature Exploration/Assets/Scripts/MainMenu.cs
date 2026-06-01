using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _levelSceneName = "LevelScene";

    // Loads level scene
    public void PlayGame()
    {
        SceneManager.LoadScene(_levelSceneName);
    }
    
    // Quits the game in build or editor
    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
