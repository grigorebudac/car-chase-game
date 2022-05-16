using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        AudioListener.volume = 1f;
    }

    public void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // time moving in slow motion
        isGamePaused = true;
        AudioListener.volume = 0f;
    }

    public void Restart()
    {
        Resume();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ToggleAudio()
    {

    }

    public void ToggleEffects()
    {

    }
}
