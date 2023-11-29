using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    string mainMenu = "MainMenu";

    public static bool canCall = true;
    public SceneFader sceneFader;

    private void Start()
    {
        Time.timeScale = 1f;
        canCall = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&canCall)
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf == true)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        sceneFader.FadeTo(mainMenu);
        Time.timeScale = 1f;
    }
}
