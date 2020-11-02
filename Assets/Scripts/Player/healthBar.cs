using UnityEngine;

public class healthBar : MonoBehaviour
{
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = Player.currentHealth / 100;
        transform.localScale = localScale;
    }
}
