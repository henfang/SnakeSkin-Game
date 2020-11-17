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

    // Boss room with door on the right
    public GameObject[] bossRoomsRight;
    // Remembers if a boss room has been spawned or not
    public bool bossRoomSpawned = false;
    // Chance of a boss room spawning at a given moment
    public int bossRoomSpawnChance = 1;


    // List of all rooms spawned
    public List<GameObject> rooms;

  
}
