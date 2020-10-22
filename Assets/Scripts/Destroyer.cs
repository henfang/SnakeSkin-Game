using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Destroys anything that collides with the Destroyer
public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("IsRoom"))
        {
            Destroy(other.gameObject);
        }
    }
}
