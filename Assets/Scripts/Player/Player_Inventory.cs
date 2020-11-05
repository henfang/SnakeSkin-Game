using UnityEngine;

public partial class Player {
    
    Inv inventory;
    [SerializeField] InvUI inventoryUI;

    // Links the inventory to the player
    void setInventory() {
        inventory = new Inv();
        inventoryUI.SetInventory(inventory);
    }

    // TODO: change for later assignments :) 
    // Temporary speedBuff addition for testing purposes, when picking-up the RootBeers
    public void addSpeedBuffToInventory() {
        inventory.AddItem(new Item {itemType = Item.ItemType.SpeedBuff, quantity = 1 });
    }

    // Handles the Toggle On/Off of the inventory when the keyboard key "b" is pressed.
    void toggleInventory()
    {
        if (get_Inventory_Input())
        {
            inventoryUI.setActive();
        }
    }
}
