using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public List<HotbarSlot> slots;  // Assign slots in the Unity Inspector
    public Color selectedColor = Color.white;
    public Color unselectedColor = Color.black;

    private Dictionary<int, int> heldCounts = new Dictionary<int, int>();
    private int goldCount = 0;

    public WeaponSwitch weaponSwitch;

    private void Awake()
    {
        InitializeHeldCounts();
    }
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
        InitializeHeldCounts();
        UpdateHeldCounts();
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
        heldCounts[itemID] = count;
        UpdateHeldCounts();
    }

    private void UpdateHeldCounts()
    {
        for (int i = 1; i < slots.Count - 1; i++)
        {
            //int itemID = slots[i].GetItemID();
            slots[i].AddItem(slots[i].itemImage.sprite, heldCounts[i], i);
        }
        //Debug.Log("Held count for ID 5: " + GetHeldCount(5));
    }

    public int GetHeldCount(int itemID)
    {
        return heldCounts.ContainsKey(itemID) ? heldCounts[itemID] : 0;
    }

    public Dictionary<int, int> GetHeldCounts()
    {
        return heldCounts;
    }
    public int GetGold()
    {
        return goldCount;
    }

    private void InitializeHeldCounts()
    {
        heldCounts[1] = PlayerPrefs.GetInt("NumFirePotions");
        heldCounts[2] = PlayerPrefs.GetInt("NumStrengthPotions");
        heldCounts[3] = PlayerPrefs.GetInt("NumSpeedPotions");
        heldCounts[4] = PlayerPrefs.GetInt("NumJumpPotions");
        heldCounts[5] = PlayerPrefs.GetInt("NumHealthPotions");
        heldCounts[6] = PlayerPrefs.GetInt("NumFreezePotions");
        heldCounts[7] = PlayerPrefs.GetInt("NumPoisonPotions");
        weaponSwitch.InitializeHeldCounts();
    }
}
