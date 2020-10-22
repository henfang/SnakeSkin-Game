using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // 1 spawns a wall tile
    public int itemID;

    // Variable to store all the things inside a room that can be spawned
    private ObjectTemplates objectTemplates;
    // Variable to store a random integer
    private int rand;
    // Variable to store whether we spawn an object or not
    private int spawnNumber;
    // Variable that remembers whether this spawn point has already spawned an object or not
    private bool spawned = false;

    void Start()
    {
        // itemTemplates contains all the different types of objects that can be spawned in a room
        objectTemplates = GameObject.FindGameObjectWithTag("RoomObjects").GetComponent<ObjectTemplates>();
        // Calls Spawn() every 0.1 seconds
        Invoke("Spawn", 0.1f);
    }

    // Spawns a room on a Spawn Point based on which door requirement is needed
    void Spawn()
    {
        if (itemID == 2)
        {
            rand = Random.Range(0, objectTemplates.roomObjects.Length);
            GameObject obj = Instantiate(objectTemplates.roomObjects[rand], transform.position, objectTemplates.roomObjects[rand].transform.rotation);
            obj.AddComponent<BoxCollider2D>();
        }
        if (spawned == false)
        {
            spawnNumber = Random.Range(1, 10);
            // Spawn walls
            if (itemID == 1 && spawnNumber <= 5)
            {
                rand = Random.Range(0, objectTemplates.roomTiles.Length);
                GameObject obj = Instantiate(objectTemplates.roomTiles[rand], transform.position, objectTemplates.roomTiles[rand].transform.rotation);
                obj.AddComponent<BoxCollider2D>();
            }
            
            // Something has been spawned, remember that
            spawned = true;
        }
    }
}
