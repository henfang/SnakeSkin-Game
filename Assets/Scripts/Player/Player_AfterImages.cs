using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AfterImages : MonoBehaviour
{
    Transform player;
    SpriteRenderer sr;

    float activeTime = 0.1f;
    float timeActivated;
    float alpha;
    float alphaSet = 0.8f;
    float alphaMultiplier = 0.85f;
    Color color;

    private void OnEnable()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        alpha = alphaSet;

        transform.position = player.position;
        transform.rotation = player.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1, 1, 1, alpha);
        foreach (SpriteRenderer child in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            child.color = color;
        }
        
        if (Time.time >= (timeActivated + activeTime))
        {
            Player_AfterImagesPool.Instance.AddToPool(gameObject);
        }
    }
}
