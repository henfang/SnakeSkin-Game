using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class EnemyCollision : MonoBehaviour
{
    KillManager killManager;

    void Start()
    {
        killManager = GameObject.FindObjectOfType<KillManager>();
    }

    private void Update()
    {
        DrawEnemyHealthBar();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            EnemyDamage();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player.instance.GetHurt();
        }
    }
}
