using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    float dashTime = 0.1f;
    public float dashAmount = 10, dashCoolDown = 3;

    int dir;
    bool isDashing, canDash = true;

    public float distanceBetweenImages;
    float lastImageXpos;

    IEnumerator dashCoroutine, cameraCoroutine;
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
        if (isDashing && dashTime > 0 && Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
        {
            Player_AfterImagesPool.Instance.GetFromPool();
            lastImageXpos = transform.position.x;
        }
    }

    IEnumerator dash()
    {
        isDashing = true;
        canDash = false;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        rb.velocity = Vector2.zero;
        yield return new WaitForSecondsRealtime(dashCoolDown);
        canDash = true;
    }

}
