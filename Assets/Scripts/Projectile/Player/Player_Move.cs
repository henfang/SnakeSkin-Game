using UnityEngine;

public partial class Player
{
    Vector2 moveAmount, moveInput, moveDirection;

    public float movementSpeed = 10f;

    void Move(Vector2 moveInput)
    {
        update_Move_Input();
        
        // Check if player is dashing, and spawn clones for after images
        dashing();
        spawnClones(); 

        // The normalized grid movement of the player; 
        //  used to update player direction
        moveAmount = moveInput.normalized * movementSpeed;
    }


    /*
        moveInput is the grid direction the player is heading, before normalizing it. 
        Horizontal left == -1, and right == 1
        Vertical upwards == 1, and down == -1 
    */
    void update_Move_Input()
    {
        moveInput = new Vector2(get_Horizontal_Input(), get_Vertical_Input());
    }


    void updatePosition()
    {
        rb.MovePosition(updateDirection());
    }

    Vector2 updateDirection()
    {
        if (isDashing)
        {
            moveDirection = rb.position + (moveAmount * dashAmount) * Time.fixedDeltaTime;
        }
        else
        {
            moveDirection = rb.position + moveAmount * Time.fixedDeltaTime;
        }
        return moveDirection;
    }
}
