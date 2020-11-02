using System.Collections;
using UnityEngine;

public partial class Player
{
    public void GetHurt(float damage)
    {
        //If the player is invincible they won't take damage
        if (isInvincible) return;

        //Remove health
        currentHealth -= damage;

        //Start invincibility period
        StartCoroutine(StartTemporaryInvincible());
    }

    private IEnumerator StartTemporaryInvincible()
    {
        isInvincible = true;

        for (float i = 0; i < invincibleDurationSec; i += invincibleDeltaTime)
        {
            //Makes player flash
            if (model.transform.localScale == baseScale)
            {
                SetModelScale(Vector3.zero);
            }
            else
            {
                SetModelScale(baseScale);
            }
            yield return new WaitForSeconds(invincibleDeltaTime);
        }

        //Set the player back to default state after invincibility period
        SetModelScale(baseScale);
        isInvincible = false;
    }
}