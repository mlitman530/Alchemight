using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public HotbarManager hotbarManager;

    public void ToShop()
    {
        Dictionary<int, int> inv = hotbarManager.GetHeldCounts();

        PlayerPrefs.SetInt("NumHealthPotions", inv[5]);
        PlayerPrefs.SetInt("NumStrengthPotions", inv[2]);
        PlayerPrefs.SetInt("NumSpeedPotions", inv[3]);
        PlayerPrefs.SetInt("NumJumpPotions", inv[4]);
        //PlayerPrefs.SetInt("SwordPurchased", inv[0]);
        PlayerPrefs.SetInt("NumFirePotions", inv[1]);

        SceneManager.LoadScene("Shop");
    }
}
