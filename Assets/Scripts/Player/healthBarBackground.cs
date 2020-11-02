using UnityEngine;

public class healthBarBackground : MonoBehaviour
{
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = Player.maxHealth / 100;
        transform.localScale = localScale;
    }
}
