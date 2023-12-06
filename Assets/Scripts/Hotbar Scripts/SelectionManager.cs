using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public HotbarManager hotbarManager;
    private int selectedItemIndex = 0;

    private void Start()
    {
        // Ensure hotbarManager is assigned
        if (hotbarManager == null)
        {
            //Debug.LogError("HotbarManager not assigned to SelectionManager!");
            return;
        }

        UpdateSelectionVisual();
    }

    // private void Update()
    // {
    //     float scrollValue = Input.GetAxis("Mouse ScrollWheel");

    //     if (scrollValue > 0)
    //     {
    //         ScrollUp();
    //     }
    //     else if (scrollValue < 0)
    //     {
    //         ScrollDown();
    //     }
    // }

    public void ScrollDown()
    {
        selectedItemIndex = (selectedItemIndex + 1) % hotbarManager.GetNumSlots();
        UpdateSelectionVisual();
    }

    public void ScrollUp()
    {
        selectedItemIndex = (selectedItemIndex - 1 + hotbarManager.GetNumSlots()) % hotbarManager.GetNumSlots();
        UpdateSelectionVisual();
    }

    public void UpdateSelection(float key)
    {
        hotbarManager.UpdateSelection(key);
    }

    private void UpdateSelectionVisual()
    {
        hotbarManager.UpdateSelection(selectedItemIndex);
    }
}
