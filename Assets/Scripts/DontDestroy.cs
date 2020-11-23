using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static KillManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this.gameObject.GetComponent<KillManager>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
