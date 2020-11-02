using System;
using System.Collections.Generic;

// Simple class to handle the items in the inventory
public class Inv
{
    List<Item> itemList;
    public event EventHandler OnItemChange;
        
    public Inv() {
        itemList = new List<Item>();
    }

    public void AddItem(Item item) {
        itemList.Add(item);

        // When the player picks up an item, it will trigger the EventHandler 
        // which invokes its method in the InvUI.cs to force a re-draw of the inventory with the update
        OnItemChange?.Invoke(this,EventArgs.Empty);
    }

    public List<Item> GetItems() {
        return itemList;
    }

    // TODO: Can add extra methods such as removing an item from inventory on use, 
    //          or adding quantity of items  
}
