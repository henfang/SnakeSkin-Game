using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillCount : MonoBehaviour
{
    public GameObject killText;
    int killCounterBandits;
    // Start is called before the first frame update
    void Start()
    {
        killText = GameObject.FindWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
