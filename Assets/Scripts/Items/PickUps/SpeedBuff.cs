using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    [Range(0, 20)]
    public float speedBuff;

    GameObject inventory;

    private void Start() {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    void handleSpeedBuff() {
        Player.instance.SpeedUp(speedBuff);         // Add the effect of the speed buff to the player

        // TODO: Consider having split the buffs to a tab of the inventory, meanwhile usable items or others in a different tab 
        Player.instance.addSpeedBuffToInventory();  // Add the buff to the inventory
    }

    // TODO: Create a check to see if the item has been picked up prior to destroying the item on the ground
    //          - in case the inventory is full
    //          - for this to happen, the inventory must be of set size (for more details see invUI.cs -> Refresh())  
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            handleSpeedBuff();
            Destroy(gameObject);
        }
    }
}
