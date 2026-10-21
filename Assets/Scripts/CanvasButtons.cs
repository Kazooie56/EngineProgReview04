using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    // The CanvasButtons lead to the GameStateManager, the GameStateManager leads to the LevelManager
    // CallItQuits is the only one that directly references LevelManager in here
    // since it doesn't change the game's state.

    public void ReturnToMainMenu()
    {
        GameStateManager.Instance.GoToMenu();
    }

    public void GoToGameplay()
    {
        GameStateManager.Instance.StartGame();
    }

    public void ResumeGame()
    {
        GameStateManager.Instance.TogglePause();
    }

    // Only button that uses LevelManager only.
    public void CallItQuits()
    {
        LevelManager.Instance.QuitGame();
    }
}