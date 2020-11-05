using UnityEngine;

// Simple class to handle types of pick up items 
public class Item
{
    // Can extend this enum to handle all pick-ups 
    public enum ItemType
    {
        SpeedBuff,
        HealthPotion,
        Shield
    }

    public ItemType itemType;

    // Counter for stackable items
    public int quantity;

    // Change sprites depending on the type of pick-up that has been encountered
    // This is used in the invUI.cs -> Refresh() when drawing the items in the inventory
    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.SpeedBuff:
                return ItemAssets.Instance.speedBuff;
            case ItemType.HealthPotion:
                return ItemAssets.Instance.healthPotion;
        }
    }

    // Specify which pick-up items are stackable and which are not 
    public bool Stackable()
    {
        switch (itemType)
        {
            default:
            case ItemType.SpeedBuff:
                return true;
            case ItemType.HealthPotion:
            case ItemType.Shield:
                return false;
        }
    }
}
