using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using static UnityEditor.Progress;
#endif

public class DrinkablePotion : MonoBehaviour
{
    private bool currentlyHeld;

    public int tempStrength;
    public int tempSpeed;
    public int tempHealth;
    public int tempJump;
    private int currentStrength;
    private int currentSpeed;
    private int currentHealth;
    private int currentJump;
    private int uses;
    public PlayerController controller;
    private HotbarManager hotbarManager;



    void Start()
    {
        currentStrength = PlayerPrefs.GetInt("StrengthForRun");
        currentSpeed = PlayerPrefs.GetInt("SpeedForRun");
        currentHealth = PlayerPrefs.GetInt("HealthForRun");
        currentJump = PlayerPrefs.GetInt("JumpForRun");

        PlayerPrefs.SetInt("Current Strength", currentStrength);
        PlayerPrefs.SetInt("Current Speed", currentSpeed);
        PlayerPrefs.SetInt("Current Health", currentHealth);
        PlayerPrefs.SetInt("Current Jump", currentJump);

        hotbarManager = FindObjectOfType<HotbarManager>();  // Find the HotbarManager
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void drinkPotion()
    {
        Item potionItem = GetComponent<Item>();
        if (potionItem.isHeld)
        {
            currentStrength = PlayerPrefs.GetInt("Current Strength");
            currentSpeed = PlayerPrefs.GetInt("Current Speed");
            currentHealth = PlayerPrefs.GetInt("Current Health");
            currentJump = PlayerPrefs.GetInt("Current Jump");

            PlayerPrefs.SetInt("Current Strength", currentStrength + tempStrength);
            PlayerPrefs.SetInt("Current Speed", currentSpeed + tempSpeed);
            PlayerPrefs.SetInt("Current Health", currentHealth + tempHealth);
            PlayerPrefs.SetInt("Current Jump", currentJump + (tempJump / 5));
            controller.currentPlayerHealth += tempHealth;
            controller.ApplyStats(currentStrength + tempStrength, currentSpeed + tempSpeed, currentJump + (tempJump / 5), currentHealth + tempHealth);
            potionItem.SetHeldCount(potionItem.heldCount - 1);
            hotbarManager.IncrementHeldCount(potionItem.id, potionItem.heldCount);
            uses++;
            trackTempStats();
        }
    }

    public void trackTempStats()
    {
        PlayerPrefs.SetInt("tempStrength", tempStrength * uses);
        PlayerPrefs.SetInt("tempSpeed", tempSpeed * uses);
        PlayerPrefs.SetInt("tempHealth", tempHealth * uses);
        PlayerPrefs.SetInt("tempJump", tempJump * uses);
    }
}
