using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    void Animate() {
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        } 
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
