using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public Loading loadCheck;
    public GameObject LoadScreen;

    // Start is called before the first frame update
    void Start()
    {
        loadCheck = GameObject.FindObjectOfType<Loading>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loadCheck.Loaded)
        {
            Destroy(LoadScreen);
        }
    }
}
