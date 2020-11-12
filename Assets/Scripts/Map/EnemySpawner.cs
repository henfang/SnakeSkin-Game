using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // 1 spawns a basic enemy
    public int enemyID;

    // Variable to store all the things inside a room that can be spawned
    private EnemyTemplates enemyTemplates;
    // Variable to store a random integer
    private int rand;
    // Variable to store whether we spawn an object or not
    private int spawnNumber;
    // Variable that remembers whether this spawn point has already spawned an object or not
    private bool spawned = false;

    void Start()
    {
        // itemTemplates contains all the different types of objects that can be spawned in a room
        enemyTemplates = GameObject.FindGameObjectWithTag("Enemies").GetComponent<EnemyTemplates>();
        // Calls Spawn() every 0.1 seconds
        Invoke("Spawn", 0.1f);
    }

    // Spawns a room on a Spawn Point based on which door requirement is needed
    void Spawn()
    {
        if (spawned == false)
        {
            // Spawn basic enemies
            if (enemyID == 1)
            {
                rand = Random.Range(0, enemyTemplates.enemies.Length);
                GameObject obj = Instantiate(enemyTemplates.enemies[rand], transform.position, enemyTemplates.enemies[rand].transform.rotation);
            }

            // Something has been spawned, remember that
            spawned = true;
        }
    }
}
