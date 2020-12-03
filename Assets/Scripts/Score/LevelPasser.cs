using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPasser : MonoBehaviour
{
    public int floor = 1;

    public static LevelPasser instance = null;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void resetFloor()
    {
        floor = 1;
    }

    public void incrementFloor()
    {
        floor++;
    }
}
