using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player {
    
    Inv inventory;
    [SerializeField] InvUI inventoryUI;

    void setInventory() {
        inventory = new Inv();
        inventoryUI.SetInventory(inventory);
    }

    public void addSpeedBuffToInventory() {
        inventory.AddItem(new Item {itemType = Item.ItemType.SpeedBuff, amount = 1 });
    }

    void toggleInventory()
    {
        if (get_Inventory_Input())
        {
            inventoryUI.setActive();
        }
    }
}
