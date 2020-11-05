using System;
using System.Collections.Generic;

// Simple class to handle the items in the inventory
public class Inv
{
    List<Item> itemList;
    public event EventHandler OnItemChange;

    public Inv()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.Stackable())
        {
            bool isInInv = false;
            // Increment the item's quantity if its already in the inventory
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.quantity += item.quantity;
                    isInInv = true;
                }
            }
            // If the item is not in the inventory, then add it
            if (!isInInv)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }

        // When the player picks up an item, it will trigger the EventHandler 
        // which invokes its method in the InvUI.cs to force a re-draw of the inventory with the update
        OnItemChange?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItems()
    {
        return itemList;
    }

    // TODO: Can add extra methods such as removing an item from inventory on use, 
    //          or adding quantity of items  
}
