using System;
using System.Collections.Generic;

public class Inv
{
    List<Item> itemList;
    public event EventHandler OnItemChange;
        
    public Inv() {
        itemList = new List<Item>();
    }

    public void AddItem(Item item) {
        itemList.Add(item);
        OnItemChange?.Invoke(this,EventArgs.Empty);
    }

    public List<Item> GetItems() {
        return itemList;
    }
}
