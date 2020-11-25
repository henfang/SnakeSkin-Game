using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip damageSound, playerAttackSound, enemyDeathSound;
    static AudioSource audioSource;

    private void Start()
    {
        damageSound = Resources.Load<AudioClip>("Bloody punch");
        playerAttackSound = Resources.Load<AudioClip>("Magic Spell_Simple Swoosh_6");
        enemyDeathSound = Resources.Load<AudioClip>("Indiana Jones Punch");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "damage":
                audioSource.PlayOneShot(damageSound);
                break;
            case "playerAttack":
                audioSource.PlayOneShot(playerAttackSound);
                break;
            case "enemyDeath":
                audioSource.PlayOneShot(playerAttackSound);
                break;
        }
    }
}
