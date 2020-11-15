using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private Vector2 origin;
    Rigidbody2D rigidbody;

    KillManager killManager;

    void Start()
    {
        killManager = GameObject.FindObjectOfType<KillManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            killManager.UpdateBanditKills();
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player.instance.GetHurt();
        }
    }
}
