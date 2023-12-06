using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject UI;
    [SerializeField] private bool isPaused;
    public AudioSource audioSource;

    public void Pause()
    {
        isPaused = !pauseMenu.activeSelf;
        Time.timeScale = isPaused ? 0f : 1f;
        audioSource.Pause();
        pauseMenu.SetActive(true);
        UI.SetActive(false);
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = isPaused ? 0f : 1f;
    }
    public void Resume()
    {
        isPaused = !pauseMenu.activeSelf;
        Time.timeScale = isPaused ? 0f : 1f;
        audioSource.Play();
        pauseMenu.SetActive(false);
        UI.SetActive(true);
    }
    public bool IsPaused()
    {
        return isPaused;
    }
}
