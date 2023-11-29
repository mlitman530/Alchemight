using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemImage;  // Set this in the Unity Inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HotbarManager hotbarManager = other.GetComponent<HotbarManager>();            
            bool itemAdded = hotbarManager.AddItem(itemImage);

            if (itemAdded)
            {
                // Item successfully added, destroy the pickup object
                Destroy(gameObject);
            }
        }
    }
}
