using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
        addItemToInventory();
        //clearItem();
    }
}
