using UnityEngine;

public class BigGreenShootingScript : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots = 2;
    private float shotTime;

    void FixedUpdate()
    {        
        if (Time.time >= shotTime)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            shotTime = Time.time + timeBetweenShots;
        }
    }
}
