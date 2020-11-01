using UnityEngine;

public class Inventory : MonoBehaviour
{
    GameObject inventory;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        inventory.SetActive(false);
    }

    void Update()
    {
        toggleInventory();
    }


    void toggleInventory()
    {
        if (get_Inventory_Input())
        {
            inventory.SetActive(!inventory.activeSelf);
        }
    }

    bool get_Inventory_Input()
    {
        return Input.GetKeyDown(KeyCode.B);
    }
}
