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


    void Start()
    {
        Debug.Log(inventory.Count);
        inventoryTitleObject = GameObject.Find("Inventory");
        inventoryTitle = inventoryTitleObject.GetComponent<TextMeshProUGUI>();
        inventoryTextObject = GameObject.Find("Inventory List");
        inventoryText = inventoryTextObject.GetComponent<TextMeshProUGUI>();
        goldTextObject = GameObject.Find("Gold");
        goldText = goldTextObject.GetComponent<TextMeshProUGUI>();
        currentGoldCount = startingGoldCount;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryText.enabled = true;
            inventoryTitle.enabled = true;
            DisplayInventory();
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventoryText.enabled = false;
            inventoryTitle.enabled = false;

        }

        goldText.text = "" + currentGoldCount;
    }

    void DisplayInventory()
    {
        // Dictionary to store item counts
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

        // Update the inventoryText based on the itemCounts dictionary
        //goldText.text = "Gold: ";
        
        inventoryText.text = string.Join("\n", itemCounts.Select(pair =>
            $"{PurchasableItems.itemRegistry[pair.Key].name} x{pair.Value}"));
    }


}


