using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomDoorSpawn : MonoBehaviour
{
    public int doorID;
    private ObjectTemplates objectTemplates;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4.0f);
        objectTemplates = GameObject.FindGameObjectWithTag("RoomObjects").GetComponent<ObjectTemplates>();
    }

    public void Spawn()
    {
        if (doorID == 1)
        {
            Instantiate(objectTemplates.bossNDoor, transform.position, objectTemplates.bossNDoor.transform.rotation);
        }
        else if (doorID == 2)
        {
            Instantiate(objectTemplates.bossEWDoor, transform.position, objectTemplates.bossEWDoor.transform.rotation);
        }
        else if (doorID == 3)
        {
            Instantiate(objectTemplates.bossSDoor, transform.position, objectTemplates.bossSDoor.transform.rotation);
        }
    }
}
