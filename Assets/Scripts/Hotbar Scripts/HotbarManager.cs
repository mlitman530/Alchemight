using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public List<HotbarSlot> slots;  // Assign slots in the Unity Inspector
    public Color selectedColor = Color.white;
    public Color unselectedColor = Color.black;

    private Dictionary<int, int> heldCounts = new Dictionary<int, int>();

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

    public void IncrementHeldCount(int itemID, int count)
    {
        if (heldCounts.ContainsKey(itemID))
        {
            heldCounts[itemID] = count;
        }
        else
        {
            heldCounts.Add(itemID, count);
        }

        UpdateHeldCounts();
    }

    private void UpdateHeldCounts()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].IsOccupied())
            {
                int itemID = slots[i].GetItemID();
                if (heldCounts.ContainsKey(itemID))
                {
                    slots[i].AddItem(slots[i].itemImage.sprite, heldCounts[itemID], itemID);
                }
            }
        }
    }

    public int GetHeldCount(int itemID)
    {
        return heldCounts.ContainsKey(itemID) ? heldCounts[itemID] : 0;
    }
}
