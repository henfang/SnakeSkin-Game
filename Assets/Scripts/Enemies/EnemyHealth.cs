using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class EnemyCollision
{
    public int currentHealth;
    public int totalHealth;
    public int damage = 1;

    void DrawEnemyHealthBar()
    {
        //If an enemy runs out of health destroy them
        if (currentHealth <= 0)
        {
            SoundManager.PlaySound("enemyDeath");
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
            else if (gameObject.tag == "BigGreen")
            {
                Debug.Log("123");
                FindObjectOfType<GameManager>().WinScreen();
            }
            Destroy(gameObject);
        }
    }

    public void EnemyDamage()
    {
        SoundManager.PlaySound("damage");
        currentHealth -= damage;
    }
}
