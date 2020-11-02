using UnityEngine;

public class Item
{
    public enum ItemType {
        SpeedBuff,
        // HealthPotion
    }

    public ItemType itemType;
    public int amount;

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
