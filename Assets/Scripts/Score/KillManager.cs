using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillManager : MonoBehaviour
{
    public Loading loadCheck;

    public Text banditKillText;
    public Text gsKillText;
    public int targetBanditKills;
    public int targetGunSlingerKills;

    public int killCounterGunslingers = 0;
    public int killCounterBandits = 0;
    public int killCounterSnakes = 0;
    public int killCounterScorpions = 0;

    private GameObject[] bandits;
    private GameObject[] gunSlingers;

    public Text bossRoomMessage;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);

        banditKillText = GameObject.Find("BanditKillText").GetComponent<Text>();
        gsKillText = GameObject.Find("GSKillText").GetComponent<Text>();
        bossRoomMessage = GameObject.Find("bossMessage").GetComponent<Text>();

        bandits = GameObject.FindGameObjectsWithTag("Bandit");
        targetBanditKills = bandits.Length / 2;
        banditKillText.text = "Bandits Killed: 0/" + targetBanditKills.ToString();

        gunSlingers = GameObject.FindGameObjectsWithTag("GunSlinger");
        targetGunSlingerKills = gunSlingers.Length / 2;
        gsKillText.text = "GunSlingers Killed: 0/" + targetGunSlingerKills.ToString();
        loadCheck = GameObject.FindObjectOfType<Loading>();
        loadCheck.doneLoading();

    }

    private void Update()
    {
        UpdateScorePasser();
    }

    // Update number of bandit kills
    public void UpdateBanditKills()
    {
        if (killCounterBandits != targetBanditKills)
        {
            killCounterBandits++;
        }
        banditKillText.text = "Bandits Killed: " + killCounterBandits.ToString() + "/" + targetBanditKills.ToString();
        if (KillGoalReached())
        {
            bossRoomMessage.text = "Boss now available. Go to boss room.";
        }
    }

    // Update number of gunslinger kills
    public void UpdateGSKills()
    {
        if (killCounterGunslingers != targetGunSlingerKills)
        {
            killCounterGunslingers++;
        }
        gsKillText.text = "GunSlingers Killed: " + killCounterGunslingers.ToString() + "/" + targetGunSlingerKills.ToString();
        if (KillGoalReached())
        {
            bossRoomMessage.text = "Boss now available. Go to boss room.";
        }
    }

    // Update number of snake kills
    public void UpdateSnakeKills()
    {
        killCounterSnakes++;
    }

    // Update number of scorpion kills
    public void UpdateScorpionKills()
    {
        killCounterScorpions++;
    }

    public void UpdateScorePasser()
    {
        ScorePasser scorePasser = GameObject.Find("ScorePasser").GetComponent<ScorePasser>();
        scorePasser.killCounterBandits = killCounterBandits;
        scorePasser.killCounterGunslingers = killCounterGunslingers;
        scorePasser.killCounterScorpions = killCounterScorpions;
        scorePasser.killCounterSnakes = killCounterSnakes;
    }

    // Return whether or not the bandit kill goal has been reached
    public bool KillGoalReached()
    {

        if (killCounterBandits >= targetBanditKills && killCounterGunslingers >= targetGunSlingerKills)
        {
            return true;
        }
        return false;
    }
}
