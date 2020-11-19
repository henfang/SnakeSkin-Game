using UnityEngine;

// Handle all Inputs here
public partial class Player
{
    float get_Horizontal_Input()
    {
        return Input.GetAxisRaw("Horizontal");
    }


    float get_Vertical_Input()
    {
        return Input.GetAxisRaw("Vertical");
    }


    bool get_Dash_Input()
    {
        return Input.GetKeyDown(KeyCode.LeftShift);
    }


    bool get_Inventory_Input()
    {
        return Input.GetKeyDown(KeyCode.B);
    }

}