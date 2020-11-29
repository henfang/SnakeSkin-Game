using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    public Loading loadCheck;

    public float timeBetweenShots;
    private float shotTime;

    void Start()
    {
        loadCheck = GameObject.FindObjectOfType<Loading>();
    }

    void Update()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        if (Input.GetMouseButton(0))
        {
            if (loadCheck.Loaded)
            {
                if (Time.time >= shotTime)
                {
                    SoundManager.PlaySound("playerAttack");
                    Instantiate(projectile, shotPoint.position, transform.rotation);
                    shotTime = Time.time + timeBetweenShots;
                }
            }
        }
    }
}
