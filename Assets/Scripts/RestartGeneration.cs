using UnityEngine;

// Restarts Generation on "r" press
public class RestartGeneration : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
