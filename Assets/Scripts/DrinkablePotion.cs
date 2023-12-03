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

        Debug.Log("Drinking");
        if (GetComponent<Item>().isHeld)
        {
            PlayerPrefs.SetInt("Strength", currentStrength + tempStrength);
            PlayerPrefs.SetInt("Speed", currentSpeed + tempSpeed);
            PlayerPrefs.SetInt("Health", currentHealth + tempHealth);
            PlayerPrefs.SetInt("Jump", currentJump + tempJump);
            hotbarManager.IncrementHeldCount(GetComponent<Item>().id, GetComponent<Item>().heldCount - 1);
            uses++;
            trackTempStats();
            controller.SetStats();
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
