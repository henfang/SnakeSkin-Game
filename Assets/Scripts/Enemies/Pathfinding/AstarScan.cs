using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarScan : MonoBehaviour
{
    IEnumerator Start()
 {
     // scan inital surroundings
     yield return new WaitForSeconds(0.5f);
     AstarPath.active.Scan();

     // scan rest of surroundings
     yield return new WaitForSeconds(5f);
     AstarPath.active.Scan();
 }
}
