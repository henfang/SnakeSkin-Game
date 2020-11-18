using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class EnemyCollision
{
    public int currentHealth;
    public int totalHealth;

    void DrawEnemyHealthBar()
    {
        //If an enemy runs out of health destroy them
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            killManager.UpdateBanditKills();
        }
    }

    public void EnemyDamage()
    {
        currentHealth -= 1;
    }
}
