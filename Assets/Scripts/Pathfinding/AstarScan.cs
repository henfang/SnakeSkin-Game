using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarScan : MonoBehaviour
{
    IEnumerator Start()
 {
     yield return new WaitForSeconds(0.5f);
     AstarPath.active.Scan();
 }
}
