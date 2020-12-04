using System.Collections;
using UnityEngine;

public class BigGreenShootingScript : MonoBehaviour
{
    public GameObject[] bullets;
    public Transform firePoint;
    public Transform[] aoeFirePoints;
    public float timeBetweenShots = 2;
    float shotTime;
    float attackTimer = 0f;
    public float AoeTimer = 5f;
    public float pause = 2f;

    Rigidbody2D rb;
    BanditScript bs;

    bool aoeAttack;
    bool movementAllowed;
    float oldSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bs = GetComponent<BanditScript>();
        attackTimer = AoeTimer;
        oldSpeed = bs.speed;
        movementAllowed = true;
    }

    void Update()
    {
        BasicAttack();
        AoeAttackCheck();
        MovementCheck();
    }

    void MovementCheck()
    {
        if (!movementAllowed)
        {
            bs.speed = 0f;
        }
        else
        {
            bs.speed = oldSpeed;
        }
    }

    void BasicAttack()
    {
        if (aoeAttack == false && Time.time >= shotTime)
        {
            Instantiate(bullets[0], firePoint.position, firePoint.rotation);
            shotTime = Time.time + timeBetweenShots;
        }
    }

    void AoeAttackCheck()
    {
        //found target, what now ?
        if (attackTimer <= 0f) attackTimer = AoeTimer; // wait 1 second before attacking

        //wait for attack
        if (attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0f)
            {
                aoeAttack = true;
            }
        }

        if (aoeAttack)
        {
            attackTimer = 0f; // reset cooldown
            aoeAttack = false;
            StartCoroutine("aoe");
        }
    }

    void AoeAttack()
    {
        for (int i = 0; i < aoeFirePoints.Length; i++)
        {
            Instantiate(bullets[1], aoeFirePoints[i].position, aoeFirePoints[i].rotation);
        }
    }

    IEnumerator aoe()
    {
        movementAllowed = false;
        AoeAttack();
        yield return new WaitForSeconds(pause);
        movementAllowed = true;
    }
}
