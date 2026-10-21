using UnityEngine;
using UnityEngine.InputSystem;

public enum GameState
{ 
    Menus, // Menus is used for both the title screen and results screen.
    Playing,
    Paused
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameState CurrentState = GameState.Menus;

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

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;

        if (keyboard == null)
        {
            return;
        }

        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            TogglePause();
        }
    }

    public void SetState(GameState newState)
    {
        CurrentState = newState;
        if (newState == GameState.Paused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void TogglePause()
    {
        if (CurrentState == GameState.Playing)
        {
            SetState(GameState.Paused);
        }
        else if (CurrentState == GameState.Paused)
        {
            SetState(GameState.Playing);
        }
    }
    public void StartGame()
    {
        LevelManager.Instance.LoadGameplay();
        SetState(GameState.Playing);
    }

    public void GoalReached()
    {
        LevelManager.Instance.LoadResults();
        SetState(GameState.Menus);
    }

    public void GoToMenu()
    {
        LevelManager.Instance.LoadMainMenu();
        SetState(GameState.Menus);
    }
}