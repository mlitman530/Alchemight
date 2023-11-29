using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HotbarSlot
{
    public Image background;   // Reference to the background image
    public Image itemImage;    // Reference to the item image

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
            itemImage.enabled = false;
            itemImage.sprite = null;
            itemImage.color = Color.white;  // Set the color to white
        }
    }

    public bool IsOccupied()
    {
        return itemImage != null && itemImage.enabled;
    }

    public void AddItem(Sprite itemSprite)
    {
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
    }

    public void SetSelected(Color color)
    {
        if (background != null)
        {
            background.color = color;
        }
    }
}
