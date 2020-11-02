using System.Collections;
using UnityEngine;

public partial class Player
{
    float dashTime = 0.1f;  // Duration of the dash
    public float dashAmount = 10, dashCoolDown = 3; // The distance the dash reaches, and the cooldown neeed before next dash

    bool isDashing, canDash = true;

    public float distanceBetweenImages; // The amount of space between clone-spawns, it gives the effect of trailing 
    float lastImageXpos;    // Used for checking and comparing with distanceBetweenImages 

    IEnumerator dashCoroutine;

    // Handles the process of dashing, if no dashing is currently performed. 
    void startDashCoroutine()
    {
        if (dashCoroutine != null)
        {
            StopCoroutine(dashCoroutine);
        }
        dashCoroutine = dash();
        StartCoroutine(dashCoroutine);
    }


    void dashing()
    {
        if (get_Dash_Input() && canDash)
        {
            Player_AfterImagesPool.Instance.GetFromPool();
            lastImageXpos = transform.position.x;
            startDashCoroutine();
        }
    }

    void spawnClones()
    {
        // If the player can dash, and is in the process of dashing, Display a player-clone in the changing position of the player
        if (isDashing && dashTime > 0 && Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
        {
            Player_AfterImagesPool.Instance.GetFromPool();  // From the pre-created pool of clones
            lastImageXpos = transform.position.x;
        }
    }

    // Handles the process from start to finish of the dash
    IEnumerator dash()
    {
        // Before the dash
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashTime); // Once the dash begins, for the duration it is supposed to last
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(dashCoolDown); 
        // Once the duration of the dash is over, wait for the cooldown to finish before allowing for next dash
        canDash = true;
    }

}
