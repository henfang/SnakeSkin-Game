using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpawnPoint") || other.gameObject.CompareTag("IsRoom"))
        {
            Destroy(other.gameObject);
        }
    }
}
