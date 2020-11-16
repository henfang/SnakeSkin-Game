using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillManager : MonoBehaviour
{
    public Text killText;
    int targetBanditKills;
    int killCounterBandits = 0;

    private GameObject[] bandits;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);

        bandits = GameObject.FindGameObjectsWithTag("Enemy");
        targetBanditKills = bandits.Length / 3;
        killText.text = "Bandits Killed: 0/" + targetBanditKills.ToString();
    }

    // Update number of bandit kills
    public void UpdateBanditKills()
    {
        if (killCounterBandits != targetBanditKills)
        {
            killCounterBandits++;
        }
        killText.text = "Bandits Killed: " + killCounterBandits.ToString() + "/" + targetBanditKills.ToString();
    }

    // Return whether or not the bandit kill goal has been reached
    public bool banditKillGoalReached()
    {

        if (killCounterBandits >= targetBanditKills)
        {
            return true;
        }
        return false;
    }
}
