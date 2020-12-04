using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class EnemyCollision
{
    public int currentHealth;
    public int totalHealth;
    public int damage = 1;

    public GameObject powerUp;
    private int rand;

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

            // 40% chance of spawning a power up on death of enemy
            rand = Random.Range(1, 10);
            if (rand <= 4)
            {
                Instantiate(powerUp, transform.position, transform.rotation);
            }
        }
    }

    public void EnemyDamage()
    {
        SoundManager.PlaySound("damage");
        currentHealth -= damage;
    }
}
