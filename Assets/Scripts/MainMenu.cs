using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Scenes/PlayMenuScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartSingleplayer()
    {
        this.StartGame();
    }

    public void StartMultiplayer()
    {
        this.StartGame();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Scenes/SampleScene");
    }
}
