using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyPath : MonoBehaviour
{
    public Transform target;
    public float speed = 200;
    public float enemyRadius = 6f;
    private float nextPoint = 1f;
    private Vector2 origin;

    int currentPoint = 0;
    bool endOfPath = false;

    Path currentPath;
    Seeker seeker;
    Rigidbody2D rigidbody;

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

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody = GetComponent<Rigidbody2D>();
        origin = rigidbody.position;

        InvokeRepeating("UpdatePath", 0f, 0.5f);
        seeker.StartPath(rigidbody.position, target.position, ifPathComplete);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float d = Vector2.Distance(rigidbody.position, target.position);
        if (d < enemyRadius) {
            if (currentPath == null) {
            return;
        }

        if (currentPoint >= currentPath.vectorPath.Count) {
            endOfPath = true;
            return;
        }
        else {
            endOfPath = false;
        }

        Vector2 direction = ((Vector2)currentPath.vectorPath[currentPoint] - rigidbody.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        rigidbody.AddForce(force);

        float distance = Vector2.Distance(rigidbody.position, currentPath.vectorPath[currentPoint]);

        if (distance < nextPoint) {
            currentPoint++;
        }
    }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball") {
           rigidbody.position = origin;
        }
    }
    
        
}
