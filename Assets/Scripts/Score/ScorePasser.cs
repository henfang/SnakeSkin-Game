using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePasser : MonoBehaviour
{
    public int killCounterGunslingers = 0;
    public int killCounterBandits = 0;
    public int killCounterSnakes = 0;
    public int killCounterScorpions = 0;

    public static ScorePasser instance = null;

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

    public void ResetScore()
    {
        killCounterBandits = 0;
        killCounterGunslingers = 0;
        killCounterScorpions = 0;
        killCounterSnakes = 0;
    }
}
