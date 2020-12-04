using UnityEngine;

public class NonTargetBullet : MonoBehaviour
{
    public float speed = 4f;
    public float lifeTime = 0.25f;

    Vector3 direction;
    public GameObject explosion;

    void Start()
    {
        direction = transform.right;
        Invoke("DestroyBullet", lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void DestroyBullet()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
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
