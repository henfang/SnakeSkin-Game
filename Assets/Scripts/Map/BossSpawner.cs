using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossSpawner : MonoBehaviour
{
    // Store the RoomTemplates Object
    private RoomTemplates roomTemplates;
    // Store the KillManager Object;
    private KillManager killManager;

    // Have we spawned a boss or not
    private bool spawnedBoss = false;
    // What boss to spawn
    public GameObject boss;
    // Minimum time to wait before spawning boss
    public float waitTime = 10.0f;

    void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        killManager = GameObject.FindGameObjectWithTag("KillManager").GetComponent<KillManager>();
    }


    void Update()
    {
        if (waitTime <= 0 && !spawnedBoss && killManager.KillGoalReached())
        {
            Instantiate(boss, GameObject.FindGameObjectWithTag("BossSpawnPoint").transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        waitTime -= Time.deltaTime;
    }
}
