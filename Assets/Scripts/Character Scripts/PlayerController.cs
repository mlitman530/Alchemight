using UnityEngine;

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
    private float playerStrength = 10f;
    private float rotationSpeed = 5f;
    [SerializeField, Tooltip("Animation blend speed multiplier.")]
    private float animationBlendDamp = .5f;
    [SerializeField, Tooltip("Input smooth damp speed.")]
    private float inputSmoothDamp = .1f;

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
    private GameObject throwableObject;
    private Throwable throwable;
    private GameObject weaponHolder;
    private WeaponSwitch weaponSwitcher;

    private PlayerController playerController;
    private SelectionManager selectionManager;

    private void Awake()
    {
        swordObject = GameObject.FindGameObjectWithTag("Melee");
        throwableObject = GameObject.FindGameObjectWithTag("Projectile");
        weaponHolder = GameObject.Find("Weapon Holder");
        weaponSwitcher = weaponHolder.GetComponent<WeaponSwitch>();
        sword = swordObject.GetComponent<Sword>();
        throwable = throwableObject.GetComponent<Throwable>();
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
            //Debug.Log("pauseMenu.IsPaused: " + pauseMenu.IsPaused());
            if (pauseMenu.IsPaused())
            {
                pauseMenu.Resume();
            }
            else
            {
                pauseMenu.Pause();
            }
        }

        if (inputManager.GetPlayerSwing())
        {
            if (sword.isActiveAndEnabled)
            {
                sword.Swing();
            }
        }

        if (inputManager.GetPlayerThrow())
        {
            if (throwable.isActiveAndEnabled)
            {
                throwable.Throw();
            }
        }

        if (inputManager.GetWeaponSwitch())
        {
            weaponSwitcher.switchItem(true);
        }

        float scrollValue = inputManager.GetWeaponScroll();
        if (scrollValue > 0)
        {
            selectionManager.ScrollUp();
            weaponSwitcher.switchItem(false);
        }
        else if (scrollValue < 0)
        {
            selectionManager.ScrollDown();
            weaponSwitcher.switchItem(true);
        }
        float hotbarKey = inputManager.GetHotbarSwitch();
        if (hotbarKey > 0)
        {
            selectionManager.UpdateSelection(hotbarKey - 1);
        }
    }

    private void SetStats()
    {
        playerStrength += PlayerPrefs.GetInt("Strength");
        playerSpeed += PlayerPrefs.GetInt("Speed");
        jumpHeight += (PlayerPrefs.GetInt("Jump") / 5);
        //Debug.Log("Strength: " + playerStrength + " Speed: " + playerSpeed + " Jump: " + jumpHeight);
    }

    // private void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     IHotbarItem item = hit.collider.GetComponent<IHotbarItem>();
    //     Debug.Log("Item: " + item);
    //     if (item != null)
    //     {
    //         hotbar.AddItem(item);
    //     }
    // }
}
