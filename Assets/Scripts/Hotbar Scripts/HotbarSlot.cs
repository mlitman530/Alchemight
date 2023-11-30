using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class HotbarSlot
{
    public Image background;   // Reference to the background image
    public Image itemImage;    // Reference to the item image
    public TMP_Text heldCountText; // Reference to the UI text for held count

    private int itemID;         // Added field to store the item ID

    public void ResetSlot()
    {
        // Reset slot to initial state
        if (background != null)
        {
            background.enabled = true;
            SetSelected(Color.black);  // Set default unselected color
        }

        if (itemImage != null)
        {
            itemImage.enabled = true;
            //itemImage.sprite = null;
            itemImage.color = Color.white;  // Set the color to white
        }

        if (heldCountText != null)
        {
            heldCountText.text = "";  // Reset held count text
        }

        itemID = 0;  // Reset item ID
    }

    public bool IsOccupied()
    {
        return itemImage != null && itemImage.enabled;
    }

    public void AddItem(Sprite itemSprite, int heldCount, int id)
    {
        itemID = id;  // Set item ID

        if (itemImage != null)
        {
            // Set item image and make it visible
            itemImage.sprite = itemSprite;
            itemImage.enabled = true;

            // Set the color of the item image to white
            itemImage.color = Color.white;
        }

        if (background != null)
        {
            // Background remains visible
            background.enabled = true;
        }

        if (heldCountText != null)
        {
            // Set held count text
            heldCountText.text = "x" + heldCount;
        }
    }

    public void SetSelected(Color color)
    {
        if (background != null)
        {
            background.color = color;
        }
    }

    public int GetItemID()
    {
        return itemID;
    }
}
