using UnityEngine;
using Pathfinding;

public class GunslingerScript : MonoBehaviour
{
    private Transform target;
    public float speed = 200;
    public float enemyRadius = 5f;
    private float nextPoint = 1f;
    private Vector2 origin;
    public Vector2 direction;

    int currentPoint = 0;
    bool endOfPath = false;

    Path currentPath;
    Seeker seeker;
    Rigidbody2D rigidbody;
    Animator anim;

    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots = 2;
    private float shotTime;

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
                EnemyAnimate(direction);
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

            if (Time.time >= shotTime)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotTime = Time.time + timeBetweenShots;
                }
        }

        if (d > enemyRadius) 
        {
            //If out of chase radius set variables to idle values
            anim.SetFloat("x", 0);
            anim.SetFloat("y", 0);
        }
    }
    
    void EnemyAnimate(Vector2 dir) 
    {
        anim.SetLayerWeight(1, 1);

        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
    }

}
