using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class EnemyPath : MonoBehaviour
{
    private Transform target;
    public float speed = 200;
    public float enemyRadius = 5f;
    private float nextPoint = 1f;
    private Vector2 origin;
    private Vector2 direction;

    int currentPoint = 0;
    bool endOfPath = false;

    Path currentPath;
    Seeker seeker;
    Rigidbody2D rigidbody;
    Animator anim;

    void ifPathComplete(Path path) {
        if (!path.error) {
            currentPath = path;
            currentPoint = 0;
        }
    }

    void UpdatePath() {
        if (seeker.IsDone()) {
            seeker.StartPath(rigidbody.position, target.position, ifPathComplete);
        }
    }

    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        origin = rigidbody.position;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rigidbody.position, target.position, ifPathComplete);
    }

    void FixedUpdate()
    {
        float d = Vector2.Distance(rigidbody.position, target.position);
        if (d <= enemyRadius)
        {
            if (currentPath == null)
            {
                return;
            }

            if (currentPoint >= currentPath.vectorPath.Count)
            {
                endOfPath = true;
                return;
            }
            else
            {
            endOfPath = false;
            }

            direction = ((Vector2)currentPath.vectorPath[currentPoint] - rigidbody.position).normalized;
            Vector2 force = direction * speed * Time.fixedDeltaTime;

            if (direction.x != 0 || direction.y != 0)
            {
                //Animate bandit while chasing player
                banditAnimate(direction);
            }
            else
            {
                //If not chasing player set to bandit idle
                anim.SetLayerWeight(1, 0);
            }

            rigidbody.AddForce(force);

            float distance = Vector2.Distance(rigidbody.position, currentPath.vectorPath[currentPoint]);

            if (distance < nextPoint)
            {
                currentPoint++;
            }
        }

        if (d > enemyRadius) 
        {
            //If out of chase radius set variables to idle values
            anim.SetFloat("x", 0);
            anim.SetFloat("y", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball") {
           rigidbody.position = origin;
        }
        else if (collision.gameObject.tag == "Player")
        {
            Player.instance.GetHurt();
        }
    }
    
    void banditAnimate(Vector2 dir) 
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }
}
