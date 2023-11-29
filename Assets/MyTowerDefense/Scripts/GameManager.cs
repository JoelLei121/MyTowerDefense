using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject GameOverUI;
    public GameObject VictoryUI;
    public GameObject gameMaster;

    public Button startButton;

    private void Start()
    {
        GameIsOver = false;
        startButton.interactable = true;
        gameMaster.GetComponent<WaveSpawner>().enabled = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame() {
        GameIsOver = true;
        PauseMenu.canCall = false;
        GameOverUI.SetActive(true);
        Debug.Log("Game Over!");
    }

    public void WinLevel()
    {
        GameIsOver = true;
        PauseMenu.canCall = false;
        VictoryUI.SetActive(true); 
    }

    public void StartGame()
    {
        gameMaster.GetComponent<WaveSpawner>().enabled = true;
        startButton.interactable = false;
    }

}
