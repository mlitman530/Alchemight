using UnityEngine;
using Cinemachine;

/// <summary>
/// Cinemachine extension to override camera orientation values
/// </summary>
public class CinemachinePOVExtension : CinemachineExtension
{
    private float horizontalSpeed;
    private float verticalSpeed;
    [SerializeField, Tooltip("Maximum angle at which the player can look up and down")]
    private float clampAngle = 80f;
    

    private InputManager inputManager;
    private Vector3 startingRotation;

    protected override void Awake() {
        inputManager = InputManager.Instance;
        startingRotation = transform.localRotation.eulerAngles;
        base.Awake();
        horizontalSpeed = PlayerPrefs.GetFloat("Saved Mouse Sensitivity") + 25;
        verticalSpeed = PlayerPrefs.GetFloat("Saved Mouse Sensitivity") + 25;
    }

    /// <summary>
    /// Called after the end of each stage.
    /// Here we override the orientation of the camera 
    /// </summary>
    /// <param name="vcam">Virtual camera</param>
    /// <param name="stage">What stage the pipeline is currently on</param>
    /// <param name="state">The output of the Cinemachine engine for a specific virtual camera. We won't be using this. </param>
    /// <param name="deltaTime">Current delta time. We won't be using this.</param>
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime) {
        if (Application.IsPlaying(gameObject) && vcam.Follow) { 
            if (stage == CinemachineCore.Stage.Aim) {
                // Debug.Log("Horizontal speed: " + horizontalSpeed);
                // Debug.Log("Vertical speed: " + verticalSpeed);
                // Get input system mouse delta values and add them to the starting rotation along with speed
                Vector2 deltaInput = inputManager.GetMouseDelta();
                startingRotation.x += deltaInput.x * horizontalSpeed * Time.deltaTime;
                startingRotation.y += deltaInput.y * verticalSpeed * Time.deltaTime;
                // Clamp the values to make sure the player can't keep looking up (it would rotate over their head)
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                // Rotate the orientation of the camera to match the new delta values.
                // If you look sideways, you need to rotate it on the Y axis, 
                // thus put startingRotation.y in the x value for Euler calculation.
                // We add a negative in front of startingRotation.y to invert the axis.
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

    public void SetSensitivity(float val)
    {
        horizontalSpeed = val + 25;
        verticalSpeed = val + 25;
        Debug.Log("Sensitivity Set to " + (val + 25));
    }
}
