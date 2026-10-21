using TMPro;
using UnityEngine;

public class HUDCanvas : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    public static HUDCanvas Instance;

    public GameObject pauseMenuPanel;
    private int coins;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateText();
    }

    private void Update()
    {
        bool isPaused = GameStateManager.Instance.CurrentState == GameState.Paused;
        pauseMenuPanel.SetActive(isPaused);
    }

    public void AddCoin()
    {
        coins++;
        UpdateText();
    }

    private void UpdateText()
    {
        coinText.text = $"Coins Collected: {coins}";
    }
}