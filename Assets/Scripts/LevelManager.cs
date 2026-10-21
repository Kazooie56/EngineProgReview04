using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("1.MainMenu");
    }
    public void LoadGameplay()
    {
        // Writing just "Gameplay" works the same as "Gameplay", LoadSceneMode.Single
        // the default mode is Single, and Single means "unload all loaded scenes"
        SceneManager.LoadScene("Gameplay", LoadSceneMode.Single);
        SceneManager.LoadScene("HUD", LoadSceneMode.Additive);
    }
    public void LoadResults()
    {
        SceneManager.LoadScene("Results");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}