using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("The target player to follow.")]
    private Transform player;

    [SerializeField, Tooltip("The offset between the camera and the player.")]
    private Vector3 offset = new Vector3(0f, 5f, -7f);

    [SerializeField, Tooltip("Smoothness of the camera movement.")]
    private float smoothness = 5f;

    private void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference not set in the FollowPlayer script.");
            return;
        }

        // Calculate the desired position for the camera.
        Vector3 desiredPosition = player.position + offset;

        // Smoothly move the camera towards the desired position.
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothness * Time.deltaTime);

        // Make the camera look at the player.
        transform.LookAt(player);
    }
}
