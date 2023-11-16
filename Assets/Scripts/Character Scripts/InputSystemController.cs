using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Simple player controller with smooth values read from Unity's Input System.
/// </summary>
[RequireComponent(typeof(CharacterController), typeof(PlayerInput))]
public class InputSystemController : MonoBehaviour
{
    [SerializeField, Tooltip("Player speed multiplier.")]
    private float playerSpeed = 10f;
    [SerializeField, Tooltip("How how the player should jump.")]
    private float jumpHeight = 3f;
    [SerializeField, Tooltip("Downwards force on the player.")]
    private float gravityValue = -18f;
    [SerializeField, Tooltip("Rotation Speed multiplier.")]
    private float rotationSpeed = 5f;
    [SerializeField, Tooltip("Animation blend speed multiplier.")]
    private float animationBlendDamp = .5f;
    [SerializeField, Tooltip("Input smooth damp speed.")]
    private float inputSmoothDamp = .1f;

    private PlayerInput playerInput;
    private Animator anim;
    private CharacterController controller;
    public GameObject sword;
    private Sword swordScript;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraTransform;

    // Reference to the player actions.
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction swingAction;
    // Reference to the animations and animation parameters.
    private int jumpAnimationId;
    private int blendAnimationParameterId;

    // Used for damping/smoothing the input vector.
    private Vector2 currentInputVector;
    private Vector2 animationVelocity;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        swordScript = sword.GetComponent<Sword>();
        if(swordScript != null)
        {
            Debug.Log("Sword Script Found");
        }
        //cameraTransform = Camera.main.transform;
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        swingAction = playerInput.actions["Swing"];
        jumpAnimationId = Animator.StringToHash("Jump");
        blendAnimationParameterId = Animator.StringToHash("Blend");

    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        Debug.Log("Grounded: " + groundedPlayer);

        // Remove downwards force when player is grounded.
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = moveAction.ReadValue<Vector2>();
        // Manually smooth the input over time since Unity's Input System does not do it automatically.
        currentInputVector = Vector2.SmoothDamp(currentInputVector, input, ref animationVelocity, inputSmoothDamp);
        Vector3 move = new Vector3(currentInputVector.x, 0, currentInputVector.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Changes the height position of the player.
        if ( jumpAction.triggered && groundedPlayer)
        {
            //anim.Play(jumpAnimationId);
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        // Set blending animation when player is moving.
        //anim.SetFloat (blendAnimationParameterId, input.sqrMagnitude, animationBlendDamp, Time.deltaTime);

        // Rotate the player depending on their input and camera direction.
        if (input != Vector2.zero) {
            float targetAngle = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, targetAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

        if (swingAction.triggered)
        {
            swordScript.Swing();
        }

    }
}