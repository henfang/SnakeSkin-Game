using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    public Text banditScore;
    public Text gsScore;
    public Text snakeScore;
    public Text scorpionScore;

    ScorePasser scorePasser;

    void Start()
    {
        scorePasser = GameObject.FindObjectOfType<ScorePasser>();

        banditScore.text = "Bandits Killed: " + scorePasser.killCounterBandits.ToString();
        gsScore.text = "GunSlingers Killed: " + scorePasser.killCounterGunslingers.ToString();
        snakeScore.text = "Snakes Killed: " + scorePasser.killCounterSnakes.ToString();
        scorpionScore.text = "Scorpions Killed: " + scorePasser.killCounterScorpions.ToString();
    }


}
