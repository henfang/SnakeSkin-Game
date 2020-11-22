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

    // Capping off rooms
    public GameObject bottomClosed;
    public GameObject topClosed;
    public GameObject leftClosed;
    public GameObject rightClosed;

    // A filled in room with no interior
    public GameObject closedRoom;

    // Boss rooms
    public GameObject[] bossRoomsBottom;
    public GameObject[] bossRoomsTop;
    public GameObject[] bossRoomsRight;
    public GameObject[] bossRoomsLeft;

    // Remembers if a boss room has been spawned or not
    public bool bossRoomSpawned = false;
    // Boss room spawn location
    public int bossRoomSpawnPlace;


    // List of all rooms spawned
    public List<GameObject> rooms;

    // Variables to remember how many rooms have been spawned in each direction
    public int rightRoomCount = 0;
    public int leftRoomCount = 0;
    public int topRoomCount = 0;
    public int bottomRoomCount = 0;

    private void Start()
    {
        bossRoomSpawnPlace = Random.Range(1, 4);
    }


}
