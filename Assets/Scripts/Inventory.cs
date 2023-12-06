using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public PurchasableItems PurchasableItems;
    public List<int> inventory;
    private GameObject inventoryTextObject;
    private TextMeshProUGUI inventoryText;
    private GameObject inventoryTitleObject;
    private TextMeshProUGUI inventoryTitle;
    private GameObject goldTextObject;
    private TextMeshProUGUI goldText;
    public int currentGoldCount;


    void Start()
    {
        Debug.Log(inventory.Count);
        inventoryTitleObject = GameObject.Find("Inventory");
        inventoryTitle = inventoryTitleObject.GetComponent<TextMeshProUGUI>();
        inventoryTextObject = GameObject.Find("Inventory List");
        inventoryText = inventoryTextObject.GetComponent<TextMeshProUGUI>();
        goldTextObject = GameObject.Find("Gold");
        goldText = goldTextObject.GetComponent<TextMeshProUGUI>();
        currentGoldCount = PlayerPrefs.GetInt("Gold");
        RefreshInventory();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryText.enabled = true;
            goldText.enabled = true;
            inventoryTitle.enabled = true;
            DisplayInventory();
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventoryText.enabled = false;
            goldText.enabled = false;
            inventoryTitle.enabled = false;

        }
        PlayerPrefs.SetInt("Gold", currentGoldCount);
        goldText.text = "" + PlayerPrefs.GetInt("Gold");
        
    }

    void DisplayInventory()
    {
        // Dictionary to store item counts
        Dictionary<int, int> itemCounts = GetItemCounts();

        // Update the inventoryText based on the itemCounts dictionary
        //goldText.text = "Gold: ";

        inventoryText.text = string.Join("\n", itemCounts.Select(pair =>
            $"{PurchasableItems.itemRegistry[pair.Key].name} x{pair.Value}"));
    }

    public Dictionary<int, int> GetItemCounts()
    {
        Dictionary<int, int> itemCounts = new Dictionary<int, int>();

        for (int i = 0; i < inventory.Count; i++)
        {
            int itemId = inventory[i];

            // Check if the item is already in the dictionary
            if (itemCounts.ContainsKey(itemId))
            {
                // Increment the count
                itemCounts[itemId]++;
            }
            else
            {
                // Add the item to the dictionary with count 1
                itemCounts[itemId] = 1;
            }
        }
        return itemCounts;
    }

    private void RefreshInventory()
    {
        int numHealthPotions = PlayerPrefs.GetInt("NumHealthPotions");
        if (numHealthPotions > 0)
        {
            for (int i = 0; i < numHealthPotions; i++)
            {
                inventory.Add(0);
            }
        }
        int numStrengthPotions = PlayerPrefs.GetInt("NumStrengthPotions");
        if (numStrengthPotions > 0)
        {
            for (int i = 0; i < numStrengthPotions; i++)
            {
                inventory.Add(1);
            }
        }
        int numSpeedPotions = PlayerPrefs.GetInt("NumSpeedPotions");
        if (numSpeedPotions > 0)
        {
            for (int i = 0; i < numSpeedPotions; i++)
            {
                inventory.Add(2);
            }
        }
        int numJumpPotions = PlayerPrefs.GetInt("NumJumpPotions");
        if (numJumpPotions > 0)
        {
            for (int i = 0; i < numJumpPotions; i++)
            {
                inventory.Add(3);
            }
        }
        int numFirePotions = PlayerPrefs.GetInt("NumFirePotions");
        if (numFirePotions > 0)
        {
            for (int i = 0; i < numFirePotions; i++)
            {
                inventory.Add(5);
            }
        }
    }
}


