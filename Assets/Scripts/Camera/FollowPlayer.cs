using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Get player location reference;
    public Transform player;

    // The time it takes for the camera to reach the player
    public float dampTime = 0.4f;
    private Vector3 cameraPos;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Make new Vector in direction of the player
        cameraPos = new Vector3(player.position.x, player.position.y, -10f);

        // Update the position of the camera
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, cameraPos, ref velocity, dampTime);
    }
}
