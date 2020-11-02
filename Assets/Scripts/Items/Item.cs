using UnityEngine;

// Simple class to handle types of pick up items 
public class Item
{
    // Can extend this enum to handle all pick-ups 
    public enum ItemType {
        SpeedBuff,
        // HealthPotion
    }

    public ItemType itemType;

    // temporary variable to adjust the amount of speed that will be added to the buff when speedBuff is picked up
    // TODO: to be changed for more general usage when other types of pick-ups are added
    public int amount;  

    // Change sprites depending on the type of pick-up that has been encountered
    // This is used in the invUI.cs -> Refresh() when drawing the items in the inventory
    public Sprite GetSprite() {
        switch (itemType) {
            default:
                case ItemType.SpeedBuff: 
                    return ItemAssets.Instance.speedBuff;
                // case ItemType.HealthPotion: 
                //     return ItemAssets.Instance.healthPotion; 
        }
    }
}
