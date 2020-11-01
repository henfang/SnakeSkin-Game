using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Range(0, 20)]
    public float speedBuff;

    GameObject inventory;
    Item item;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    void handleSpeedBuff() {
        Player.instance.SpeedUp(speedBuff);
        Player.instance.addSpeedBuffToInventory();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            handleSpeedBuff();
            Destroy(gameObject);
        }
    }
}
