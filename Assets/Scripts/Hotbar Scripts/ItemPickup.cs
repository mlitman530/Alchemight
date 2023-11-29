using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemImage;  // Set this in the Unity Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HotbarManager hotbarManager = other.GetComponent<HotbarManager>();

            Debug.Log("Hotbar manager: " + hotbarManager);
            
            if (hotbarManager != null)
            {
                // Attempt to add the item to the hotbar
                bool itemAdded = hotbarManager.AddItem(itemImage);

                if (itemAdded)
                {
                    // Item successfully added, destroy the pickup object
                    Destroy(gameObject);
                }
            }
        }
    }
}
