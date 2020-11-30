using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlate : MonoBehaviour
{
    BossSpawner bossSpawner;
    // Store the KillManager Object;
    private KillManager killManager;

    private GameObject[] doorSpawnPoints;

    void Start()
    {
        bossSpawner = GameObject.Find("BossSpawner").GetComponent<BossSpawner>();
        killManager = GameObject.FindGameObjectWithTag("KillManager").GetComponent<KillManager>();
        doorSpawnPoints = GameObject.FindGameObjectsWithTag("DoorSpawnPoint");
    }

    void BossSpawnSequence()
    {
        SoundManager.PlaySound("bossSpawn");
        foreach (GameObject spawnPoint in doorSpawnPoints)
        {
            spawnPoint.GetComponent<BossRoomDoorSpawn>().Spawn();
        }
        bossSpawner.SpawnBoss();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && killManager.KillGoalReached() && !bossSpawner.spawnedBoss)
        {
            BossSpawnSequence();
        }
    }
}
