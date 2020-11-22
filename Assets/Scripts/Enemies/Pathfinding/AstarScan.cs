using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AstarScan : MonoBehaviour
{
    public float waitTime = 5.0f;
    IEnumerator Start()
 {
<<<<<<< HEAD
     yield return new WaitForSeconds(waitTime);
=======
     // scan inital surroundings
     yield return new WaitForSeconds(0.5f);
>>>>>>> origin/master
     AstarPath.active.Scan();

     // scan rest of surroundings
     yield return new WaitForSeconds(5f);
     AstarPath.active.Scan();
 }
}
