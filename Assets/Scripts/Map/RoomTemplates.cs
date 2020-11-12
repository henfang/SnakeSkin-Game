using System.Collections.Generic;
using System.Threading;
using UnityEngine;

// Stores all the possible rooms that can be spawned
public class RoomTemplates : MonoBehaviour
{
    // Array of all the rooms with a door on the bottom
    public GameObject[] bottomRooms;
    // Array of all the rooms with a door on the top
    public GameObject[] topRooms;
    // Array of all the rooms with a door on the left
    public GameObject[] leftRooms;
    // Array of all the rooms with a door on the right
    public GameObject[] rightRooms;

    // A filled in room with no interior
    public GameObject closedRoom;

    // List of all rooms spawned
    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;


    void Update()
    {
        if (waitTime <= 0 && !spawnedBoss)
        {
            Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
        
}
