using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemPurchase : MonoBehaviour
{
    private int itemId;
    public Inventory playerInventory;
    public PurchasableItems PurchasableItems;

    void Start()
    {
 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void getId() 
    {
        Item purchasedItem = GetComponentInChildren<Item>();

        itemId = purchasedItem.id;
        Debug.Log(itemId); 
    }

    private bool checkPurchaseLimit()
    {
        
        if (GetComponentInChildren<Item>().purchaseCount > GetComponentInChildren<Item>().purchaseLimit)
        {
            Debug.Log("Purchase Limit is reached");
            this.gameObject.GetComponent<Button>().interactable = false;
            return false;
        }
        else
        {
            Debug.Log("Increased Purchase Count");
            GetComponentInChildren<Item>().purchaseCount++;
   
        }
        return true;

    }

    private void addItemToInventory()
    {
        playerInventory.inventory.Add(itemId);
        Debug.Log("Inventory Count: " + playerInventory.inventory.Count);
        if (PurchasableItems.itemRegistry.ContainsKey(itemId))
        {
            GameObject itemObject = PurchasableItems.itemRegistry[itemId];
            Debug.Log("Item added to inventory: " + itemObject.name);
        }
        else
        {
            Debug.LogError("Item with itemId not found in the dictionary.");
        }
    }

    private void clearItem()
    {
        Destroy(gameObject);
    }

    public void clickAction()
    {
        getId();
        if (checkPurchaseLimit())
        {
            addItemToInventory();
        }
        //clearItem();
    }
}
