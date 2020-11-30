using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private Vector2 targetPosition;
    private Vector3 directionToGo;

    void Start() {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        targetPosition = target.position;
        directionToGo = (target.position - transform.position).normalized;
    }

    void FixedUpdate () 
     {   
        transform.position += directionToGo * 10 * Time.deltaTime;
     }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
