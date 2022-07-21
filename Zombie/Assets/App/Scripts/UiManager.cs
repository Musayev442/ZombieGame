using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gameMenuPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Text menuText;
    [SerializeField] private Button restarButton;
    [SerializeField] private Slider healthBarSlider;

    public GameState State;
    public int a=5;

    public void SetHealthBarSlider(float value)
    {
        healthBarSlider.value = value;
    }

     private void Awake()
    {
        Time.timeScale = 0;
    }

    public void UpdateGameState(GameState state)
    {
        State = state;
        switch (State) 
        {
            case GameState.Play:
                GamePlay();
                break;
            case GameState.Pause:
                GamePause();
                break;
            case GameState.Restart:
               SceneManager.LoadScene("Demo_Bunker");
               //SceneManager.LoadScene(0);
               //Application.LoadLevel(Application.loadedLevel);
                break;
            case GameState.Quit:
                Application.Quit();
                break;
        }
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        mainMenuPanel.SetActive(true);
        restarButton.interactable=true;
        gameMenuPanel.SetActive(false);
    }

    public void GamePlay()
    {
        Time.timeScale = 1;
        mainMenuPanel.SetActive(false);
        gameMenuPanel.SetActive(true);
        gameOverPanel.SetActive(false);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }

}
public enum GameState 
{
    Play,
    Pause,
    Restart,
    Quit
}