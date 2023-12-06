using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// First person player controller using the new input system
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("Player speed multiplier.")]
    private float playerSpeed = 8f;
    [SerializeField, Tooltip("How how the player should jump.")]
    private float jumpHeight = 1f;
    [SerializeField, Tooltip("Downwards force on the player.")]
    private float gravityValue = -18f;
    [SerializeField, Tooltip("Rotation Speed multiplier.")]
    public float playerStrength = 10f;
    private float rotationSpeed = 5f;
    [SerializeField, Tooltip("Animation blend speed multiplier.")]
    private float animationBlendDamp = .5f;
    [SerializeField, Tooltip("Input smooth damp speed.")]
    private float inputSmoothDamp = .1f;
    [SerializeField]
    private float playerMaxHealth = 100;
    public float currentPlayerHealth;
    public Slider healthBar;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private InputManager inputManager;
    private Transform cameraTransform;
    private Vector2 currentInputVector;
    private Vector2 animationVelocity;

    private PauseMenu pauseMenu;

    private GameObject swordObject;
    private Sword sword;
    private GameObject weaponHolder;
    private WeaponSwitch weaponSwitcher;

    private PlayerController playerController;
    private SelectionManager selectionManager;
    private int currentlySelected = 0;
    private Item currentItem;
    private DrinkablePotion currentPotion;
    private ThrowablePotion throwablePotion;

    private int numAttempts;
    private void Awake()
    {
        swordObject = GameObject.FindGameObjectWithTag("Melee");

        weaponHolder = GameObject.Find("Weapon Holder");
        weaponSwitcher = weaponHolder.GetComponent<WeaponSwitch>();
        throwablePotion = GetComponent<ThrowablePotion>();
        sword = swordObject.GetComponent<Sword>();
        currentPlayerHealth = playerMaxHealth;
        //SetPlayerPrefs();
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        pauseMenu = GetComponentInChildren<PauseMenu>();
        //Debug.Log("Pause menu instance: " + pauseMenu);
        cameraTransform = Camera.main.transform;
        playerController = GetComponent<PlayerController>();
        selectionManager = playerController.gameObject.GetComponent<SelectionManager>();
        numAttempts = PlayerPrefs.GetInt("Attempts");
        SetStats();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        // Make sure the player's velocity isn't negative while on the ground
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Move the player with the new input system
        Vector2 movement = inputManager.GetPlayerMovement();
        // Manually smooth the input over time since Unity's Input System does not do it automatically.
        currentInputVector = Vector2.SmoothDamp(currentInputVector, movement, ref animationVelocity, inputSmoothDamp);
        Vector3 move = new Vector3(currentInputVector.x, 0f, currentInputVector.y);
        // Take the camera's orientation into consideration with the movement
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        // Reset the y axis in case it was changed in the previous calculation
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player..
        if (inputManager.PlayerJumpedThisFrame() && groundedPlayer)
        {
            // Kinematic equation
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            //Debug.Log("Jump");
        }
        // Add gravity and then move the player once again
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (inputManager.Paused())
        {
            if (pauseMenu.IsPaused())
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }

        if (inputManager.GetPlayerSwing() && !pauseMenu.IsPaused())
        {
            if (sword.isActiveAndEnabled)
            {
                sword.Swing();
            }
        }

        if (inputManager.GetPlayerDrink() && !pauseMenu.IsPaused())
        {
            currentItem = weaponSwitcher.getCurrentItem();
            Debug.Log(currentItem);

            if (currentItem.GetComponent<DrinkablePotion>() != null)
            {
                currentPotion = currentItem.GetComponent<DrinkablePotion>();

                currentPotion.drinkPotion();
            }
        }
        if (inputManager.GetPlayerThrow() && !pauseMenu.IsPaused())
        {
            currentItem = weaponSwitcher.getCurrentItem();
            //Debug.Log(currentItem);

            if (currentItem.GetComponent<DrinkablePotion>() == null)
            {
                throwablePotion.Throw();
            }
        }

        // if (inputManager.GetPlayerThrow())
        // {
        //     if (throwable.isActiveAndEnabled)
        //     {
        //         throwable.Throw();
        //     }
        // }

        if (inputManager.GetWeaponSwitch() && !pauseMenu.IsPaused())
        {
            // weaponSwitcher.switchItem(true);
        }

        float scrollValue = inputManager.GetWeaponScroll();
        if (scrollValue > 0 && !pauseMenu.IsPaused())
        {
            selectionManager.ScrollUp();
            if (currentlySelected <= 0)
            {
                currentlySelected = 8;
                weaponSwitcher.switchItem(8);
            }
            else
            {
                currentlySelected--;
                weaponSwitcher.switchItem(currentlySelected);
            }
        }
        else if (scrollValue < 0 && !pauseMenu.IsPaused())
        {
            selectionManager.ScrollDown();
            if (currentlySelected >= 8)
            {
                currentlySelected = 0;
                weaponSwitcher.switchItem(0);
            }
            else
            {
                currentlySelected++;
                weaponSwitcher.switchItem(currentlySelected);
            }
        }
        float hotbarKey = inputManager.GetHotbarSwitch();
        if (hotbarKey > 0 && !pauseMenu.IsPaused())
        {
            currentlySelected = (int)hotbarKey - 1;
            selectionManager.UpdateSelection(hotbarKey - 1);
            weaponSwitcher.switchItem((int)hotbarKey - 1);
        }
    }

    public void SetStats()
    {
        if (numAttempts == 0)
        {
            playerStrength += PlayerPrefs.GetInt("Strength") + PlayerPrefs.GetInt("StrengthAddition");
            playerSpeed += PlayerPrefs.GetInt("Speed") + PlayerPrefs.GetInt("SpeedAddition");
            jumpHeight += (PlayerPrefs.GetInt("Jump") / 5) + PlayerPrefs.GetInt("JumpAddition") + 1;
            playerMaxHealth += (PlayerPrefs.GetFloat("MaxHealth") * 10) + PlayerPrefs.GetInt("HealthAddition");
        }
        else
        {
            playerStrength += PlayerPrefs.GetInt("StrengthAddition");
            playerSpeed += PlayerPrefs.GetInt("SpeedAddition");
            jumpHeight += PlayerPrefs.GetInt("JumpAddition") + 1;
            playerMaxHealth += PlayerPrefs.GetInt("HealthAddition");
        }

        Debug.Log("Strength: " + playerStrength + " Speed: " + playerSpeed + " Jump: " + jumpHeight);
        PlayerPrefs.SetInt("Strength", (int)playerStrength);
        PlayerPrefs.SetInt("Speed", (int)playerSpeed);
        PlayerPrefs.SetInt("Health", (int)playerMaxHealth);
        PlayerPrefs.SetInt("Jump", (int)jumpHeight);
    }

    public void ApplyStats(int strength, int speed, int jump, int health)
    {
        playerStrength = strength;
        playerSpeed = speed;
        jumpHeight = jump;
        playerMaxHealth = health;
    }

    /*public void SetDefaultStats()
    {
       
    }*/

    public Dictionary<string, float> GetStats()
    {
        Dictionary<string, float> stats = new Dictionary<string, float>();
        stats.Add("Strength", playerStrength);
        stats.Add("Speed", playerSpeed);
        stats.Add("Jump", jumpHeight);
        stats.Add("MaxHealth", playerMaxHealth); // Swapping jump and max health could be causing a bug
        return stats;
    }

    private void SetPlayerPrefs()
    {
        PlayerPrefs.SetInt("NumHealthPotions", 0);
        PlayerPrefs.SetInt("NumStrengthPotions", 0);
        PlayerPrefs.SetInt("NumSpeedPotions", 0);
        PlayerPrefs.SetInt("NumJumpPotions", 0);
        PlayerPrefs.SetInt("SwordPurchased", 0);
        PlayerPrefs.SetInt("NumFirePotions", 0);
        PlayerPrefs.SetInt("NumFreezePotions", 0);
        PlayerPrefs.SetInt("NumPoisonPotions", 0);
        PlayerPrefs.SetInt("NumNukePotions", 0);
    }

    public void TakeDamage(float damage)
    {

        currentPlayerHealth -= damage;
        healthBar.value = currentPlayerHealth;
        if (currentPlayerHealth <= 0)
        {
            // TODO: SHOW DEATH SCENE
            GetComponent<Collider>().enabled = false;
        }
    }

    public int GetNumAttempts()
    {
        return numAttempts;
    }
}
