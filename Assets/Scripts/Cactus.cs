using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float cactusDamage = 20f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player.instance.GetHurt(cactusDamage);
    }
}
