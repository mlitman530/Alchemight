using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Sprite itemImage;  // Set this in the Unity Inspector
    public int itemID;
    private HotbarManager hotbarManager;

    private void Start()
    {
        hotbarManager = FindObjectOfType<HotbarManager>();  // Find the HotbarManager
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment held count in the associated hotbar slot
            int heldCount = hotbarManager.GetHeldCount(itemID);
            hotbarManager.IncrementHeldCount(itemID, heldCount + 1);
            
            WeaponSwitch weaponSwitch = other.GetComponentInChildren<WeaponSwitch>();
            weaponSwitch.IncrementHeldCount(itemID);

            // Destroy the pickup object
            Destroy(gameObject);
        }
    }
}




