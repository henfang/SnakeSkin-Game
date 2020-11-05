using UnityEngine;
using UnityEngine.UI;

public class InvUI : MonoBehaviour
{
    Inv inventory;
    GameObject invUI;
    
    Transform slotContainer;
    Transform itemTemplate;

    // Find the location of the inventory canvas in the hierarchy 
    private void Awake() {
        slotContainer = transform.Find("slotsContainer");
        itemTemplate = slotContainer.Find("itemTemplate");
        invUI = GameObject.FindGameObjectWithTag("Inventory");
        invUI.SetActive(false); // initially start the game with inventory toggled off
    }

    // Initialize a link between the player and inventory
    internal void SetInventory(Inv inventory)
    {   
        this.inventory = inventory;

        // Handle inventory updates and force refresh when needed
        inventory.OnItemChange += inventory_OnitemChange;
        Refresh();
    }

    // EventHandler
    void inventory_OnitemChange(object sender, System.EventArgs eventArgs) {
        Refresh();
    }

    // Toggles inventory to become active or inactive
    public void setActive() {
        invUI.SetActive(!invUI.activeSelf);
    }

    // TODO: limit number of colums, thus giving set size of the inventory
    //          - could add a check before creating the newItem, and breaking from the loop if reached.
    void Refresh() {
        foreach (Transform child in slotContainer) {
            if (child != itemTemplate) {
                Destroy(child.gameObject);
            } 
        }

        // Create the cells in the inventory
        int row = 0;        // used for limiting the number of cells a row can have 
        int col = 0;        // used for limiting the number of rows in the inventory
        int xPos = 40;      // starting location of the first cell in the canvas
        int yPos = -50;     // starting location of the first cell in the canvas
        int spacing = 130;   // space between each cell in the (x) and (y) direction

        int cells = 4;              // for easier adjustment of the number of cells 
        float itemCellSize = 80f;   // size of each cell
        int imageSize = 10;

        foreach (Item item in inventory.GetItems())
        {
            // Create a new game object within the container for slots, in the form of the item template previously created
            // Then set its position in the canvas
            RectTransform newItem = Instantiate(itemTemplate, slotContainer).GetComponent<RectTransform>();
            newItem.gameObject.SetActive(true);
            newItem.anchoredPosition = new Vector2(xPos + (row * (itemCellSize + spacing)), yPos - (col * (itemCellSize + spacing)));

            // Create a child to hold the image of the item that will be displayed in the inventory slot
            Image image = newItem.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            image.transform.localScale = new Vector3(imageSize, imageSize, imageSize);

            // Update the Text of items in the inventory, depending on quantity 
            Text text = newItem.Find("itemText").GetComponent<Text>();
            if (item.quantity > 1) {
                text.text = item.quantity.ToString();
            } else {
                text.text = "";
            }

            // Inventory size check 
            row++;
            if (row > cells) {
                row = 0;
                col++;
            }
        }
    }
}
