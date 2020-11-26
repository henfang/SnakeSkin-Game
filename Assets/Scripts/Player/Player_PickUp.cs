// Handle Pick-Ups here

using UnityEngine;

public partial class Player
{
    // Using temporary movement speed cap (30); default speed starts at 10
    public void SpeedUp(float amount) {
        if (movementSpeed + amount >= 20) {
            movementSpeed = 20;
        } else {
            movementSpeed = movementSpeed + amount;
        }
    }
}
