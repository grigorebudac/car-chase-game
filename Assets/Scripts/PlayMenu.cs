using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void StartSingleplayer()
    {
        SceneManager.LoadScene("Scenes/AlternateGameplay");
    }

    public void StartMultiplayer()
    {
        SceneManager.LoadScene("Scenes/MapScene");
    }
}
