using Unity.Properties;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Singleton for this class
    private static InputManager _instance;
    public Sword sword;

    public WeaponSwitch weaponSwitcher;
    private Item currentItem;
    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private Controls controls;
    private DrinkablePotion currentPotion;
    private ThrowablePotion throwablePotion;

    private void Awake()
    {
        // If there is another instance of this script, destroy this instance
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            // Assign this as an instance if one does not already exist
            _instance = this;
        }
        controls = new Controls();

        // Placed here to avoid making another script
        // Makes the cursor invisible while playing the game
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    /// <summary>
    /// Vector2 Composite values for movement
    /// </summary>
    /// <returns>Vector2, -1 if pressing left or down and 1 if pressing right or up</returns>
    public Vector2 GetPlayerMovement()
    {
        return controls.Sewers.Move.ReadValue<Vector2>();
    }

    public bool GetPlayerSwing()
    {
        return controls.Sewers.Swing.triggered;
    }

    public bool GetPlayerDrink()
    {
        return controls.Sewers.Drink.triggered;
    }

    public bool GetPlayerThrow()
    {
        return controls.Sewers.Throw.triggered;
    }

    /// <summary>
    /// Difference in mouse position from the current and previous frame
    /// </summary>
    /// <returns>Vector2 direction of mouse movement</returns>
    public Vector2 GetMouseDelta()
    {
        return controls.Sewers.Look.ReadValue<Vector2>();
    }

    /// <summary>
    /// Player has pressed jump button
    /// </summary>
    /// <returns>True if player jumped on this frame</returns>
    public bool PlayerJumpedThisFrame()
    {
        return controls.Sewers.Jump.triggered;
    }

    public bool Paused()
    {
        return controls.Sewers.Pause.triggered;
    }
    public bool GetWeaponSwitch()
    {
        return controls.Sewers.SwitchItem.triggered;
    }

    public void swing()
    {
        if (GetPlayerSwing())
        {
            
            sword.Swing();
        }
    }

    

    public void drink()
    {
       
        if (GetPlayerDrink())
        {
            currentItem = weaponSwitcher.getCurrentItem();
            Debug.Log(currentItem);

            if (currentItem.GetComponent<DrinkablePotion>() != null)
            {
                currentPotion = currentItem.GetComponent<DrinkablePotion>();

                currentPotion.drinkPotion();
            }
        }
    }

    public void Throw()
    {
        if (GetPlayerThrow())
        {
            throwablePotion.Throw();  
        }
    }
    public void switchItem()
    {
        // if (GetWeaponSwitch())
        // {
        //     weaponSwitcher.switchItem(true);
        // }
    }

    public float GetWeaponScroll()
    {
        return controls.Sewers.HotbarScroll.ReadValue<float>();
    }

    public float GetHotbarSwitch()
    {
        return controls.Sewers.HotbarSwitch.ReadValue<float>();
    }
}
