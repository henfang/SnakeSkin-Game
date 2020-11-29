using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{

    public bool Loaded = false;
    public bool ready = false;
    // Start is called before the first frame update
 

    // Update is called once per frame
    

    public void doneLoading()
    {
        ready = true;
    }

    public void Continue()
    {
        if (ready)
        {
            Loaded = true;
        }
    }


}
