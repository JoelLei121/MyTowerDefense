using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public SceneFader fader;

    public Button[] levelButtons;

    string mainMenu = "MainMenu";

    public void SelectLevel(string Level)
    {
        fader.FadeTo(Level);
    }

    public void Menu()
    {
        fader.FadeTo(mainMenu);
    }

    private void Start()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for(int i = 0; i < levelButtons.Length; i++)
        {
            if(i+1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }


}
