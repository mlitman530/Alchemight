using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public List<HotbarSlot> slots;  // Assign slots in the Unity Inspector
    public Color selectedColor = Color.white;
    public Color unselectedColor = Color.black;

    private int nextAvailableSlot = 0;  // New variable to keep track of the next available slot

    private void Start()
    {
        // Ensure slots list is initialized properly
        if (slots == null)
        {
            Debug.LogError("Hotbar slots not assigned in the Inspector!");
            return;
        }

        // Initialize slots
        foreach (HotbarSlot slot in slots)
        {
            slot.ResetSlot();
        }

        // Initial selection
        UpdateSelection(0);
    }

    public void UpdateSelection(float selectedIndex)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i == selectedIndex)
            {
                slots[i].SetSelected(selectedColor);
            }
            else
            {
                slots[i].SetSelected(unselectedColor);
            }
        }
    }

    public int GetNumSlots()
    {
        return slots.Count;
    }

    public bool AddItem(Sprite itemImage)
    {
        if (nextAvailableSlot < slots.Count)
        {
            slots[nextAvailableSlot].AddItem(itemImage);
            nextAvailableSlot = (nextAvailableSlot + 1) % slots.Count;
            return true;
        }
        return false;  // No available slots
    }
}
