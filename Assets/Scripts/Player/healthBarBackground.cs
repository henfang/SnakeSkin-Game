using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarBackground : MonoBehaviour
{
    Vector3 localScale;

    void Start()
    {
        localScale = transform.localScale;
    }

    void Update()
    {
        localScale.x = Player.maxHealth / 50;
        transform.localScale = localScale;
    }
}
