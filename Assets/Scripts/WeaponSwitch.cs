using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Start is called before the first frame update

    public Item[] inventory;
    private Item currentItem;
    private int currentItemIndex;
    void Start()
    {
        inventory = GetComponentsInChildren<Item>();
        foreach(Item item in inventory)
        {
            item.deactivateItem();
        }

        itemInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void itemInitialize()
    {
        if (inventory != null && inventory.Length > 0)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i].id == 0)
                {
                    inventory[i].activateItem();
                    currentItem = inventory[i];
                    currentItemIndex = i;
                    //Debug.Log("Item Initialized: " + currentItem.name + " at Index: " + currentItemIndex);
                }
                else
                {
                    inventory[i].deactivateItem(); // Ensure other items are deactivated
                }
            }
        }
    }


    public Item getCurrentItem()
    {
        return currentItem;
    }
    public int getCurrentItemIndex()
    {
        return currentItemIndex;
    }

    public void switchItem()
    {
       

        currentItemIndex = getCurrentItemIndex();


        // Deactivate the current item first
        getCurrentItem().deactivateItem();

        if (currentItemIndex + 1 < inventory.Length)
        {
            Debug.Log(currentItem);
            currentItemIndex += 1;
            currentItem = inventory[currentItemIndex];
            Debug.Log(currentItem);
            currentItem.activateItem();
        }
        else
        {
            currentItem = inventory[0];
            currentItemIndex = 0;
            currentItem.activateItem();
        }

        Debug.Log("Switched Item To: " + getCurrentItem());
    }


}
