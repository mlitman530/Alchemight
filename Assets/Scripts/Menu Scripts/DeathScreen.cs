using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI attemptsText;
    public TextMeshProUGUI waveReachedText;
    public TextMeshProUGUI highestWaveText;

    void Start()
    {
        //Debug.Log("Current gold (on death screen): " + PlayerPrefs.GetInt("Gold"));
        attemptsText.text = "Attempts: " + PlayerPrefs.GetInt("Attempts").ToString();
        waveReachedText.text = "Wave Reached: " + PlayerPrefs.GetInt("Wave").ToString();
        PlayerPrefs.SetInt("WaveReached", PlayerPrefs.GetInt("Wave"));
        if (PlayerPrefs.GetInt("WaveReached") > PlayerPrefs.GetInt("HighestWave"))
        {
            PlayerPrefs.SetInt("HighestWave", PlayerPrefs.GetInt("WaveReached"));
        }
        highestWaveText.text = "Highest Wave Reached: " + PlayerPrefs.GetInt("HighestWave").ToString();
    }

    public void BackToShop()
    {
        PlayerPrefs.SetInt("ZombiesKilled", 0);
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
