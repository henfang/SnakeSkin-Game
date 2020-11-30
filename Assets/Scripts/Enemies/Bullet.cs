using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private Vector3 targetPosition;
    public float speed = 4f;
    private Vector2 direction; 

    void Start() {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        targetPosition = target.position;
        direction = (targetPosition - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
    }

    void FixedUpdate () 
     {  
         transform.Translate(Vector2.up * speed * Time.deltaTime);
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
