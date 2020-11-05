using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    [Range(0, 100)]
    public float heal;

    void handleHealthPotion() {
        Player.instance.HealthPotion(heal);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            handleHealthPotion();
            Destroy(gameObject);
        }
    }
}
