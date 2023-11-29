using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningLevels : MonoBehaviour
{
    string mainMenu = "MainMenu";

    public int nextLevel = 2;
    public string nextScene = "Level02";

    public Button nextButton;

    public GameManager gameManager;
    public SceneFader sceneFader;

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            nextButton.interactable = false;
        }
    }

    public void OnEnable()
    {
        PlayerPrefs.SetInt("levelReached", nextLevel);
    }

    public void Next()
    {
        sceneFader.FadeTo(nextScene);
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
        Time.timeScale = 1f;
    }

}
