using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Range(0, 20)]
    public float speedBuff;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Player.instance.SpeedUp(speedBuff);
            Destroy(gameObject);
        }
    }
}
