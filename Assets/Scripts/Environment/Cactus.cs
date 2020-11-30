using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.instance.GetHurt();
        }
    }
}
