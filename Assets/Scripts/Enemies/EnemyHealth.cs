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
            if (gameObject.tag == "Bandit") 
            { 
                killManager.UpdateBanditKills();
            }
            else if (gameObject.tag == "GunSlinger")
            {
                killManager.UpdateGSKills();
            }
            else if (gameObject.tag == "Snake")
            {
                killManager.UpdateSnakeKills();
            }
            else if (gameObject.tag == "Scorpion")
            {
                killManager.UpdateScorpionKills();
            }

        }
    }

    public void EnemyDamage()
    {
        currentHealth -= 1;
    }
}
