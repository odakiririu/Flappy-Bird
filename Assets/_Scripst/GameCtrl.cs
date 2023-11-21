
using TMPro;
using UnityEngine;

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl Ins;
    [SerializeField] private TextMeshProUGUI txtcurrentScore;
    [SerializeField] private TextMeshProUGUI txtbestScore;
    [SerializeField] private GameObject pnButtonStartGame;
    [SerializeField] private GameObject pnEndGame;
    [SerializeField] private GameObject buttonPauseGame;
    [SerializeField] private GameObject buttonResumeGame;
    [SerializeField] private int currentScore;  
    [SerializeField] private int bestScore;  
    public enum GameState
    {
        Opening,
        GamePlay,
        GamePause,
        GameOver
    }
    [SerializeField]  public GameState gameState;
    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else if (Ins)
        {
            Destroy(this);
        }

    }
    void Start()
    {
        SetGameManagerState(GameState.Opening);
    }
    public void SetGameManagerState(GameState state)
    {
        gameState = state;
        SwitchGameState();
    }
    public void SwitchGameState()
    {
        switch (gameState)
        {
            case GameState.Opening:
                CheckBestScore();
                UICtrl.Ins.SetActive(pnButtonStartGame, true);
                currentScore = 0;
                break;
            case GameState.GamePlay:
                BirdCtrl.Ins.Init();
                break;
            case GameState.GamePause:
                break;
            case GameState.GameOver:
                SaveScoreInPlayerPrefs();
                DestroyBird();
                UICtrl.Ins.SetActive(pnEndGame, true);
                break;
        }
    }
    public void StartGamePlay()
    {
        SetGameManagerState(GameState.GamePlay);
        UICtrl.Ins.SetActive(pnButtonStartGame, false);
        UICtrl.Ins.SetActive(buttonPauseGame, true);
    }
    public void ButtonRestart() // click here set active pannel Endgame include button restart game, image endgame and set state open game
    {
        SetGameManagerState(GameState.Opening);
        UICtrl.Ins.SetActive(pnEndGame, false);
    }
    public void PauseGame()
    {
        UICtrl.Ins.SetActive(buttonPauseGame, false);
        UICtrl.Ins.SetActive(buttonResumeGame, true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        UICtrl.Ins.SetActive(buttonPauseGame, true);
        UICtrl.Ins.SetActive(buttonResumeGame, false);
        Time.timeScale = 1;
    }
    void UpdateUI()
    {
        txtcurrentScore.text = currentScore.ToString();
        txtbestScore.text = (PlayerPrefs.GetInt("BEST_SCORE") > currentScore ? PlayerPrefs.GetInt("BEST_SCORE") : currentScore).ToString();
    }
    public void IncreasecurrentScore()
    {
        currentScore = currentScore + 1;
    }
    public void SaveScoreInPlayerPrefs()
    {
        if (currentScore > PlayerPrefs.GetInt("BEST_SCORE"))
        {
            PlayerPrefs.SetInt("BEST_SCORE", currentScore);
        }
    }
    public void CheckBestScore()
    {
        if (PlayerPrefs.HasKey("BEST_SCORE")) return;
        PlayerPrefs.SetInt("BEST_SCORE", 0);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    void DestroyBird()
    {
        var bird = GameObject.FindWithTag("Bird");
        Destroy(bird);

    }
}
