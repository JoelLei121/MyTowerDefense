using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    string SceneToLoad = "LevelSelector";
    public SceneFader sceneFader;


    public void StartGame()
    {
        sceneFader.FadeTo(SceneToLoad);
    }

    public void Quit()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }

    public void Help()
    {
        sceneFader.FadeTo("HelpMenu");
        Debug.Log("Help Menu.");
    }

    public void Clean()
    {
        PlayerPrefs.SetInt("levelReached", 1);
    }

    public void Testing()
    {
        sceneFader.FadeTo("recording");
    }
}
