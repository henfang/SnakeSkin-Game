using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public partial class Player
{

    void DrawHealthBar()
    {
        //If the player gains more hearts than allowed set back to max
        if (currentHearts > totalHearts) 
        {
            currentHearts = totalHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            //Show correct heart status
            if (i < currentHearts) 
            {
                hearts[i].sprite = fullHeart;
            } 
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < totalHearts) 
            {
                hearts[i].enabled = true;
            } 
            else
            {
                hearts[i].enabled = false;
            }
        }

        //If the player runs out of hearts send them back to spawn with full health
        if (currentHearts <= 0)
        {
            currentHearts = totalHearts;
            Respawn();
        }
    }

    public void Heal()
    {
        currentHearts += 1;
    }
}
