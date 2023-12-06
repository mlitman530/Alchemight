using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public HotbarManager hotbarManager;
    public PlayerController playerController;

    public void ToShop()
    {
        Dictionary<string, float> stats = playerController.GetStats();
        int numAttempts = playerController.GetNumAttempts();
        // Dictionary<int, int> inv = hotbarManager.GetHeldCounts();

        // PlayerPrefs.SetInt("NumHealthPotions", inv[5]);
        // PlayerPrefs.SetInt("NumStrengthPotions", inv[2]);
        // PlayerPrefs.SetInt("NumSpeedPotions", inv[3]);
        // PlayerPrefs.SetInt("NumJumpPotions", inv[4]);
        // PlayerPrefs.SetInt("SwordPurchased", inv[0]);
        // PlayerPrefs.SetInt("NumFirePotions", inv[1]);

        PlayerPrefs.SetFloat("Strength", stats["Strength"]);
        PlayerPrefs.SetFloat("Speed", stats["Speed"]);
        PlayerPrefs.SetFloat("Jump", stats["Jump"]);
        PlayerPrefs.SetFloat("MaxHealth", stats["MaxHealth"]);

        PlayerPrefs.SetInt("Gold", hotbarManager.GetGold());

        PlayerPrefs.SetInt("Attempts", numAttempts);

        SceneManager.LoadScene("DeathScreen");
    }
}
