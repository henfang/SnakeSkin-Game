using UnityEngine;
using UnityEngine.UI;

public class InvUI : MonoBehaviour
{
    Inv inventory;
    GameObject invUI;
    
    Transform slotContainer;
    Transform itemTemplate;

    private void Awake() {
        slotContainer = transform.Find("slotsContainer");
        itemTemplate = slotContainer.Find("itemTemplate");
        invUI = GameObject.FindGameObjectWithTag("Inventory");
        invUI.SetActive(false);
    }
    internal void SetInventory(Inv inventory)
    {   
        this.inventory = inventory;
        inventory.OnItemChange += inventory_OnitemChange;
        refresh();
    }

    void inventory_OnitemChange(object sender, System.EventArgs eventArgs) {
        refresh();
    }

    public void setActive() {
        invUI.SetActive(!invUI.activeSelf);
    }

    void refresh() {
        foreach (Transform child in slotContainer) {
            if (child != itemTemplate) {
                Destroy(child.gameObject);
            } 
        }

        int row = 0;
        int col = 0;
        int xPos = 30;
        int yPos = -50;
        int spacing = 15;
        float itemCellSize = 30f;

        foreach (Item item in inventory.GetItems())
        {
            RectTransform newItem = Instantiate(itemTemplate, slotContainer).GetComponent<RectTransform>();
            newItem.gameObject.SetActive(true);
            newItem.anchoredPosition = new Vector2(xPos + (row * (itemCellSize + spacing)), yPos - (col * (itemCellSize + spacing)));

            Image image = newItem.Find("Image").GetComponent<Image>();
            image.sprite = item.GetSprite();
            image.transform.localScale = new Vector3(5, 5, 5);

            row++;
            if (row > 4) {
                row = 0;
                col++;
            }
        }
    }
}
