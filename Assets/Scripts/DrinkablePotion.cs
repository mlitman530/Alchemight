using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

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
        PlayerPrefs.SetInt("Current Strength", PlayerPrefs.GetInt("Strength"));
        PlayerPrefs.SetInt("Current Speed", PlayerPrefs.GetInt("Speed"));
        PlayerPrefs.SetInt("Current Health", PlayerPrefs.GetInt("Health"));
        PlayerPrefs.SetInt("Current Jump", PlayerPrefs.GetInt("Jump"));

        currentStrength = PlayerPrefs.GetInt("Strength");
        currentSpeed = PlayerPrefs.GetInt("Speed");
        currentHealth = PlayerPrefs.GetInt("Health");
        currentJump = PlayerPrefs.GetInt("Jump");

        hotbarManager = FindObjectOfType<HotbarManager>();  // Find the HotbarManager
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void drinkPotion()
    {
        Item potionItem = GetComponent<Item>();
        Debug.Log("Potion is held: " + potionItem.isHeld);
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
            potionItem.SetHeldCount(potionItem.heldCount - 1);
            hotbarManager.IncrementHeldCount(potionItem.id, potionItem.heldCount);
            uses++;
            trackTempStats();
            controller.ApplyStats(currentStrength, currentSpeed, currentJump, currentHealth);
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
