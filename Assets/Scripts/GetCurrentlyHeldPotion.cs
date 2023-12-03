using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCurrentlyHeldPotion : MonoBehaviour
{
    // Start is called before the first frame update

    public WeaponSwitch weaponSwitch;
    public Item currentItem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Item getCurrentItem()
    {
        currentItem = weaponSwitch.getCurrentItem();
        return currentItem;
    }
}
