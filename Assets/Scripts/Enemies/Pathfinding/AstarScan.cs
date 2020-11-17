using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarScan : MonoBehaviour
{
    public float waitTime = 5.0f;
    IEnumerator Start()
 {
     yield return new WaitForSeconds(waitTime);
     AstarPath.active.Scan();
 }
}
