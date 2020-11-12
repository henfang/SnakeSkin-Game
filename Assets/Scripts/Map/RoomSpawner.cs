using UnityEngine;

// Spawns a room on a Spawn Point
public class RoomSpawner : MonoBehaviour
{
    // 1 means need bottom door is needed
    // 2 means need left door is needed
    // 3 means need top door is needed
    // 4 means need right door is needed
    public int openingDirection;

    // Variable that stores all the possible rooms that can be spawned
    private RoomTemplates templates;
    // Variable to store a random integer
    private int rand;
    // Variable that remembers whether this spawn point has already spawned an object or not
    private bool spawned = false;

    public float waitTime = 4f;

    void Start()
    {
        // Declutter spawnPoints
        Destroy(gameObject, waitTime);
        // templates contains all the different types of rooms that can be spawned
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        // Calls Spawn() every 0.1 seconds
        Invoke("Spawn", 0.1f);
    }

    // Spawns a room on a Spawn Point based on which door requirement is needed
    void Spawn()
    {
        if (spawned == false) {
            // If we need a bottom door
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            // If we need a left door
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            // If we need a top door
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            // If we need a right door
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            // Something has been spawned, remember that
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Close off any paths that lead to nowhere with a closed room
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && !spawned)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
