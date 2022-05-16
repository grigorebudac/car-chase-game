using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject deadMenuUI;
    public TextMeshProUGUI audioText;

    private float tempVolume;

    private void Awake()
    {
        pauseMenuUI.SetActive(false);
        deadMenuUI.SetActive(false);
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

    public void Resume(bool modifyVolume) {
        if(modifyVolume)
        {
            AudioListener.volume = tempVolume;
        }

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }


    public void Resume()
    {
        this.Resume(true);
    }

    public void Pause() {
        SetAudioBtnText();

        tempVolume = AudioListener.volume;
        AudioListener.volume = 0f;

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // time moving in slow motion
        isGamePaused = true;
    }

    public void Restart()
    {
        Resume(false);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ToggleAudio()
    {
        float volume = tempVolume == 0f ? 1f : 0f;
        AudioListener.volume = volume;
        tempVolume = volume;

        this.Resume();
    }

    private void SetAudioBtnText()
    {
        audioText.text = AudioListener.volume == 0f ? "Enable Audio" : "Disable Audio";
    }

    public void ShowDeadMenu()
    {
        deadMenuUI.SetActive(true);
    }
}
