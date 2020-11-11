using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    void handleHealthPotion()
    {
        Player.instance.Heal();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            handleHealthPotion();
            Destroy(gameObject);
        }
    }
}
