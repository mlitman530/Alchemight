using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("StatCustomization");
        ResetPlayerPrefs();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    private void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt("NumHealthPotions", 0);
        PlayerPrefs.SetInt("NumStrengthPotions", 0);
        PlayerPrefs.SetInt("NumSpeedPotions", 0);
        PlayerPrefs.SetInt("NumJumpPotions", 0);
        PlayerPrefs.SetInt("SwordPurchased", 0);
        PlayerPrefs.SetInt("NumFirePotions", 0);
        PlayerPrefs.SetInt("NumFreezePotions", 0);
        PlayerPrefs.SetInt("Strength", 5);
        PlayerPrefs.SetInt("Speed", 5);
        PlayerPrefs.SetInt("Health", 100);
        PlayerPrefs.SetInt("Jump", 1);
        PlayerPrefs.SetInt("Gold", 10);
        PlayerPrefs.SetInt("Attempts", 0);
        PlayerPrefs.SetInt("ZombiesKilled", 0);
    }
}
